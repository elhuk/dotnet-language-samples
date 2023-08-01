namespace ExamplesApp.Data.OptionalTypeEf;

public sealed record BookId
{
    public Guid Value { get; set; }

    public BookId(Guid value)
    {
        Value = value;
    }

    public static implicit operator BookId(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
