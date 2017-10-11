using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListBLL.BusinessObjects
{
    public class OrderBO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int MusicId { get; set; }
        public MusicBO Music { get; set; }
    }
}
