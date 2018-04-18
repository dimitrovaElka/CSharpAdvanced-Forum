
namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;
  
    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private IMenuFactory menuFactory;

        public PostCommand(ISession session, IPostService postService, IMenuFactory menuFactory)
        {
            this.session = session;
            this.postService = postService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;
            string postTitle = args[0];
            string postCategory = args[1];
            string postContent = args[2];

            bool validTitle = !string.IsNullOrWhiteSpace(postTitle);
            bool validCategory = !string.IsNullOrWhiteSpace(postCategory);
            bool validContent = !string.IsNullOrWhiteSpace(postContent);

            if (!validTitle || !validCategory || !validContent)
            {
                throw new ArgumentException("All field must be filled!");
            }

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();

            IMenu menu = this.menuFactory.CreateMenu("ViewPostMenu");
            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }
            return menu;
        }
    }
}
