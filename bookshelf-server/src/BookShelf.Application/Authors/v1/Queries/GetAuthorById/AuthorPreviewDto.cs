using System.Text.Json.Serialization;

namespace BookShelf.Application.Authors.v1.Queries.GetAuthorById;

public record AuthorPreviewDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public string DateOfBirth { get; set; }
    public string DateOfDeath { get; set; }
    public IEnumerable<string> NotableWorks { get; set; }

    [JsonConstructor]
    public AuthorPreviewDto()
    {

    }
}

