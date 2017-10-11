using System;
using System.ComponentModel.DataAnnotations;

namespace MusicListBLL.BusinessObjects
{
    public class MusicBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        public string Style { get; set; }

        public string FullName
        {
            get { return $"{Name} {Style}"; }
        }
    }
}
