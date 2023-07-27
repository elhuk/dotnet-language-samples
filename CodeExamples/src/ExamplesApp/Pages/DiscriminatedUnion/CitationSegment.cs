using Microsoft.AspNetCore.Rewrite;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ExamplesApp.Pages.DiscriminatedUnion;

// Discriminated Union implementation using records which is equivalent
// what F# language supports out of the box

///type CitationSegment =
/// | BookAuthorSegment of Name : string * AuthorId : Guid
/// | BookTitleSegment of Text : string * BookId : Guid
/// | TitleSegment of Title : string * BookId : Guid

public abstract record CitationSegment(string value);
public record BookAuthorSegment(string Name, Guid AuthorId) : CitationSegment(Name);
public record BookTitleSegment(string Text, Guid BookId) : CitationSegment(Text);
public record TitleSegment(string Title, Guid BookId) : CitationSegment(Title);

// Discriminated Union usage example
/*
    @foreach(CitationSegment segment in Model)
    {
        string style = "citation-" + @segment.GetType().Name.ToLower();
        switch (segment)
        {
            case BookTitleSegment title: 
                <a class="citation @style" href="/book/@title.BookId">@title.Text</a>
                break;
            case BookAuthorSegment author:
                <a class="citation @style" href="/books?authorId=@author.AuthorId">@author.Name</a>
                break;
            default: 
                <span class"citation @style">@segment.Text</span>
                break;
        }
    }
*/

// TODO: Build an implementation for Discriminated Union for the example below
/*
    public abstract record CommandOperationResult(T value);
    public record Ok(T Response) : CommandOperationResult(Response);
    public record NotFound() : CommandOperationResult();
    public record Failed(T Message) : CommandOperationResult(Message);

    return result.Match<IActionResult>(
        res => Ok(res.MapToResponse()),
        _   => NotFound(),
        failed => BadRequest(failed.MapToResponse()));
*/