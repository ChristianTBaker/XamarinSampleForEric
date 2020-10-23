using System;
using HelloPrism.Models;

namespace HelloPrism.Interfaces
{
    public interface IProfileManager
    {
        public Profile GetProfile();
        public void SaveProfile(Profile userProfile);
    }
}
