using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI_Banka.DesignPatterns.StrategyPattern.Init;
using WebAPI_Banka.Models.Entities;

namespace WebAPI_Banka.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }

        public DbSet<CardInformation> Cards { get; set; }
    }
}