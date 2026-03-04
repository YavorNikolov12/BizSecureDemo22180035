using BizSecureDemo22180035.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BizSecureDemo22180035.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly AppDbContext _db;
    public HomeController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); //����� ID-�� �� �������� ����������

        var myOrders = await _db.Orders
            .Where(o => o.UserId == uid)
            .OrderByDescending(o => o.Id)
            .ToListAsync(); // ���� ��������� �� ������ ������ �������� ����������

        var allOrders = await _db.Orders
            .OrderByDescending(o => o.Id)
            .ToListAsync(); // ���� ������ ������� �� ������

        ViewBag.AllOrders = allOrders; //������ ������ ������� ��� View-�� ���� ViewBag. ViewBag � ������ �� ������������ ����� ��� View-��. ���� View-�� ���� �� ������� � �������� ������ �� �������.
        return View(myOrders);
    }

}

