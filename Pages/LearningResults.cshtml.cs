using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Pages;

public class Hinhthucthanhtoan : PageModel
{
    private readonly AppDbContext _context;

    public Hinhthucthanhtoan(AppDbContext context){
        _context = context;
    }

    public IList<Hinhthucthanhtoan> Hinhthucthanhtoans { get; set; }

    public int Id { get; set; }
    public string Fullname { get; set; }

    public async Task OnGetAsync(int id, string fullname){
        Id = id; 
        Fullname = fullname;
        
        Hinhthucthanhtoans = Hinhthucthanhtoans = (IList<Hinhthucthanhtoan>)await _context.Hinhthucthanhtoans
        .Where(lr => lr.Id == id).ToListAsync();
    }

    public async Task<IActionResult> OnPostInsertAsync(int studentid, string fullnamestudent, string subjectname, string semester, int credits, decimal score){
        var grade = "";

        if(score >= 1 && score <= 4){
             grade = "D";
        } else if (score > 4 && score <= 6){
             grade = "C";
        } else if (score > 6 && score < 8){
             grade = "B";
        }else if (score > 8){
             grade = "A";
        } else {
            grade = "F";
        }

        DateTime localDateTime = DateTime.Now;  // Local DateTime
        DateTime utcDateTime = localDateTime.ToUniversalTime();  // Convert to UTC

        // var resultFinal = new Hinhthucthanhtoan
        // {
        //     StudentId = studentid,
        //     SubjectName = subjectname,
        //     Semester = semester,
        //     Credits = credits,
        //     Score = score,
        //     Grade = grade,
        //     CreatedAt = utcDateTime
        // };

        // _context.Hinhthucthanhtoans.Add(resultFinal);
        // await _context.SaveChangesAsync();

        return RedirectToPage("/Hinhthucthanhtoans", new { id = studentid, fullname = fullnamestudent});
    }

    // public async Task<IActionResult> OnPostEditAsync(int studentid, string fullnamestudent, int id, decimal score)
    // {
    //     var result = await _context.Hinhthucthanhtoans.FindAsync(id);
    //     if (result == null) return NotFound();

    //     if (result.Score != score){

    //         var grade = "";

    //         if(score >= 1 && score <= 4){
    //             grade = "D";
    //         } else if (score > 4 && score <= 6){
    //             grade = "C";
    //         } else if (score > 6 && score <= 8){
    //             grade = "B";
    //         }else if (score > 8){
    //             grade = "A";
    //         } else {
    //             grade = "F";
    //         }

    //         result.Score = score;
    //         result.Grade = grade;
    //         await _context.SaveChangesAsync();
    //     }

    //     return RedirectToPage("/Hinhthucthanhtoans", new { id = studentid, fullname = fullnamestudent});    

    // }

    public async Task<IActionResult> OnPostDeleteAsync(int studentid, string fullnamestudent, int id)
    {
        var Hinhthucthanhtoans = await _context.Hinhthucthanhtoans.FindAsync(id);
        if (Hinhthucthanhtoans == null) return NotFound();
        
        _context.Hinhthucthanhtoans.Remove(Hinhthucthanhtoans);
        await _context.SaveChangesAsync();
        
        return RedirectToPage("/Hinhthucthanhtoans", new { id = studentid, fullname = fullnamestudent});
    }


}