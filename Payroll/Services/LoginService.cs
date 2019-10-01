using System;
using Payroll.Models;

namespace Payroll.Services
{
    public class LoginService
    {
        private PayrollEntities db;

        public const String LoggedUser = "LoggedUser";

        public Boolean IsUserValid(String username, String userpass)
        {
            var securityService = new SecurityService();
            String hashedPassword = securityService.HashString(userpass);
            m_User userInDb;
            Boolean isUserValid = false;
            using (db = new PayrollEntities())
            {
                userInDb = db.m_User.Find(username);
                if (userInDb != null)
                    isUserValid = userInDb.Password == hashedPassword;
            }

            return isUserValid;
        }
    }
}