using CommonModel;
using System.Data.Entity.Core.Objects;

namespace DatabaseAccess.Login
{
    public class LoginDA
    {
        TwitterDbEntities1 context = new TwitterDbEntities1();

        public string  ValidateLoginDA(Person model)
        {
            ObjectParameter returnId = new ObjectParameter("responseMessage", typeof(string));
            var courses = context.usp_validatelogin(model.UserId, model.Password, returnId);
            return returnId.Value.ToString();
        }
        public int SignUpDA(Person model)
        {
            var cnt = context.usp_signup(model.UserId, model.Password, model.EmailId, model.FullName);
            return cnt;
        }
    }
}
