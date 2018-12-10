using CommonModel;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAccess.Profile
{
    public class ProfileDA
    {
        TwitterDbEntities1 context = new TwitterDbEntities1();

        public string GetFollowerCount(string userId)
        {
            var followerCount = context.tx_following.Where(t => t.following_Id == userId).Select(t => t);
            return followerCount.Count().ToString();
        }
        public string GetFollowingCount(string userId)
        {
            var followingCount = context.tx_following.Where(t => t.UserId == userId).Select(t => t);
            return followingCount.Count().ToString();
        }
        public string GetTweetsCount(string userId)
        {
            var tweetsCount = context.tm_tweets.Where(t => t.UserId == userId).Select(t => t);
            return tweetsCount.Count().ToString();
        }

        
        public List<Person> GetProfileList(string profileName)
        {
            List<Person> objPerson = new List<Person>();

              var profileList = context.tm_person.Where(t => t.FullName.Contains(profileName)).Select(t => t);
            foreach (var item in profileList)
            {
                Person obj = new Person()
                {
                    FullName = item.FullName,
                    UserId = item.UserId,
                    EmailId = item.EmailId 
                };
                objPerson.Add(obj);
            }
            return objPerson;
        }
        public int Markfollow(follow model)
        {
            var count = context.usp_follow_profile(model.ProfileId, model.UserId, model.Follow);
            return count;
           
        }
        public int DeactivateProfile(Person model)
        {
            var count = context.usp_profile_actions(model.UserId,"D", model.EmailId, model.FullName);
            return count;
        }

        public int UpdateProfile(Person model)
        {
            var count = context.usp_profile_actions(model.UserId, "U", model.EmailId, model.FullName);
            return count;
        }

    }
}
