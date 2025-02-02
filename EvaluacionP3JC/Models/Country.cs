﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3JC.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
    }
}
