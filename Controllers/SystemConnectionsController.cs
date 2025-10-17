using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Glory77.Data;
using Glory77.Models;
using System.Linq.Dynamic.Core;

namespace Glory77.Controllers
{
    public class SystemConnectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemConnectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemConnections
        public async Task<IActionResult> Index()
        {
            try
            {
                var applicationDbContext = _context.SystemConnections
                    .Include(s => s.Provider)
                    .Where(s => s != null); // Filter out null entities
                
                var connections = await applicationDbContext.ToListAsync();
                
                // Handle potential null values in the entities
                foreach (var connection in connections)
                {
                    if (connection != null)
                    {
                        connection.SystemName = connection.SystemName ?? "";
                        connection.ConnectionStatus = connection.ConnectionStatus ?? "";
                        connection.ProviderType = connection.ProviderType ?? "";
                        connection.SupportedNetworks = connection.SupportedNetworks ?? "";
                        connection.Direction = connection.Direction ?? "";
                        connection.AccountSources = connection.AccountSources ?? "";
                        connection.Employees = connection.Employees ?? "";
                        connection.AlertSettings = connection.AlertSettings ?? "";
                        connection.SuspensionSettings = connection.SuspensionSettings ?? "";
                        
                        if (connection.Provider != null)
                        {
                            connection.Provider.ProviderName = connection.Provider.ProviderName ?? "غير محدد";
                        }
                    }
                }
                
                return View(connections);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in Index: {ex.Message}");
                // Return an empty list if there's an error
                return View(new List<SystemConnection>());
            }
        }

        // GET: SystemConnections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemConnection = await _context.SystemConnections
                .Include(s => s.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemConnection == null)
            {
                return NotFound();
            }

            return View(systemConnection);
        }

        // GET: SystemConnections/Create
        public IActionResult Create()
        {
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName");
            return View();
        }

        // POST: SystemConnections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProviderId,ConnectionTime,SystemName,ConnectionStatus,LastCheck,ResponseTime,ErrorMessage,ProviderType,Balance,SupportedNetworks,Direction,AccountSources,Employees,AlertSettings,SuspensionSettings")] SystemConnection systemConnection)
        {
            if (ModelState.IsValid)
            {
                systemConnection.CreatedAt = DateTime.Now;
                _context.Add(systemConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", systemConnection.ProviderId);
            return View(systemConnection);
        }

        // GET: SystemConnections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemConnection = await _context.SystemConnections.FindAsync(id);
            if (systemConnection == null)
            {
                return NotFound();
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", systemConnection.ProviderId);
            return View(systemConnection);
        }

        // POST: SystemConnections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProviderId,ConnectionTime,SystemName,ConnectionStatus,LastCheck,ResponseTime,ErrorMessage,ProviderType,Balance,SupportedNetworks,Direction,AccountSources,Employees,AlertSettings,SuspensionSettings,CreatedAt")] SystemConnection systemConnection)
        {
            if (id != systemConnection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemConnectionExists(systemConnection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", systemConnection.ProviderId);
            return View(systemConnection);
        }

        // GET: SystemConnections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemConnection = await _context.SystemConnections
                .Include(s => s.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemConnection == null)
            {
                return NotFound();
            }

            return View(systemConnection);
        }

        // POST: SystemConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemConnection = await _context.SystemConnections.FindAsync(id);
            if (systemConnection != null)
            {
                _context.SystemConnections.Remove(systemConnection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: SystemConnections/GetProvidersData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetProvidersData()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 10;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var query = _context.SystemConnections.Include(s => s.Provider).AsQueryable();

                // Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(p => 
                        (p.Provider != null && p.Provider.ProviderName.Contains(searchValue)) ||
                        (p.ProviderType != null && p.ProviderType.Contains(searchValue)) ||
                        (p.ConnectionStatus != null && p.ConnectionStatus.Contains(searchValue))
                    );
                }

                // Getting records total count
                recordsTotal = await query.CountAsync();

                // Sorting - using Dynamic LINQ for flexible sorting
                var columnName = "";
                switch (sortColumn)
                {
                    case "0":
                        columnName = "Id"; // QueueNumber
                        break;
                    case "1":
                        columnName = "Provider.ProviderName";
                        break;
                    case "2":
                        columnName = "ProviderType";
                        break;
                    case "3":
                        columnName = "ConnectionStatus";
                        break;
                    case "4":
                        columnName = "Balance";
                        break;
                    default:
                        columnName = "Id";
                        break;
                }
                
                var sortDirection = sortColumnDirection == "asc" ? "" : " descending";
                if (!string.IsNullOrEmpty(columnName))
                {
                    // Use a try-catch block for sorting to handle any potential issues
                    try
                    {
                        query = query.OrderBy(columnName + sortDirection);
                    }
                    catch
                    {
                        // If sorting fails, fallback to default sorting
                        query = query.OrderBy("Id");
                    }
                }

                // Pagination
                var data = await query.Skip(skip).Take(pageSize).ToListAsync();

                // Prepare response data
                var responseData = data.Select(item => new
                {
                    QueueNumber = item.Id,
                    ProviderName = item.Provider != null ? item.Provider.ProviderName : "غير محدد",
                    Type = item.ProviderType ?? "",
                    IsActive = item.ConnectionStatus ?? "",
                    Balance = item.Balance,
                    AlertLimit = "0", // Placeholder - you can add actual data here
                    SuspendLimit = "0", // Placeholder - you can add actual data here
                    CancelThreshold = "0", // Placeholder - you can add actual data here
                    PendingThreshold = "0", // Placeholder - you can add actual data here
                    Retry = item.ResponseTime,
                    More = "", // Placeholder - you can add actual data here
                    Inquiry = "", // Placeholder - you can add actual data here
                    AccountBalance = item.Balance // Using same balance for demo
                }).ToList();

                return Json(new
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = responseData
                });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error in GetProvidersData: {ex.Message}");
                return Json(new { error = ex.Message });
            }
        }

        // GET: SystemConnections/GetBalance/5
        [HttpGet]
        public async Task<IActionResult> GetBalance(int id)
        {
            var systemConnection = await _context.SystemConnections.FindAsync(id);
            if (systemConnection == null)
            {
                return Json(new { error = "System connection not found" });
            }

            return Json(new { balance = systemConnection.Balance });
        }

        private bool SystemConnectionExists(int id)
        {
            return _context.SystemConnections.Any(e => e.Id == id);
        }
    }
}