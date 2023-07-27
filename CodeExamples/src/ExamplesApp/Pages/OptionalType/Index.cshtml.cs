using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Types;

namespace ExamplesApp.Pages.OptionalType
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> Books = Enumerable.Empty<Book>();

        public void OnGet()
        {
            Books = Book.BuildBookList();
        }
    }
}
