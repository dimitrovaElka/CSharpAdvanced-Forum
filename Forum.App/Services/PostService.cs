namespace Forum.App.Services
{
    using Forum.App.Contracts;
    using Forum.App.ViewModels;
    using Forum.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private ISession session;

        public PostService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            throw new NotImplementedException();
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.FirstOrDefault(c => c.Id == categoryId).Name;
            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts = this.forumData.Posts.Where(p => p.CategoryId == categoryId).Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
