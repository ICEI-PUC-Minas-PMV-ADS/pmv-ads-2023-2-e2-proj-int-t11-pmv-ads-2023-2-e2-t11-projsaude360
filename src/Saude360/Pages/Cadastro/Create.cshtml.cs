using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Saude360.Data;
using Saude360.Models;

namespace Saude360.Pages.Cadastro
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Enums.Genero Generos { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostTesteAsync([FromBody] Models.Cadastro cadastro)
        {
            _context.Cadastros.Add(cadastro);
            _context.SaveChanges();

            return new OkObjectResult("Usuário criado com sucesso.");
        }

        //[BindProperty]
        //public Cadastro Cadastro { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //  if (!ModelState.IsValid || _context.Cadastros == null || Cadastro == null)
        //    {
        //        return Page();
        //    }

        //    _context.Cadastros.Add(Cadastro);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
