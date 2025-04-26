using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Phongtro> Phongtros { get; set; }

    public async Task OnGetAsync()
    {
        Phongtros = await _context.phongtros.OrderBy(s => s.Id).ToListAsync();
    }

    public int Id { get; set; }
    public string Ten { get; set; }

    public string SDT { get; set; }


     public async Task<IActionResult> OnPostSearchAsync(string thongtin){

        
        Ten = thongtin;
        SDT = thongtin;
          
           Phongtros = Phongtros = (IList<Phongtro>)await _context.phongtros
        .Where(lr => lr.SDT == SDT).ToListAsync();
        Console.WriteLine("Thong tin", Phongtros);
      
            Phongtros = Phongtros = (IList<Phongtro>)await _context.phongtros
        .Where(lr => lr.TenNguoiThue == Ten).ToListAsync();
        
        Console.WriteLine("Thong tin", Phongtros);
        
        return RedirectToPage();

     }



    public async Task<IActionResult> OnPostInsertAsync(string tennguoithue, string sdt, int hinhthucthanhtoan, string ghichu){

        DateTime localDateTime = DateTime.Now;  // Local DateTime
        DateTime utcDateTime = localDateTime.ToUniversalTime();  // Convert to UTC

        if (ghichu == null){
            ghichu = "...";
        }

        var result = new Phongtro {
            TenNguoiThue = tennguoithue, 
            SDT = sdt,
            id_hinh_thuc_thanh_toan = hinhthucthanhtoan,
            GhiChu = ghichu,
            NgayThue = utcDateTime,
        };

        _context.phongtros.Add(result);
        await _context.SaveChangesAsync();
        
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var result = await _context.phongtros.FindAsync(id);
        if (result == null) return NotFound();
        
        _context.phongtros.Remove(result);
        await _context.SaveChangesAsync();
        
        return RedirectToPage(); // reload lại trang
    }

}
