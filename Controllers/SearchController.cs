
using BizSecureDemo22180035.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
namespace BizSecureDemo.Controllers;
[Authorize]
public class SearchController : Controller
{
    private readonly AppDbContext _db;
    public SearchController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return View();
    }
    //[HttpPost]
    //public async Task<IActionResult> Results(string keyword)
    //{
    //    var sql = $"SELECT * FROM Orders WHERE Title LIKE '%{keyword}%'";
    //    var results = await _db.Orders
    //      .FromSqlRaw(sql)
    //      .ToListAsync();
    //    return View(results);
    //}
    [HttpPost]
    public async Task<IActionResult> Results(string keyword)
    {
        var sql = "SELECT * FROM Orders WHERE Title LIKE @keyword";
        var param = new SqlParameter("@keyword", $"%{keyword}%");
        var results = await _db.Orders
        .FromSqlRaw(sql, param)
        .ToListAsync();
        return View(results);
    }
}
