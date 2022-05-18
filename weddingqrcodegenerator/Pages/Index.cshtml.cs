using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using weddingqrcodegenerator.Models;

namespace weddingqrcodegenerator.Pages;

public class IndexModel : PageModel
{
    public string InputText { get; set; } = "";
    public string QRcodeString { get; set; } = "";
    private readonly Data.GuestDbContext _context;
    private readonly ILogger<IndexModel> _logger;
    [BindProperty]
    public Guest? Guest { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        // if (!ModelState.IsValid)
        // {
        //     return Page();
        // }
        GenerateQRCode();
        if (Guest != null) _context.Guest.Add(Guest);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
    public void GenerateQRCode()
    {
        QRcodeString = "";
        InputText = "you are good to go";
        if (!string.IsNullOrEmpty(InputText))
        {
            using (MemoryStream ms = new())
            {
                QRCodeGenerator gen = new();
                QRCodeData qrData = gen.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new(qrData);
                using (Bitmap map = qrcode.GetGraphic(20))
                {
                    map.Save(ms, ImageFormat.Png);
                    QRcodeString = "data:image/png,base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
