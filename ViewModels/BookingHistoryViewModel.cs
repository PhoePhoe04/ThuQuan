namespace ThuQuan.ViewModels;
public class BookingHistoryViewModel
{
    public List<BookingHistoryItem> BookingHistoryItems { get; set; }
}

public class BookingHistoryItem
{
    public List<BookedRoom> BookedRooms { get; set; }
}

public class BookedRoom
{
    public string ImageUrl { get; set; }
    public string RoomName { get; set; }
    public DateTime BookingDate { get; set; }
    public TimeSpan TimeBooking => BookingDate.TimeOfDay;
    public string Status { get; set; }
    public string DeviceName { get; set; }
}
