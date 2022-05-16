using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Banka.DesignPatterns.SingletonPattern;
using WebAPI_Banka.DTOClasses;
using WebAPI_Banka.Models.Context;
using WebAPI_Banka.Models.Entities;

namespace WebAPI_Banka.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DBInstance;
        }

        // Aşağıdaki Action test içindir. API canlıya çıkacağı zaman kesinlikle açık bırakılmamalıdır...

        /*   Test ettikten sonra yorum satırına aldım... Bilgiler oluşturuldu... Dışarıya paylaşılmamalı ama...

        [HttpGet]
        public List<PaymentDTO> GetAll()
        {
            return _db.Cards.Select(x => new PaymentDTO
            {
                CardExpiryMonth = x.CardExpiryMonth,
                CardExpiryYear = x.CardExpiryYear,
                CardNumber = x.CardNumber,
                ID = x.ID,
                CardUserName = x.CardUserName,
                SecurityNumber = x.SecurityNumber

            }).ToList();
        }

        */


        private void SetBalance(PaymentDTO item, CardInformation ci)
        {
            ci.Balance -= item.ShoppingPrice;  // Her alışverişde mevcut limitten düşürme olsun satın aldığım kadar.
            _db.SaveChanges();
        }

        [HttpPost]
        public IHttpActionResult ReceivePayment(PaymentDTO item)
        {
            CardInformation ci = _db.Cards.FirstOrDefault(x => x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber && x.CardUserName == item.CardUserName && x.CardExpiryYear == item.CardExpiryYear && x.CardExpiryMonth == item.CardExpiryMonth);

            if(ci != null)
            {
                if(ci.CardExpiryYear < DateTime.Now.Year)
                {
                    return BadRequest("Expired Card");
                }

                else if(ci.CardExpiryYear == DateTime.Now.Year)
                {
                    if(ci.CardExpiryMonth < DateTime.Now.Month)
                    {
                        return BadRequest("Expired Card");
                    }

                    if (ci.Balance >= item.ShoppingPrice)
                    {
                        SetBalance(item, ci);
                        return Ok();
                    }

                    else return BadRequest("Balance Exceeded");
                }

                if(ci.Balance >= item.ShoppingPrice)
                {
                    SetBalance(item, ci);
                    return Ok();
                }
                
            }
            return BadRequest("Card Not Found");
        }
    }
}
