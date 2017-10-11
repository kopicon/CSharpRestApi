using System;
using System.Collections.Generic;
using System.Text;

namespace List.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int MusicId { get; set; }
        public Music Music { get; set; }
    }
}
