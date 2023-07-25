using System.Runtime.CompilerServices;

namespace Types;

public sealed record Person 
{
    public Option<string> FirstName { get; }
    public Option<string> LastName { get; }

    private Person(string firstName, string lastName) =>
        (FirstName, LastName) = (
            firstName is null ? Option<string>.None() : Option<string>.Some(firstName), 
            lastName is null ?  Option<string>.None() : Option<string>.Some(lastName)
        );

    public static Person CreateNew(string firstName, string lastName) => 
        new(firstName, lastName);

    public override string ToString() =>
        this.FirstName
            .Map(fname => $"{fname} ")
            .Reduce("{   } ") +
        this.LastName
            .Map(lname => $"{lname}")
            .Reduce("{   }");
}
