using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models {

    //58 利用 EnumHelper 輸出 enum 型別的屬性
    public enum Status {
        P , V , C
    }
    //58 利用 EnumHelper 輸出 enum 型別的屬性
    public class MyOrderVM {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }

    }

}