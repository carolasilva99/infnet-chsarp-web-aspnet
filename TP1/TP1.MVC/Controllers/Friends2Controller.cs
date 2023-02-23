using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1.Data;
using TP1.Domain;
using TP1.MVC.Models;

namespace TP1.MVC.Controllers
{
    public class Friends2Controller : Controller
    {
        private readonly Tp1Context _context;

        public Friends2Controller(Tp1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            foreach (var friend in _context.Friends)
            {
                if (SelectedFriendsViewModel.Friends.Contains(new SelectedFriendViewModel()
                    {
                        BirthDate = friend.BirthDate,
                        Email = friend.Email,
                        LastName = friend.LastName,
                        Id = friend.Id,
                        Name = friend.Name
                    })) continue;
                var editorViewModel = new SelectedFriendViewModel()
                {
                    Id = friend.Id,
                    Name = friend.Name,
                    LastName = friend.LastName,
                    BirthDate = friend.BirthDate,
                    Email = friend.Email,
                    Selected = false
                };
                SelectedFriendsViewModel.Friends.Add(editorViewModel);

            }

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Name,LastName,BirthDate,Email")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,BirthDate,Email")] Friend friend)
        {
            if (id != friend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendExists(friend.Id))
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
            return View(friend);
        }

        private bool FriendExists(int friendId)
        {
            return _context.Friends.Any(e => e.Id == friendId);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (_context.Friends == null)
            {
                return Problem("Entity set 'Tp1Context.Friends'  is null.");
            }
            var friend = await _context.Friends.FindAsync(id);
            if (friend != null)
            {
                _context.Friends.Remove(friend);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
