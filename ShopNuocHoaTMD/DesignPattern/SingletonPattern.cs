using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.DesignPattern
{
    public class SingletonPattern
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        public static volatile SingletonPattern Instance;
        private static readonly object lockObject = new object();

        public SingletonPattern() { }

        public static SingletonPattern GetInstance()
        {
            if (Instance == null)
            {
                lock (lockObject);
                if (Instance == null)
                {
                    Instance = new SingletonPattern();
                }
            }
            return Instance;
        }
        public void AddAdvertisement(Advertisement model)
        {
            if (model.Alias == null)
            {
                model.Alias = ShopNuocHoaTMD.Models.Common.Filter.FilterChar(model.Title);
            }
            model.CreatedDate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            _dbConnect.Advertisements.Add(model);
            _dbConnect.SaveChanges();
        }

        public void EditAdvertisement(Advertisement model)
        {
            _dbConnect.Advertisements.Attach(model);
            model.ModifiedDate = DateTime.Now;
            if (model.Alias == null)
            {
                model.Alias = ShopNuocHoaTMD.Models.Common.Filter.FilterChar(model.Title);
            }
            _dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
            _dbConnect.Entry(model).Property(x => x.Description).IsModified = true;
            _dbConnect.Entry(model).Property(x => x.Alias).IsModified = true;
            _dbConnect.Entry(model).Property(x => x.Image).IsModified = true;
            _dbConnect.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
            _dbConnect.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
            _dbConnect.SaveChanges();
        }

        public bool RemoveAdvertisement(int id)
        {
            var item = _dbConnect.Advertisements.Find(id);
            if (item != null)
            {
                _dbConnect.Advertisements.Remove(item);
                _dbConnect.SaveChanges();
                return true;
            }
            return false;
        }

    }
}