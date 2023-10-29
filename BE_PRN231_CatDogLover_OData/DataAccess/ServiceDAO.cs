﻿using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServiceDAO
    {
        private static ServiceDAO instance = null;
        private static readonly object instanceLock = new object();
        private ServiceDAO() { }
        public static ServiceDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceDAO();
                    }
                    return instance;
                }
            }
        }
        public Service GetByID(string id)
        {
            Service result = null;
            try
            {
                var DBContext = new CatDogLoverContext();
                result = DBContext.Services.SingleOrDefault(u => u.ServiceId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        private string getNewId()
        {
            string result = "SV";
            var DBContext = new CatDogLoverContext();
            if (DBContext.Services.Count() <= 0) result += "1";
            else
            {
                List<string> Test = DBContext.Services.Select(i => i.ServiceId).ToList();
                int max = Test.Max(u => int.Parse(u.Substring(2, u.Length - 2))) + 1;
                result += max.ToString();
            }
            return result;
        }

        public Service AddService(Service Service)
        {
            Service result;
            try
            {
                var DBContext = new CatDogLoverContext();
                Service.ServiceId = getNewId();
                Service.ServiceSchedulers = null;
                result = DBContext.Services.Add(Service).Entity;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public Service RemoveService(string id)
        {
            Service result;
            Service Service = GetByID(id);
            try
            {
                var DBContext = new CatDogLoverContext();
                result = DBContext.Services.Remove(Service).Entity;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public Service UpdateService(Service Service)
        {
            Service result;
            try
            {
                var DBContext = new CatDogLoverContext();
                result = DBContext.Services.Update(Service).Entity;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public IEnumerable<Service> GetAll()
        {
            List<Service> result = new List<Service>();
            try
            {
                var DBContext = new CatDogLoverContext();
                result = DBContext.Services.Include(p => p.Post).Include(p => p.Post.Owner).Include(p => p.ServiceSchedulers).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
