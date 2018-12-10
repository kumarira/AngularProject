using CommonModel;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAccess.Tweets
{
    public class TweetsDA
    {
        TwitterDbEntities1 context = new TwitterDbEntities1();

        public int TweetsCount(string Userid)
        {
            var tweets = (from t in context.tm_tweets
                          where t.UserId == Userid
                          select new { t.UserId, t.message, t.tweet_Id, t.CreatedDate });
            return tweets.Count();
        }
        public List<tweets> GetTweets(string Userid)
        {
            List<tweets> objlist = new List<tweets>();
            
            var tweets = (from t in context.tm_tweets
                          where t.UserId == Userid
                          select new { t.UserId, t.message, t.tweet_Id, t.CreatedDate });  
           
            foreach (var item in tweets)
            {
                tweets obj = new tweets()
                {
                    message = item.message,
                    UserId = item.UserId,
                    CreatedDate = item.CreatedDate,
                   tweet_Id = item.tweet_Id
                };
                objlist.Add(obj);
            }

            return objlist;
        }

        public int ActionsTweet(tweets model,string Userid,string Action )
        {            
            var count = context.usp_tweets_actions(Userid, Action, model.tweet_Id, model.message);
            return count;
        }
    }
}
