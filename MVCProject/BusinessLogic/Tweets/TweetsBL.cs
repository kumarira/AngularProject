using CommonModel;
using DatabaseAccess.Tweets;
using System.Collections.Generic;

namespace BusinessLogic.Tweets
{
    public class TweetsBL
    {
        TweetsDA obj;
        public TweetsBL()
        {
            obj = new TweetsDA();
        }
        public List<tweets> GetTweetsListBL(string Userid)
        {
            return obj.GetTweets(Userid);
        }
        public IndexViewtweet GetIndexedViewTweetsBL(string UserId)
        {
            IndexViewtweet objindex = new IndexViewtweet();
            tweets tweet = new tweets();
            objindex.Details = tweet;
            objindex.List = obj.GetTweets(UserId);
            return objindex;
        }
        public int AddUpdateTweetBL(tweets model, string Userid, string Action)
        {
          return  obj.ActionsTweet(model, Userid, Action);
        }
        public int TweetsCountBL(string Userid)
        {
            return obj.TweetsCount(  Userid);

        }
    }
}
