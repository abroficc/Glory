using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Glory77.Data;
using Glory77.Models;

namespace Glory77.Controllers
{
    public class MatchingReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchingReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatchingReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MatchingReports.Include(m => m.Provider);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MatchingReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchingReport = await _context.MatchingReports
                .Include(m => m.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchingReport == null)
            {
                return NotFound();
            }

            return View(matchingReport);
        }

        // GET: MatchingReports/Create
        public IActionResult Create()
        {
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName");
            return View();
        }

        // POST: MatchingReports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProviderId,ReportTime,Networks,TotalReadyProvider,TotalReadySystem,CountReadyProvider,CountReadySystem,TotalCancelledProvider,TotalCancelledSystem,CountCancelledProvider,CountCancelledSystem,TotalPendingProvider,TotalPendingSystem,CountPendingProvider,CountPendingSystem,MatchingStatus")] MatchingReport matchingReport)
        {
            if (ModelState.IsValid)
            {
                matchingReport.CreatedAt = DateTime.Now;
                _context.Add(matchingReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", matchingReport.ProviderId);
            return View(matchingReport);
        }

        // GET: MatchingReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchingReport = await _context.MatchingReports.FindAsync(id);
            if (matchingReport == null)
            {
                return NotFound();
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", matchingReport.ProviderId);
            return View(matchingReport);
        }

        // POST: MatchingReports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProviderId,ReportTime,Networks,TotalReadyProvider,TotalReadySystem,CountReadyProvider,CountReadySystem,TotalCancelledProvider,TotalCancelledSystem,CountCancelledProvider,CountCancelledSystem,TotalPendingProvider,TotalPendingSystem,CountPendingProvider,CountPendingSystem,MatchingStatus,CreatedAt")] MatchingReport matchingReport)
        {
            if (id != matchingReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchingReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchingReportExists(matchingReport.Id))
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
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", matchingReport.ProviderId);
            return View(matchingReport);
        }

        // GET: MatchingReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchingReport = await _context.MatchingReports
                .Include(m => m.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchingReport == null)
            {
                return NotFound();
            }

            return View(matchingReport);
        }

        // POST: MatchingReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchingReport = await _context.MatchingReports.FindAsync(id);
            if (matchingReport != null)
            {
                _context.MatchingReports.Remove(matchingReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchingReportExists(int id)
        {
            return _context.MatchingReports.Any(e => e.Id == id);
        }
    }
}