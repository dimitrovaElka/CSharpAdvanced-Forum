
namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddPostMenuCommand : NavigationCommand
    {
        private IMenuFactory menuFactory;

        public AddPostMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }

        //public IMenu Execute(params string[] args)
        //{
        //    string commandName = this.GetType().Name;
        //    string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
        //    var menu = menuFactory.CreateMenu(menuName);
        //    return menu;
        //}
    }
}
