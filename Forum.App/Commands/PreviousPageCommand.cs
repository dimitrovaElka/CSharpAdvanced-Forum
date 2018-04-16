
namespace Forum.App.Commands
{
    using Contracts;

    public class PreviousPageCommand : ICommand
    {
        private ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }
        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;
            if (currentMenu is IPaginatedMenu paginateMenu)
            {
                paginateMenu.ChangePage(false);
            }

            return currentMenu;
        }
    }
}
