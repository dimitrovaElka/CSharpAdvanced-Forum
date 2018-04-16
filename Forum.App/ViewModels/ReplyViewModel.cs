﻿
namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string content) : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
