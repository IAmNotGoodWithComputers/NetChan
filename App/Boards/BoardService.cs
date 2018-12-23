using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NetChan.App.Boards.Views;
using NetChan.App.Threads;
using NetChan.App.Threads.Views;
using NetChan.Entities;

namespace NetChan.App.Boards
{
    public interface IBoardService
    {
        BoardListViewModel GetBoardList();
        Guid CreateBoard(CreateBoardFormModel formModel);
        ShowBoardViewModel GetBoardByShortName(string shortName);
        Guid CreateThread(CreateThreadFormModel formModel, string boardShortName);
    }

    public class BoardService : IBoardService
    {
        private readonly NetchanDbContext dbContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public BoardService(NetchanDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            this.dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public BoardListViewModel GetBoardList()
        {
            var boards = dbContext.Boards
                .OrderBy(b => b.ShortName)
                .ToList();

            return CreateBoardListViewModel(boards);
        }

        public Guid CreateBoard(CreateBoardFormModel formModel)
        {
            var board = new Board();
            board.Id = Guid.NewGuid();
            board.Title = formModel.Title;
            board.ShortName = formModel.ShortName;
            board.IsSfw = true;

            dbContext.Add(board);
            dbContext.SaveChanges();

            return board.Id;
        }

        public Guid CreateThread(CreateThreadFormModel formModel, string boardShortName)
        {
            var board = dbContext.Boards.FirstOrDefault(b => b.ShortName == boardShortName);

            var thread = new Thread();
            thread.Id = Guid.NewGuid();
            thread.Board = board;
            thread.Content = formModel.Content;
            thread.Title = formModel.Title;
            thread.UserName = formModel.Username;
            thread.Attachments = new List<Attachment>();
            var uploadPath = hostingEnvironment.ContentRootPath + "/wwwroot/uploads/";
            
            foreach (var attachment in formModel.Attachments)
            {
                var a = new Attachment();
                a.Id = Guid.NewGuid();
                if (!attachment.ContentType.Contains("image") || !attachment.FileName.Contains("."))
                {
                    continue;
                }

                a.Ext = attachment.FileName.Split(".").Last();
                var fileStream = new FileStream(uploadPath + a.Id + "." + a.Ext, FileMode.Create);
                attachment.CopyTo(fileStream);
                thread.Attachments.Add(a);
                dbContext.Add(a);
            }

            dbContext.Add(thread);
            dbContext.SaveChanges();

            return thread.Id;
        }
        
        public ShowBoardViewModel GetBoardByShortName(string shortName)
        {
            var threads = dbContext.Threads
                .Include(t => t.Board)
                .Where(t => t.Board.ShortName == shortName)
                .ToList();

            var board = dbContext.Boards.FirstOrDefault(b => b.ShortName == shortName);

            return CreateShowBoardViewModel(threads, board);
        }

        private ShowBoardViewModel CreateShowBoardViewModel(List<Thread> threads, Board board)
        {
            var threadList = new List<ShowBoardViewModelThread>();
            foreach (var t in threads)
            {
                threadList.Add(new ShowBoardViewModelThread(t.Id.ToString(), t.Title, t.Content, t.CreateDate));
            }
            
            return new ShowBoardViewModel(board.Title, board.ShortName, threadList);
        }

        private static BoardListViewModel CreateBoardListViewModel(IEnumerable<Board> boards)
        {
            var boardList = boards.Select(b => new BoardListViewModelBoard(b.Id.ToString(), b.ShortName, b.IsSfw)).ToList();
            
            return new BoardListViewModel(boardList);
        }
    }
}