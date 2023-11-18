using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Payroll.Models;

namespace Payroll.Services {
    public class SalaryService : IDisposable {
        readonly PayrollEntities db = new PayrollEntities();

        public List<d_Salary> GetAllSalaries() => db.d_Salary.ToList();

        String GetNewId() {
            String lastId = db.Database
                .SqlQuery<String>("SELECT TOP 1 SalaryId FROM d_Salary ORDER BY SalaryId DESC")
                .SingleOrDefault();
            lastId = lastId ?? "0";

            String newId = (Convert.ToInt32(lastId) + 1).ToString();

            return newId;
        }

        public d_Salary GetById(String id) {
            d_Salary salary = db.d_Salary.Find(id);

            if (salary == null)
                throw new ObjectNotFoundException("Salary with id: " + id);

            return salary;
        }

        public void CreateNewSalary(d_Salary salary) {
            salary.SalaryId = GetNewId();
            db.d_Salary.Add(salary);
            db.SaveChanges();
        }

        public void UpdateExistingSalary(d_Salary salary) {
            db.Entry(salary).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExistingSalary(String id) {
            d_Salary salary = GetById(id);
            db.d_Salary.Remove(salary);
            db.SaveChanges();
        }

        public void Dispose() => db.Dispose();
    }
}