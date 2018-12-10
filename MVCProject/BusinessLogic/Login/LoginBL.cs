using CommonModel;
using DatabaseAccess.Login;

namespace BusinessLogic.Login
{
    public class LoginBL
    {
        LoginDA obj;
        public LoginBL()
        {
              obj = new LoginDA();
        }
        public string ValidateLoginBL(Person model)
        {            
            return obj.ValidateLoginDA(model);
        }
        public int SignUpBL(Person model)
        {
            return obj.SignUpDA(model);
        }

    }
}
