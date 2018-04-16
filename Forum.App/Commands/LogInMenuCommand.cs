using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class LogInMenuCommand : NavigationCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
