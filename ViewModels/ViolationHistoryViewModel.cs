using System;

namespace ThuQuan.ViewModels;

public class ViolationHistoryViewModel
{
    public string UserId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DeviceName { get; set; }
    public string Description { get; set; }
    public string Penalty { get; set; }
    public string Status { get; set; }
}
