﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClassLibrary.Model
{
    public class Hashtag
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        [ForeignKey("POI")]
        public int PoiID { get; set; }
        public virtual POI POI { get; set; }
        public virtual ICollection<POI> POIs { get; set; }
    }
}