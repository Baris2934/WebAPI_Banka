using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Banka.DTOClasses
{
    public class PaymentDTO
    {
        // Projemiz ile haberleşecek sınıfımız..

        // Müşterimin ID'si var, Kredi kartı bilgisi var, Güvenlik numarası bilgisi var, Son kullanma tarihi var ve bu müşterinin ne kadar harcama yapmak istediğini bilmem gerekecek. Bu bilgileri alıp, veritabanımdaki bilgilerle karşılaştırıp, karar verip alışveriş sitesine göndermem lazım...

        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }

    }
}