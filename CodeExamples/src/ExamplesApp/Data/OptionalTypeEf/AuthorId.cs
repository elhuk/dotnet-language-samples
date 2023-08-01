namespace ExamplesApp.Data.OptionalTypeEf;

public sealed record AuthorId
{
    public Guid Value { get; set; }

    public AuthorId(Guid value)
    {
        Value = value;
    }

    public static implicit operator AuthorId(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
