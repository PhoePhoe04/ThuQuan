using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Models;

namespace ThuQuan.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            // Sample data for demonstration
            var cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    Title = "Title",
                    Description = "Add text or whatever you'd like to say. Add main takeaway points, quotes, anecdotes, or even a very short story.",
                    ImageUrl = "/images/placeholder.jpg",
                    Price = 100000,
                    Quantity = 1
                },
                new CartItem
                {
                    Id = 2,
                    Title = "Title",
                    Description = "Add text or whatever you'd like to say. Add main takeaway points, quotes, anecdotes, or even a very short story.",
                    ImageUrl = "/images/placeholder.jpg",
                    Price = 150000,
                    Quantity = 1
                }
            };

            ViewBag.CartItems = cartItems;
            return View();
        }
    }
}