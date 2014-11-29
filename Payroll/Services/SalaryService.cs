using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Payroll.Models;

namespace Payroll.Services
{
    public class SalaryService : IDisposable
    {
        private PayrollEntities db = new PayrollEntities();

        public List<M_EMP_SALARY> GetAllSalaries()
        {
            return db.M_EMP_SALARY.ToList();
        }

        private String GetNewId()
        {
            String lastId = db.Database
                    .SqlQuery<String>("SELECT TOP 1 SALARY_ID FROM M_EMP_SALARY ORDER BY SALARY_ID DESC")
                    .SingleOrDefault();
            lastId = lastId ?? "0";

            String newId = (Convert.ToInt32(lastId) + 1).ToString();

            return newId;
        }

        public M_EMP_SALARY GetById(String id)
        {
            M_EMP_SALARY salary = db.M_EMP_SALARY.Find(id);

            if (salary == null)
                throw new ObjectNotFoundException("Salary with id: " + id);

            return salary;
        }

        public void CreateNewSalary(M_EMP_SALARY salary)
        {
            salary.SALARY_ID = GetNewId();
            db.M_EMP_SALARY.Add(salary);
            db.SaveChanges();
        }

        public void UpdateExistingSalary(M_EMP_SALARY salary)
        {
            db.Entry(salary).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExistingSalary(String id)
        {
            M_EMP_SALARY salary = GetById(id);
            db.M_EMP_SALARY.Remove(salary);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}