using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadatak.WebApi
{
    public class Actor
    {
        [Required]
        [Range(1, 10)] // definira da int Id MORA biti izmedju 1 i 10, ali samo int Id, dalje ovi ne
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}