using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBL.Models.DataBase;

namespace WarehouseBL.Models.View
{
    public class ViewModel
    {
        public IEnumerable<Staff> staffs { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Operation> operations { get; set; }
        
        public string Status { get; set; }
    }
}
