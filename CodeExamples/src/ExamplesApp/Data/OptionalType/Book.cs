using Types;

namespace ExamplesApp.Data.OptionalType;

public sealed record Book
{
    public Option<string> Title { get; }
    public Option<Person> Author { get; }

    private Book(string title, Person author) =>
        (Title, Author) = (
            title is null ? Option<string>.None() : Option<string>.Some(title),
            author is null ? Option<Person>.None() : Option<Person>.Some(author)
        );

    public static Book CreateNew(string title, Person author) => new(title, author);

    public string GetBookTitle() => Title.Map(value => value).Reduce("");

    public string GetAuthorFirstName() => Author.Map(value => value).Reduce(new Person()).GetFirstName;

    public string GetAuthorLastName() => Author.Map(value => value).Reduce(new Person()).GetLastName;

    public override string ToString() => Title.Map(title => $"{title} by ").Reduce("") + Author
        .Map(author => $"{author}")
        .Reduce("");

    public static IEnumerable<Book> BuildBookList()
    {
        return new Book[]
        {
            CreateNew(
                title : "Patterns of Enterprise Application Architecture",
                author : Person.CreateNew(firstName : "Martin", lastName : "Fowler")),
            CreateNew(
                title : "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
                author: Person.CreateNew(firstName: "Robert C.", lastName: "Martin")),
            CreateNew(
                title : "The Art of Computer Programming",
                author : Person.CreateNew(firstName: "Donald", lastName: null!)),
            CreateNew(
                title : "CODE: The Hidden Language of Computer Hardware and Software",
                author : Person.CreateNew(firstName: "Charles", lastName: null!)),
            CreateNew(
                title : "Agile Software Development: Principles, Patterns, and Practices",
                author : Person.CreateNew(firstName: "Uncle Bob", lastName: null!)),
            CreateNew(
                title : "Introduction to Algorithms",
                author : Person.CreateNew(firstName: "Thomas H.", lastName: "Cormen")),
            CreateNew(
                title : "Head First Design Patterns: A Brain-Friendly Guide",
                author : Person.CreateNew(firstName: "Eric", lastName: "Freeman")),
            CreateNew(
                title : "Cracking the Coding Interview: 189 Programming Questions and Solutions",
                author : Person.CreateNew(firstName: "Gayle L.", lastName: null!)),
            CreateNew(
                title : "Don't Make Me Think: A Common Sense Approach to Web Usability",
                author : Person.CreateNew(firstName: "Steve", lastName: null!)),
            CreateNew(
                title : "The Clean Coder: A Code of Conduct for Professional Programmers",
                author : Person.CreateNew(firstName: null!, lastName: null!)),
            CreateNew(
                title : "Soft Skills: The Software Developer's Life Manual",
                author : Person.CreateNew(firstName: null!, lastName: null!)),
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
                author : Person.CreateNew(firstName: "Andrew", lastName: "Hunt")),
            CreateNew(
                title : "Clean Code: A Handbook of Agile Software Craftsmanship",
                author : Person.CreateNew(firstName: null!, lastName: null!)),
        };
    }
}