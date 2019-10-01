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

        public List<m_Rate> GetAllRates()
        {
            return db.m_Rate.ToList();
        }

        private String GetNewId()
        {
            String lastId = db.Database
                    .SqlQuery<String>("SELECT TOP 1 RateId FROM m_Rate ORDER BY RateId DESC")
                    .SingleOrDefault();
            lastId = lastId ?? "0";

            String newId = (Convert.ToInt32(lastId) + 1).ToString();

            return newId;
        }

        public m_Rate GetById(String id)
        {
            m_Rate rate = db.m_Rate.Find(id);

            if (rate == null)
                throw new ObjectNotFoundException("Rate with Id: " + id);

            return rate;
        }

        public void CreateNewRate(m_Rate rate)
        {
            rate.RateId = GetNewId();
            db.m_Rate.Add(rate);
            db.SaveChanges();
        }

        public void UpdateExistingRate(m_Rate rate)
        {
            db.Entry(rate).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExistingRate(String id)
        {
            m_Rate rate = GetById(id);
            db.m_Rate.Remove(rate);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}