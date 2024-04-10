﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string text, string substring, StringComparison comparison)
        {
            return text.IndexOf(substring, comparison) >= 0;
        }
    }
}