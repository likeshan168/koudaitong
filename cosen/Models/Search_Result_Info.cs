using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cosen.Models
{
    public class Search_Result_Info
    {
        public int TotalPage { get; set; }

        public IList<kdt_style_kucun_procResult> Infos { get; set; }
    }
}