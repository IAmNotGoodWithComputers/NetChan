using System.Collections.Generic;
using System.Linq;
using NetChan.App.Boards.Views;
using NetChan.Entities;

namespace NetChan.App.Boards
{
    public class BoardService
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

        private static BoardListViewModel CreateBoardListViewModel(IEnumerable<Board> boards)
        {
            var boardList = boards.Select(b => new BoardListViewModelBoard(b.Id.ToString(), b.Title, b.IsSfw)).ToList();
            return new BoardListViewModel(boardList);
        }
    }
}