namespace GamesWebAPI;

public class SearchResult<T>(IResult? error, T? entity)
    where T : IEntity
{
    private IResult? Error { get; } = error;
    private T? Entity { get; } = entity;

    public IResult Finally(Func<T, IResult> onSuccess)
    {
        if (Error != null) return Error;
        
        return onSuccess(Entity!);
    }
}