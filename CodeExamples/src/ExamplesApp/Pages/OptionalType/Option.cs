namespace ExamplesApp.Pages.OptionalType;

/// <summary>
/// This class is a way to fix the nullable reference type limitations 
/// that c# has and also not to mention the urgly syntax that need to 
/// write repeatedly all over the code using null-condition-operator(?),
/// null-coalescing-operator(??) and express-condition
/// <example>
/// <code>
/// var lastNameLength = book?.Author?.LastName?.Length ?? -1;
///
/// string? BookLabel(Person? person) =>
///     person is null ? null
///     : person.LastName is null ? person.FirstName
///     : $"{person.FirstName} {person.LastName}";
/// 
/// string GetBookLabel(Book book) =>
///     BookLabel(book.Author) is string author ? $"{book.Title} by {author}"
///     : book.Title;
/// </code>                 
/// </example>
/// The class defines an optional Monad type that is responsible 
/// for wrapping an object inside the Option<T>. 
/// <example>
/// <code>
/// The BookLabel expression will alway return a non-null string
/// If you forget that the object might be missing, the code will not compile
/// This code will not be syntactically correct and semantically incorrect
/// 
/// string BookLabel(Person person) => person
///     .LastName                                           // optional string
///     .Map(lastName => $"{person.FirstName} {lastName}")  // return this string if lastname is not null
///     .Reduce(person.FirstName)                           // return firstname if lastname does not exists
/// 
/// string GetBookLabel(Book book) => book
///     .Author
///     .Map(BookLabel)                                     // if Author exists it is passed to BookLabel function
///     .Map(author => $"{book.Title} by {author}")         // returned if Author has a name 
///     .Reduce(book.Title);                                // returned if Author does not exists
/// </code>
/// </example>
/// </summary>
public class Option<T> where T : class
{
    /// This property has the private knowledge of whether there
    /// is an object inside this Option or not.
    /// It keeps track of whether there is something in the box or
    /// there is nothing in the box
    private T? _object = null;

    /// This is the instance of the Option that contain a value
    public static Option<T> Some(T obj) => new() {_object = obj };

    /// This is the instance of the Option that does not contain
    public static Option<T> None() => new();

    /// The Map function checks if an object is missing or not
    /// if found returns the object otherwise it returns a empty container
    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class =>
        _object is null ? Option<TResult>.None() : Option<TResult>.Some(map(_object));

    /// The Reduce function will return the contained object or the
    /// default supplied by the caller
    public T Reduce(T @default) => _object ?? @default;
}