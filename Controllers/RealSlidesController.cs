using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class RealSlidesController : Controller
    {
        // GET: RealSlides
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
                        Title = "عرض ترويجي 1 - الريال",
                        Description = "وصف العرض الترويجي الأول لشرائح الريال",
                        ImageUrl = "/uploads/slides/realslide1.jpg",
                        Order = 1,
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddDays(-10),
                        UpdatedDate = DateTime.Now.AddDays(-5),
                        LinkUrl = "https://example.com/realpromo1",
                        Notes = "ملاحظات حول العرض الأول لشرائح الريال"
                    },
                    new Slide
                    {
                        Id = 2,
                        Title = "عرض ترويجي 2 - الريال",
                        Description = "وصف العرض الترويجي الثاني لشرائح الريال",
                        ImageUrl = "/uploads/slides/realslide2.jpg",
                        Order = 2,
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddDays(-8),
                        UpdatedDate = DateTime.Now.AddDays(-3),
                        LinkUrl = "https://example.com/realpromo2",
                        Notes = "ملاحظات حول العرض الثاني لشرائح الريال"
                    },
                    new Slide
                    {
                        Id = 3,
                        Title = "عرض ترويجي 3 - الريال",
                        Description = "وصف العرض الترويجي الثالث لشرائح الريال",
                        ImageUrl = "/uploads/slides/realslide3.jpg",
                        Order = 3,
                        IsActive = false,
                        CreatedDate = DateTime.Now.AddDays(-15),
                        UpdatedDate = DateTime.Now.AddDays(-7),
                        LinkUrl = "https://example.com/realpromo3",
                        Notes = "ملاحظات حول العرض الثالث لشرائح الريال"
                    }
                }
            };

            return View(viewModel);
        }
    }
}