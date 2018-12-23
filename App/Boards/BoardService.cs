using System;
using System.Collections.Generic;
using System.Linq;
using NetChan.App.Boards.Views;
using NetChan.Entities;

namespace NetChan.App.Boards
{
    public interface IBoardService
    {
        BoardListViewModel GetBoardList();
        Guid CreateBoard(CreateBoardFormModel formModel);
    }

    public class BoardService : IBoardService
    {
        private readonly NetchanDbContext dbContext;

        public BoardService(NetchanDbContext dbContext)
        {
            this.dbContext = dbContext;
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
            board.Title = formModel.ShortName;
            board.ShortName = formModel.ShortName;
            board.IsSfw = true;

            dbContext.Add(board);
            dbContext.SaveChanges();

            return board.Id;
        }

        private static BoardListViewModel CreateBoardListViewModel(IEnumerable<Board> boards)
        {
            var boardList = boards.Select(b => new BoardListViewModelBoard(b.Id.ToString(), b.Title, b.IsSfw)).ToList();
            return new BoardListViewModel(boardList);
        }
    }
}