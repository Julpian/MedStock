namespace MedStock.API.DTOs
{
    public class DashboardSummaryDto
    {
        public int TotalProducts { get; set; }
        public int TotalStock { get; set; }
        public int LowStockCount { get; set; }
        public int ExpiringSoonCount { get; set; }
    }
}