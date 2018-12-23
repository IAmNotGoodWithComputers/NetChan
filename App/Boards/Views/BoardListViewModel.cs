using System.Collections.Generic;

namespace NetChan.App.Boards.Views
{
    public class BoardListViewModel
    {
        public List<BoardListViewModelBoard> Boards;

        public BoardListViewModel(List<BoardListViewModelBoard> boards)
        {
            Boards = boards;
        }
    }
    
    public class BoardListViewModelBoard
    {
        public readonly string Id;
        public readonly string ShortName;
        public readonly bool IsSfw;

        public BoardListViewModelBoard(string id, string shortName, bool isSfw)
        {
            Id = id;
            ShortName = shortName;
            IsSfw = isSfw;
        }
    }   
}