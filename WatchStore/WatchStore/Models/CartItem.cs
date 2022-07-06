using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class CartItem
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public string Gender { get; set; }
        public int unitPrice { get; set; }
        public int quantity { get; set; }
        public int intoMoney
        {
            get
            {
                return quantity * unitPrice;
            }
        }
    }
}