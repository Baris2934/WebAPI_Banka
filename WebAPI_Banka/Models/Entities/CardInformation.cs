using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Banka.Models.Entities
{
    public class CardInformation : BaseEntity
    {
        // Veri tabanında tuttuğum kredi kartları burada olacak...

        public string CardUserName { get; set; }  
        public string SecurityNumber { get; set; } 
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal Limit { get; set; } // Kartın toplam limiti
        public decimal Balance { get; set; } // Kartın kullanılabilir mevcut limiti

    }
}