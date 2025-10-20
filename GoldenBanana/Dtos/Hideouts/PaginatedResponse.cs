namespace GoldenBanana.Dtos.Hideouts;

public class PaginatedResponse<T>
{
    public int TotalCount { get; set; }
    public IEnumerable<T> Items { get; set; } = [];
}
