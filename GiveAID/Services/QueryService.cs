using GiveAID.Data;
using GiveAID.Models;
using GiveAID.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiveAID.Services;

public class QueryService(GiveAidContext dbContext) : IQueryService
{
    public async Task<List<Query>> GetAllQueriesAsync(CancellationToken ct = default)
    {
        return await dbContext.Queries
            .Include(query => query.Member)
            .OrderByDescending(query => query.CreatedAt)
            .ToListAsync(ct);
    }

    public async Task<Query?> GetQueryByIdAsync(int queryId, CancellationToken ct = default)
    {
        return await dbContext.Queries
            .Include(query => query.Member)
            .FirstOrDefaultAsync(query => query.Id == queryId, ct);
    }

    public async Task<Query> CreateQueryAsync(Query query, CancellationToken ct = default)
    {
        query.IsResolved = false;
        query.CreatedAt = DateTime.UtcNow;

        dbContext.Queries.Add(query);
        await dbContext.SaveChangesAsync(ct);

        return query;
    }

    public async Task<Query?> MarkAsResolvedAsync(int queryId, string? replyText = null, CancellationToken ct = default)
    {
        var query = await dbContext.Queries.FirstOrDefaultAsync(item => item.Id == queryId, ct);
        if (query is null)
        {
            return null;
        }

        query.IsResolved = true;
        query.ReplyText = replyText;

        await dbContext.SaveChangesAsync(ct);
        return query;
    }
}