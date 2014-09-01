using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cosen.Models
{
    public class StyleInfo
    {
        [Display(Name="款式名称")]
        public string Style_Name { get; set; }
        [Display(Name = "款式代码")]
        public string Style_No { get; set; }
        [Display(Name = "库存数量")]
        public decimal Count { get; set; }
    }
}