using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI_Banka.Models.Context;
using WebAPI_Banka.Models.Entities;

namespace WebAPI_Banka.DesignPatterns.StrategyPattern.Init
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        // Veri tabanı yaratıldığı zaman hangi bilgilerle yaratılmasını istiyorsak buraya yazıyoruz... 

        protected override void Seed(MyContext context)
        {
            CardInformation ci = new CardInformation();
            ci.CardUserName = "Barıs Celik";
            ci.CardNumber = "1111 1111 1111 1111";
            ci.CardExpiryYear = 2024;
            ci.CardExpiryMonth = 10;
            ci.SecurityNumber = "222";
            ci.Limit = 50000;
            ci.Balance = 50000;

            context.Cards.Add(ci);
            context.SaveChanges();
        }
    }
}