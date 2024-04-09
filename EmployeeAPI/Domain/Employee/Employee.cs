﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Domain
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime HiredDate { get; set; }
    }
}