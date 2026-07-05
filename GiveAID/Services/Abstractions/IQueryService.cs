using GiveAID.Models;

namespace GiveAID.Services.Abstractions;

public interface IQueryService
{
    public Task<List<Query>> GetAllQueriesAsync(CancellationToken ct = default);

    public Task<Query?> GetQueryByIdAsync(int queryId, CancellationToken ct = default);

    public Task<Query> CreateQueryAsync(Query query, CancellationToken ct = default);

    public Task<Query?> MarkAsResolvedAsync(int queryId, string? replyText = null, CancellationToken ct = default);
}