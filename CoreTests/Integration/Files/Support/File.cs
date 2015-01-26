namespace CoreTests.Integration.Files.Support
{
    public interface File
    {
        string Name { get; }
        string Path { get; }
        int ContentLength { get; }
    }
}