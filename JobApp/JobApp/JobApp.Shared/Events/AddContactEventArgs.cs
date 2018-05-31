using JobApp.Shared.Models;
using System;

namespace JobApp.Shared.Events
{
    public class AddContactEventArgs : EventArgs
    {
        public AddContactEventArgs(Contact contact)
        {
            this.Contact = contact;
        }

        public Contact Contact { get; private set; }
    }
}
