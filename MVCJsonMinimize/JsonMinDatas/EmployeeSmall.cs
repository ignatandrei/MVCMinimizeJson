using System;
using System.Collections.Generic;
using System.Linq;


namespace JsonMinDatas
{
    public class DSmall
    {
        public int I { get; set; }
        public string D { get; set; }

        public List<ESmall> E{ get; set; }
    }
    public class ESmall
    {
        public string F { get; set; }
        public string L { get; set; }
        public string Lo { get; set; }
        public DateTime D{ get; set; }

        public string M{ get; set; }
    }

    
}