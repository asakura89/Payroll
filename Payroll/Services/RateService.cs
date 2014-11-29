using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Payroll.Models;

namespace Payroll.Services
{
    public class RateService : IDisposable
    {
        private PayrollEntities db = new PayrollEntities();

        public List<M_RATES> GetAllRates()
        {
            return db.M_RATES.ToList();
        }

        private String GetNewId()
        {
            String lastId = db.Database
                    .SqlQuery<String>("SELECT TOP 1 RATE_ID FROM M_RATES ORDER BY RATE_ID DESC")
                    .SingleOrDefault();
            lastId = lastId ?? "0";

            String newId = (Convert.ToInt32(lastId) + 1).ToString();

            return newId;
        }

        public M_RATES GetById(String id)
        {
            M_RATES rate = db.M_RATES.Find(id);

            if (rate == null)
                throw new ObjectNotFoundException("Rate with Id: " + id);

            return rate;
        }

        public void CreateNewRate(M_RATES rate)
        {
            rate.RATE_ID = GetNewId();
            db.M_RATES.Add(rate);
            db.SaveChanges();
        }

        public void UpdateExistingRate(M_RATES rate)
        {
            db.Entry(rate).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExistingRate(String id)
        {
            M_RATES rate = GetById(id);
            db.M_RATES.Remove(rate);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}