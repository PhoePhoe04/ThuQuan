using System;
using System.Collections.Generic;

namespace YourProjectNamespace.Models
{
    public class ViolationHistoryViewModel
    {
        // Chứa danh sách các vi phạm
        public List<ViolationHistoryItem> ViolationHistoryItems { get; set; }
    }

    public class ViolationHistoryItem
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeDate => Date.TimeOfDay;
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string StatusText { get; set; }
        public string StatusClass { get; set; }
        public bool CanAppeal { get; set; }
    }
}
