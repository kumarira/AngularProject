using System;
using System.ComponentModel.DataAnnotations;

namespace CommonModel
{
    public class tweets
    {
        public string UserId { get; set; }
        [Display(Name = "Tweet")]
        public string message { get; set; }
        public int tweet_Id { get; set; }
        [Display(Name = "Date")]
        public DateTime CreatedDate { get; set; }
    }
}