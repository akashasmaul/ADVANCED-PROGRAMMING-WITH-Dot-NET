﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime Date { get; set; }
    }
}
