using ExamplesApp.Data.OptionalType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
