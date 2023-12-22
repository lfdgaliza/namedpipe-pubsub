using Api.Http.HttpResults;

namespace Api.HttpResults
{
    public static class CustomTypedResultsCache
    {
        public static TeaPot TeaPot { get; } = new();
    }

    public static class CustomTypedResults
    {
        public static TeaPot TeaPot() => CustomTypedResultsCache.TeaPot;
    }
}
