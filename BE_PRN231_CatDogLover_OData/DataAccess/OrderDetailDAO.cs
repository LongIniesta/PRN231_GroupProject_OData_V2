﻿using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public OrderDetail GetByID(int id)
        {
            OrderDetail result = null;
            try
            {
                var DBContext = new PRN231Context();
                result = DBContext.OrderDetails.SingleOrDefault(u => u.OrderDetailId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<OrderDetail> GetForSeller(int accountId)
        {
            List<OrderDetail> result = null;
            try
            {
                var DBContext = new PRN231Context();
                List<string> list = DBContext.ServiceSchedulers.Include(s => s.Service).Include(s => s.Service.Post).Where(s => s.Service.Post.OwnerId == accountId).Select(s => s.ItemId).ToList();
                list.AddRange(DBContext.Products.Include(p => p.Post).Where(p => p.Post.OwnerId == accountId).Select(p => p.ItemId).ToList());
                result = DBContext.OrderDetails.Where(od => list.Any( l => l==od.ItemId)).Include(od => od.Item).Include(od => od.Item.Product).Include(od => od.Item.ServiceScheduler).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        public OrderDetail AddOrderDetail(OrderDetail OrderDetail)
        {
            OrderDetail result;
            try
            {
                var DBContext = new PRN231Context();
                result = DBContext.OrderDetails.Add(OrderDetail).Entity;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public OrderDetail RemoveOrderDetail(int id)
        {
            OrderDetail result;
            OrderDetail OrderDetail = GetByID(id);
            try
            {
                var DBContext = new PRN231Context();
                result = DBContext.OrderDetails.Remove(OrderDetail).Entity;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public OrderDetail UpdateOrderDetail(OrderDetail OrderDetail)
        {
            OrderDetail result;
            try
            {
                var DBContext = new PRN231Context();
                result = DBContext.OrderDetails.Update(OrderDetail).Entity;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            List<OrderDetail> result = new List<OrderDetail>();
            try
            {
                var DBContext = new PRN231Context();
                result = DBContext.OrderDetails.Include(od => od.Item).Include(od => od.Item.Product).Include(od => od.Item.ServiceScheduler).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
