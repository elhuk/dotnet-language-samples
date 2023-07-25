namespace Types;

public sealed record Book
{
    private Option<string> Title { get; } 
    private Option<Person> Author { get; }

    private Book(string title, Person author) =>
        (Title, Author) = (
            title is null ? Option<string>.None() : Option<string>.Some(title),
            author is null ? Option<Person>.None() : Option<Person>.Some(author)    
        );

    public static Book CreateNew(string title, Person author) =>
        new(title, author);

    public override string ToString() =>
        this.Title
            .Map(title => $"{title} by ")
            .Reduce("{   } by ") +
        this.Author
            .Map(author => $"{author}")
            .Reduce("{   }");

    public static IEnumerable<Book> BuildBookList()
    {
        return new Book[]
        {
            Book.CreateNew(
                title : "Patterns of Enterprise Application Architecture",
                author : Person.CreateNew(firstName : "Martin", lastName : "Fowler")),
            Book.CreateNew(
                title : "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
                author: Person.CreateNew(firstName: "Robert C.", lastName: "Martin")),
            Book.CreateNew(
                title : "The Art of Computer Programming",
                author : Person.CreateNew(firstName: "Donald", lastName: null!)),
            Book.CreateNew(
                title : "CODE: The Hidden Language of Computer Hardware and Software",
                author : Person.CreateNew(firstName: "Charles", lastName: null!)),
            Book.CreateNew(
                title : "Agile Software Development: Principles, Patterns, and Practices",
                author : Person.CreateNew(firstName: "Uncle Bob", lastName: null!)),
            Book.CreateNew(
                title : "Introduction to Algorithms",
                author : Person.CreateNew(firstName: "Thomas H.", lastName: "Cormen")),
            Book.CreateNew(
                title : "Head First Design Patterns: A Brain-Friendly Guide",
                author : Person.CreateNew(firstName: "Eric", lastName: "Freeman")),
            Book.CreateNew(
                title : "Cracking the Coding Interview: 189 Programming Questions and Solutions",
                author : Person.CreateNew(firstName: "Gayle L.", lastName: null!)),
            Book.CreateNew(
                title : "Don't Make Me Think: A Common Sense Approach to Web Usability",
                author : Person.CreateNew(firstName: "Steve", lastName: null!)),
            Book.CreateNew(
                title : "The Clean Coder: A Code of Conduct for Professional Programmers",
                author : Person.CreateNew(firstName: null!, lastName: null!)),
            Book.CreateNew(
                title : "Soft Skills: The Software Developer's Life Manual",
                author : Person.CreateNew(firstName: null!, lastName: null!)),
            Book.CreateNew(
                title : "Working Effectively with Legacy Code",
                author : null!),
            Book.CreateNew(
                title : "Design Patterns: Elements of Reusable Object-Oriented Software",
                author : null!),
            Book.CreateNew(
                title : "Code Complete: A Practical Handbook of Software Construction",
                author : null!),
            Book.CreateNew(
                title : "The Pragmatic Programmer: From Journeyman to Master",
                author : Person.CreateNew(firstName: "Andrew", lastName: "Andrew")),
            Book.CreateNew(
                title : "Clean Code: A Handbook of Agile Software Craftsmanship",
                author : Person.CreateNew(firstName: null!, lastName: null!)),
        };
    }
}