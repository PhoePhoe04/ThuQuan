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
                new RoomViewModel { RoomName = "Phòng A", ImageRoom = "/images/room-a.jpg" },
                new RoomViewModel { RoomName = "Phòng B", ImageRoom = "/images/room-b.jpg" },
                new RoomViewModel { RoomName = "Phòng C", ImageRoom = "/images/room-c.jpg" },
                new RoomViewModel { RoomName = "Phòng D", ImageRoom = "/images/room-d.jpg" },
                new RoomViewModel { RoomName = "Phòng E", ImageRoom = "/images/room-e.jpg" },
                new RoomViewModel { RoomName = "Phòng F", ImageRoom = "/images/room-f.jpg" }
            };

            var model = new BookingViewModel
            {
                Rooms = rooms
            };

            return View(model);
        }
    }
}
