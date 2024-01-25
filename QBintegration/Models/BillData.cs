public class BillData
{
    public string VendorName { get; set; }
    public DateTime BillDate { get; set; }
    public List<LineItem> LineItems { get; set; }
}

