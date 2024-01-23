using System
using System.Collections.Generic;

namespace QuickBokos.Models{
    public class BillData{
        public string VendorName{get; set;}
        public DateTime BillDate{get; set;}
        public List<LineItem> LineItems{get; set;}
    }
    public class LineItem{
        public string Description {get; set;}
        public decimal Amount {get; set;}
}