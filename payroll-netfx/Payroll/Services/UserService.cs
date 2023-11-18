using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Payroll.Models;

namespace Payroll.Services {
    public class UserService : IDisposable {
        readonly PayrollEntities db = new PayrollEntities();

        public List<m_User> GetAllUsers() => db.m_User.ToList();

        public m_User GetByUsername(String username) {
            m_User user = db.m_User.Find(username);

            if (user == null)
                throw new ObjectNotFoundException("User with Username: " + username);

            return user;
        }

        public void CreateNewUser(m_User user) {
            var securityService = new SecurityService();

            user.Password = securityService.HashString(user.Password);
            db.m_User.Add(user);
            db.SaveChanges();
        }

        public void UpdateExistingUser(m_User user) {
            m_User existing = GetByUsername(user.Username);
            existing.Category = user.Category;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void ChangePassword(String username, String oldPassword, String confirmPassword, String newPassword) {
            var securityService = new SecurityService();

            m_User existing = GetByUsername(username);

            if (oldPassword == String.Empty)
                throw new InvalidOperationException("Old Password must not empty.");
            if (confirmPassword == String.Empty)
                throw new InvalidOperationException("Confirm Old Password must not empty.");
            if (securityService.HashString(oldPassword) != securityService.HashString(confirmPassword))
                throw new InvalidOperationException("Confirm Password is not same as Old Password.");
            if (securityService.HashString(oldPassword) != existing.Password)
                throw new InvalidOperationException("Old Password is incorrect.");
            if (securityService.HashString(oldPassword) == securityService.HashString(newPassword))
                throw new InvalidOperationException("New Password must not same as before.");

            existing.Password = securityService.HashString(newPassword);

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExistingUser(String username) {
            m_User user = GetByUsername(username);
            db.m_User.Remove(user);
            db.SaveChanges();
        }

        public void Dispose() => db.Dispose();
    }
}