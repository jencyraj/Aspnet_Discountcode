using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponFetch.API.Entities
{
    public class CouponCode
    {
        // Table1 Admin_table
        public int Brand_Id { get; set; }
        public string BrandName { get; set; }

        // Table 2: User_Table

        public int UId { get; set; }
        public string UserName { get; set; }
        //public int Brand_Id { get; set; }


        // Table 3: Brand_CouponCode

        public int CId { get; set; }
        public string couponcode { get; set; }
        public int Amount { get; set; }// percentage %

        // Table 4: User_discoutTable

        public int DisId { get; set; }
    }
}
