
namespace Types;

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

public struct Option<T> : IEquatable<Option<T>> where T : class
{
    /// This property has the private knowledge of whether there
    /// is an object inside this Option or not.
    /// It keeps track of whether there is something in the box or
    /// there is nothing in the box
    private T? _content;

    /// This is the instance of the Option that contain a value
    public static Option<T> Some(T obj) => new() { _content = obj };

    /// This is the instance of the Option that does not contain any value
    public static Option<T> None() => new();

    /// The Map function checks if an object is missing or not
    /// if found returns the object otherwise it returns a empty container
    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class =>
        new() { _content = _content is not null ? map(_content) : null };
    public ValueOption<TResult> MapValue<TResult>(Func<T, TResult> map) where TResult : struct =>
        _content is not null ? ValueOption<TResult>.Some(map(_content)) : ValueOption<TResult>.None();

    public Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) where TResult : class =>
        _content is not null ? map(_content) : Option<TResult>.None();
    public ValueOption<TResult> MapOptionalValue<TResult>(Func<T, ValueOption<TResult>> map) where TResult : struct =>
        _content is not null ? map(_content) : ValueOption<TResult>.None();

    /// The Reduce function will return the contained object or the
    /// default supplied by the caller
    public T Reduce(T orElse) => _content ?? orElse;
    public T Reduce(Func<T> orElse) => _content ?? orElse();

    public Option<T> Where(Func<T, bool> predicate) =>
        _content is not null && predicate(_content) ? this : Option<T>.None();

    public Option<T> WhereNot(Func<T, bool> predicate) =>
        _content is not null && !predicate(_content) ? this : Option<T>.None();

    public override int GetHashCode() => _content?.GetHashCode() ?? 0;
    public override bool Equals(object? other) => other is Option<T> option && Equals(option);

    public bool Equals(Option<T> other) =>
        _content is null ? other._content is null
        : _content.Equals(other._content);

    public static bool operator ==(Option<T>? a, Option<T>? b) => a is null ? b is null : a.Equals(b);
    public static bool operator !=(Option<T>? a, Option<T>? b) => !(a == b);
}