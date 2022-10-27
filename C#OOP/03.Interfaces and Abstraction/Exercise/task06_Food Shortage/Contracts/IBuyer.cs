using System;
using System.Collections.Generic;
using System.Text;

namespace task06_Food_Shortage
{
    public interface IBuyer
    {
        public int Food { get; set; }
        public void BuyFood();
    }
}
