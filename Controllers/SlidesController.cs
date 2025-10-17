using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class SlidesController : Controller
    {
        // GET: Slides
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new SlidesIndexVm
            {
                Slides = new List<Slide>
                {
                    new Slide
                    {
                        Id = 1,
                        Title = "عرض ترويجي 1",
                        Description = "وصف العرض الترويجي الأول",
                        ImageUrl = "/uploads/slides/slide1.jpg",
                        Order = 1,
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddDays(-10),
                        UpdatedDate = DateTime.Now.AddDays(-5),
                        LinkUrl = "https://example.com/promo1",
                        Notes = "ملاحظات حول العرض الأول"
                    },
                    new Slide
                    {
                        Id = 2,
                        Title = "عرض ترويجي 2",
                        Description = "وصف العرض الترويجي الثاني",
                        ImageUrl = "/uploads/slides/slide2.jpg",
                        Order = 2,
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddDays(-8),
                        UpdatedDate = DateTime.Now.AddDays(-3),
                        LinkUrl = "https://example.com/promo2",
                        Notes = "ملاحظات حول العرض الثاني"
                    },
                    new Slide
                    {
                        Id = 3,
                        Title = "عرض ترويجي 3",
                        Description = "وصف العرض الترويجي الثالث",
                        ImageUrl = "/uploads/slides/slide3.jpg",
                        Order = 3,
                        IsActive = false,
                        CreatedDate = DateTime.Now.AddDays(-15),
                        UpdatedDate = DateTime.Now.AddDays(-7),
                        LinkUrl = "https://example.com/promo3",
                        Notes = "ملاحظات حول العرض الثالث"
                    }
                }
            };

            return View(viewModel);
        }
    }
}