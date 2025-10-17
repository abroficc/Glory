using System;

namespace Inspinia.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string LinkUrl { get; set; }
        public string Notes { get; set; }
    }
}