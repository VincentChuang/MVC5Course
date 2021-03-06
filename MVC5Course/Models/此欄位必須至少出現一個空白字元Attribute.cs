﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC5Course.Models {

    public class 此欄位必須至少出現一個空白字元Attribute : DataTypeAttribute {

        public 此欄位必須至少出現一個空白字元Attribute() : base(DataType.Text) {
        }

        public override bool IsValid(object value) {
            string s = (value == null) ? "" : value.ToString();
            return s.Contains(" ");
        }

    }

}