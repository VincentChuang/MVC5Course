using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models {

    //56 建立一個 ViewModel 自訂輸出不同欄位屬性的 JSON 格式
    public class ProductApiViewModel {
        public int id { get; set; }
        public string name { get; set; }
    }

}