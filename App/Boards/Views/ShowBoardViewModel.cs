using System;
using System.Collections.Generic;

namespace NetChan.App.Boards.Views
{
    public class ShowBoardViewModel
    {
        public readonly string Title;
        public readonly string ShortName;
        public readonly List<ShowBoardViewModelThread> Threads;

        public ShowBoardViewModel(string title, string shortName, List<ShowBoardViewModelThread> threads)
        {
            Title = title;
            ShortName = shortName;
            Threads = threads;
        }
    }

    public class ShowBoardViewModelThread
    {
        public readonly string Id;
        public readonly string Title;
        public readonly string Content;
        public readonly DateTime CreateDate;

        public ShowBoardViewModelThread(string id, string title, string content, DateTime date)
        {
            Id = id;
            Title = title;
            Content = content;
            CreateDate = date;
        }
    }
}