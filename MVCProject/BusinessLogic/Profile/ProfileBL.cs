using CommonModel;
using DatabaseAccess.Profile;
using System.Collections.Generic;

namespace BusinessLogic.Profile
{
    public class ProfileBL
    {
        ProfileDA obj;
        public ProfileBL()
        {
            obj = new ProfileDA();
        }
        public string GetFollowerCountBL(string   userId)
        {
            return obj.GetFollowerCount(userId);
        }
        public string GetFollowingCountBL(string userId)
        {
            return obj.GetFollowingCount(userId);
        }
        public string GetTweetsCountBL(string userId)
        {
            return obj.GetTweetsCount(userId);
        }
        public List<Person> GetProfileListBL(string profileName)
        {
            return obj.GetProfileList(profileName);
        }
        public int MarkfollowBL(follow model)
        {
            return obj.Markfollow(model);
        }

        public int DeactivateProfileBL(Person model)
        {
            return obj.DeactivateProfile(model);
        }
        public int UpdateProfileBL(Person model)
        {
            return obj.UpdateProfile(model);
        }
    }
}
