using Microsoft.AspNetCore.Mvc;
using ThuQuan.ViewModels;

namespace ThuQuan.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            var rooms = new List<RoomViewModel>
            {
                new RoomViewModel
                {
                    RoomName = "Phòng A",
                    ImageRoom = "/images/room-a.jpg",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0)
                },
                new RoomViewModel
                {
                    RoomName = "Phòng B",
                    ImageRoom = "/images/room-b.jpg",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0)
                },
                new RoomViewModel
                {
                    RoomName = "Phòng C",
                    ImageRoom = "/images/room-c.jpg",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0)
                },
                new RoomViewModel
                {
                    RoomName = "Phòng D",
                    ImageRoom = "/images/room-d.jpg",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0)
                },
                new RoomViewModel
                {
                    RoomName = "Phòng E",
                    ImageRoom = "/images/room-e.jpg",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0)
                },
                new RoomViewModel
                {
                    RoomName = "Phòng F",
                    ImageRoom = "/images/room-f.jpg",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0)
                }
            };

            var model = new BookingViewModel
            {
                Rooms = rooms
            };

            return View(model);
        }
    }
}
