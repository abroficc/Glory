using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class PricingGroupsController : Controller
    {
        public IActionResult Index()
        {
            // For now, just return the view without any specific model data
            // The PricingGroups page is primarily client-side rendered
            return View();
        }
        
        [HttpPost]
        public IActionResult GetPricingGroups([FromBody] DataTablesRequest request)
        {
            // This is a mock implementation. In a real application, you would:
            // 1. Parse the request parameters (draw, start, length, search, order)
            // 2. Query your database with server-side pagination, filtering, and sorting
            // 3. Return the data in the format expected by DataTables
            
            // Mock data for demonstration
            var mockData = new List<PricingGroup>
            {
                new PricingGroup { Id = 1, GroupName = "مجموعة تسعيرة 1", Mobile = 1.02m, YOU = 1.05m, YOUPackages = 0.98m, Safafon = 1.01m, WiFi = 0.99m, MobileWholesale = 1.03m, YOUWholesale = 1.00m, SafafonWholesale = 0.97m, Internet = 1.04m, Landline = 1.02m, MobileRecharge = 0.98m, MoneyTransfer = 1.01m },
                new PricingGroup { Id = 2, GroupName = "مجموعة تسعيرة 2", Mobile = 0.98m, YOU = 1.02m, YOUPackages = 1.00m, Safafon = 0.99m, WiFi = 1.01m, MobileWholesale = 0.97m, YOUWholesale = 1.03m, SafafonWholesale = 1.02m, Internet = 0.98m, Landline = 1.04m, MobileRecharge = 1.00m, MoneyTransfer = 0.99m }
            };
            
            // In a real implementation, you would apply:
            // - Pagination: request.Start, request.Length
            // - Search: request.Search?.Value
            // - Ordering: request.Order
            
            var response = new DataTablesResponse
            {
                Draw = request.Draw,
                RecordsTotal = mockData.Count,
                RecordsFiltered = mockData.Count,
                Data = mockData.Skip(request.Start).Take(request.Length).ToList()
            };
            
            return Json(response);
        }
    }
    
    // Data models for DataTables integration
    public class PricingGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public decimal Mobile { get; set; }
        public decimal YOU { get; set; }
        public decimal YOUPackages { get; set; }
        public decimal Safafon { get; set; }
        public decimal WiFi { get; set; }
        public decimal MobileWholesale { get; set; }
        public decimal YOUWholesale { get; set; }
        public decimal SafafonWholesale { get; set; }
        public decimal Internet { get; set; }
        public decimal Landline { get; set; }
        public decimal MobileRecharge { get; set; }
        public decimal MoneyTransfer { get; set; }
    }
    
    public class DataTablesRequest
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public SearchRequest Search { get; set; }
        public List<OrderRequest> Order { get; set; }
        public List<ColumnRequest> Columns { get; set; }
    }
    
    public class SearchRequest
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
    
    public class OrderRequest
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
    
    public class ColumnRequest
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public SearchRequest Search { get; set; }
    }
    
    public class DataTablesResponse
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<PricingGroup> Data { get; set; }
    }
}