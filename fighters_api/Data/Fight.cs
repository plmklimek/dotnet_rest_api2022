using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace fighters_api.Data
{
    public class Fight
    {
            public int id { get; set; }
            //public int blue_fighter { get; set; }
            //public int red_fighter { get; set; }
            public DateTime _date { get; set; }
            public int? blue_fighterid { get; set; }
            public int? red_fighterid { get; set; }

            [ForeignKey("blue_fighterid")]
            public Fighters blue_fighter { get; set; }
            [ForeignKey("red_fighterid")]
            public Fighters red_fighter { get; set; }
    }
}
