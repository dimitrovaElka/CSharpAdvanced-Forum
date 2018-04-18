
namespace Forum.App.Commands
{
    using System;
    using Contracts;
    public class SignUpCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool validUsername = !(string.IsNullOrWhiteSpace(username) || username.Length < 4);
            bool validPassword = !(string.IsNullOrWhiteSpace(password) || password.Length < 4);
            if (!validUsername || !validPassword)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            bool success = this.userService.TrySignUpUser(username, password);
            if (!success)
            {
                throw new InvalidOperationException("Username already taken");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
