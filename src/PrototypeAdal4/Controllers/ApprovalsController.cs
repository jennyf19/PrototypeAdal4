using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrototypeAdal4.Data;
using PrototypeAdal4.Models;

namespace PrototypeAdal4.Controllers
{
    public class ApprovalsController : Controller
    {
        private readonly PrototypeAdal4Context _context;

        public ApprovalsController(PrototypeAdal4Context context)
        {
            _context = context;    
        }

        // GET: Approvals
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder);
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var approvals = from a in _context.Approvals
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                approvals = approvals.Where(a => a.ApprovedBy.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    approvals = approvals.OrderByDescending(a => a.ApprovalStatus);
                    break;
                case "Date":
                    approvals = approvals.OrderBy(a => a.ApprovedDate);
                    break;
                case "date_desc":
                    approvals = approvals.OrderByDescending(a => a.ApprovedDate);
                    break;
                default:
                    approvals = approvals.OrderBy(a => a.ApprovalStatus);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Approval>.CreateAsync(approvals.AsNoTracking(), page?? 1, pageSize));
            //return View(await approvals.ToListAsync());
        }

        // GET: Approvals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals.Include(a => a.ApprovalStatus)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ApprovalID == id);
            if (approval == null)
            {
                return NotFound();
            }

            return View(approval);
        }

        // GET: Approvals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApprovalID,ApprovalStatus,ApprovedBy,ApprovedDate")] Approval approval)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(approval);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                              "Please try again");
            }
            return View(approval);
        }

        // GET: Approvals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals.SingleOrDefaultAsync(m => m.ApprovalID == id);
            if (approval == null)
            {
                return NotFound();
            }
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id != null)
            {
                return NotFound();
            }

            var approvalToUpdate = await _context.Approvals.SingleOrDefaultAsync(a => a.ApprovalID == id);

            if (await TryUpdateModelAsync<Approval>(approvalToUpdate, "", a => a.ApprovedDate, a => a.ApprovalStatus, a => a.ApprovedBy))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes."+
                        "Please try again.");
                }
                return RedirectToAction("Index");
            }
            return View(approvalToUpdate);
        }

        // GET: Approvals/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ApprovalID == id);

            if (approval == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Please try again.";
            }
            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approval = await _context.Approvals.AsNoTracking().SingleOrDefaultAsync(m => m.ApprovalID == id);
            if (approval == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Approvals.Remove(approval);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool ApprovalExists(int id)
        {
            return _context.Approvals.Any(e => e.ApprovalID == id);
        }
    }
}
