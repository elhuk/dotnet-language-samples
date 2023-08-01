using Types;

namespace ExamplesApp.Data.OptionalType;

public sealed record Person
{
    public Option<string> FirstName { get; }
    public Option<string> LastName { get; }

    public Person() { }
    private Person(string firstName, string lastName) =>
        (FirstName, LastName) = (
            firstName is null ? Option<string>.None() : Option<string>.Some(firstName),
            lastName is null ? Option<string>.None() : Option<string>.Some(lastName)
        );

    public static Person CreateNew(string firstName, string lastName) => new(firstName, lastName);

    public string GetFirstName => FirstName.Map(value => value).Reduce("");

    public string GetLastName => LastName.Map(value => value).Reduce("");

    public override string ToString() => FirstName.Map(fname => $"{fname} ").Reduce("") + LastName
            .Map(lname => $"{lname}")
            .Reduce("");
}