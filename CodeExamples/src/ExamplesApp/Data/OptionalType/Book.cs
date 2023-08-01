using Types;

namespace ExamplesApp.Data.OptionalType;

public sealed record Book
{
    public Option<string> Title { get; }
    public Option<Author> Author { get; }

    private Book(string title, Author author) =>
        (Title, Author) = (
            title is null ? Option<string>.None() : Option<string>.Some(title),
            author is null ? Option<Author>.None() : Option<Author>.Some(author)
        );

    public static Book CreateNew(string title, Author author) => new(title, author);

    public string GetBookTitle() => Title.Map(value => value).Reduce("");

    public string GetAuthorFirstName() => Author.Map(value => value).Reduce(new Author()).GetFirstName;

    public string GetAuthorLastName() => Author.Map(value => value).Reduce(new Author()).GetLastName;

    public override string ToString() => Title.Map(title => $"{title} by ").Reduce("") + Author
        .Map(author => $"{author}")
        .Reduce("");

    public static IEnumerable<Book> BuildBookList()
    {
        return new Book[]
        {
            CreateNew(
                title : "Patterns of Enterprise Application Architecture",
                author : OptionalType.Author.CreateNew(firstName : "Martin", lastName : "Fowler")),
            CreateNew(
                title : "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
                author: OptionalType.Author.CreateNew(firstName: "Robert C.", lastName: "Martin")),
            CreateNew(
                title : "The Art of Computer Programming",
                author : OptionalType.Author.CreateNew(firstName: "Donald", lastName: null!)),
            CreateNew(
                title : "CODE: The Hidden Language of Computer Hardware and Software",
                author : OptionalType.Author.CreateNew(firstName: "Charles", lastName: null!)),
            CreateNew(
                title : "Agile Software Development: Principles, Patterns, and Practices",
                author : OptionalType.Author.CreateNew(firstName: "Uncle Bob", lastName: null!)),
            CreateNew(
                title : "Introduction to Algorithms",
                author : OptionalType.Author.CreateNew(firstName: "Thomas H.", lastName: "Cormen")),
            CreateNew(
                title : "Head First Design Patterns: A Brain-Friendly Guide",
                author : OptionalType.Author.CreateNew(firstName: "Eric", lastName: "Freeman")),
            CreateNew(
                title : "Cracking the Coding Interview: 189 Programming Questions and Solutions",
                author : OptionalType.Author.CreateNew(firstName: "Gayle L.", lastName: null!)),
            CreateNew(
                title : "Don't Make Me Think: A Common Sense Approach to Web Usability",
                author : OptionalType.Author.CreateNew(firstName: "Steve", lastName: null!)),
            CreateNew(
                title : "The Clean Coder: A Code of Conduct for Professional Programmers",
                author : OptionalType.Author.CreateNew(firstName: null!, lastName: null!)),
            CreateNew(
                title : "Soft Skills: The Software Developer's Life Manual",
                author : OptionalType.Author.CreateNew(firstName: null!, lastName: null!)),
            CreateNew(
                title : "Working Effectively with Legacy Code",
                author : null!),
            CreateNew(
                title : "Design Patterns: Elements of Reusable Object-Oriented Software",
                author : null!),
            CreateNew(
                title : "Code Complete: A Practical Handbook of Software Construction",
                author : null!),
            CreateNew(
                title : "The Pragmatic Programmer: From Journeyman to Master",
                author : OptionalType.Author.CreateNew(firstName: "Andrew", lastName: "Hunt")),
            CreateNew(
                title : "Clean Code: A Handbook of Agile Software Craftsmanship",
                author : OptionalType.Author.CreateNew(firstName: null!, lastName: null!)),
        };
    }
}