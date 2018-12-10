using System.ComponentModel.DataAnnotations;

namespace CommonModel
{
    public class Person
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
    }
}