using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Product : BaseEnitity
    {

        public Category Category { get; set; }

        public Decimal Price { get; set; } // 18 points can be stored using decimal

    }
}
