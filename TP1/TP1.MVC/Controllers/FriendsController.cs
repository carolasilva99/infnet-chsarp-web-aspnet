using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using TP1.Data;
using TP1.Domain;
using TP1.MVC.Models;

namespace TP1.MVC.Controllers
{
    public class FriendsController : Controller
    {
        private const string CacheKey = "SelectedFriends";

        private readonly Tp1Context _context;
        public readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public FriendsController(Tp1Context context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public IActionResult Index()
        {
            var friends = GetFriendsFromDatabase();
            var selectedFriends =  new List<int>();

            var cacheExists = _cache.TryGetValue(CacheKey, out selectedFriends);
            
            foreach (var friend in friends)
            {
                if (cacheExists && selectedFriends.Contains(friend.Id))
                    friend.Selected = true;
            }

            return View(friends);
        }

        private IEnumerable<FriendViewModel> GetFriendsFromDatabase()
        {
            return _mapper.Map<IEnumerable<FriendViewModel>>(_context.Friends);
        }

        [HttpPost]
        public ActionResult SelectedFriends(List<int> selectedFriends)
        {
            if (selectedFriends.Any())
                AddFriendsToCache(selectedFriends);

            var friends = GetFriendsFromDatabase();

            foreach (var friend in friends)
            {
                if (selectedFriends.Contains(friend.Id))
                    friend.Selected = true;
            }

            return View(friends);
        }

        private void AddFriendsToCache(List<int> selectedFriends)
        {
            var _ = _cache.GetOrCreate(CacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                return selectedFriends;
            });
        
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
