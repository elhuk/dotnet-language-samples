using Types;

namespace ExamplesApp.Data.OptionalTypeEf;

public class Book
{
    public BookId BookId { get; }
    public Option<string> Title { get; }
    public Option<Author> Author { get; }

    private Book(string title, Author author) =>
        (Title, Author, BookId) = (
            title is null ? Option<string>.None() : Option<string>.Some(title),
            author is null ? Option<Author>.None() : Option<Author>.Some(author),
            Guid.NewGuid()
        );

    public static Book CreateNew(string title, Author author) => new(title, author);

    public string GetBookTitle() => Title.Map(value => value).Reduce("");

    public string GetAuthorFirstName() => Author.Map(value => value).Reduce(new Author()).GetFirstName;

    public string GetAuthorLastName() => Author.Map(value => value).Reduce(new Author()).GetLastName;

    public override string ToString() => Title.Map(title => $"{title} by ").Reduce("") + Author
        .Map(author => $"{author}")
        .Reduce("");
}
