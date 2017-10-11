using System;
using System.Collections.Generic;

namespace List.Entities
{
    public class Music
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Style { get; set; }

        public string FullName
        {
            get { return $"{Name} {Style}"; }
        }
        public List<Order> Orders { get; set; }
    }
}
