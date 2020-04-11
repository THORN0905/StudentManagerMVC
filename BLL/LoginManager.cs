using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Web;

namespace BLL
{
    public class LoginManager
    {
        public Admins Login(Admins user)
        {
            user=new AdminLoginService().Login(user);
            if (user != null)
                HttpContext.Current.Session["CurrentUser"] = user;
            return user;
        }
    }
}
