using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.DesignPattern.MementoPattern
{
    public class CareTaker
    {
        public Memento StoredBlog;
        public void SaveMementoToSession(Memento storedBlog)
        {
            HttpContext.Current.Session["Memento"] = storedBlog as Memento;
        }
    }
}