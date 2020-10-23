using System;
using HelloPrism.Interfaces;
using HelloPrism.Models;
using Newtonsoft.Json;

namespace HelloPrism.Services
{
    public class ProfileManager : IProfileManager
    {
        public ProfileManager()
        {
        }

        public Profile GetProfile()
        {
            object profile;

            if (App.Current.Properties.TryGetValue("Profile", out profile))
            {
                return JsonConvert.DeserializeObject<Profile>((string)profile);
            }

            //TODO Error hendeling would occur here
            return new Profile();
        }

        public void SaveProfile(Profile userProfile)
        {
            var profileJson = JsonConvert.SerializeObject(userProfile);

            object profile;

            if (App.Current.Properties.TryGetValue("Profile", out profile))
                App.Current.Properties["Profile"] = profileJson;
            else
                App.Current.Properties.Add("Profile", profileJson);

            App.Current.SavePropertiesAsync();
        }

        //private Profile _userProfile;
        //public Profile UserProfile
        //{
        //    get
        //    {
        //        object profile;

        //        if (_userProfile == null && App.Current.Properties.TryGetValue("Profile", out profile))
        //        {
        //            _userProfile = JsonConvert.DeserializeObject<Profile>((string)profile);
        //        }

        //        return _userProfile;
        //    }

        //    set
        //    {
        //        var profileJson = JsonConvert.SerializeObject(value);

        //        object profile;

        //        if (App.Current.Properties.TryGetValue("Profile", out profile))
        //            App.Current.Properties["Profile"] = profileJson;
        //        else
        //            App.Current.Properties.Add("Profile", profileJson);

        //        _userProfile = value;
        //    }
        //}
    }
}
