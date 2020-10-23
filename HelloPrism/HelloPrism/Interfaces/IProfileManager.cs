using System;
using HelloPrism.Models;

namespace HelloPrism.Interfaces
{
    interface IProfileManager
    {
        public Profile GetProfile();
        public void SaveProfile(Profile userProfile);
    }
}
