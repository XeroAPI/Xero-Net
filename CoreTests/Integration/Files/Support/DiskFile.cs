using System.IO;

namespace CoreTests.Integration.Files.Support
{
    public class DiskFile : File
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public int ContentLength { get; private set; }

        public DiskFile(string name)
            : this(name, name)
        { }

        public DiskFile(string name, string path)
        {
            Name = name;
            Path = string.Format("resources\\images\\{0}", path);
            ContentLength = (int)new FileInfo(Path).Length;
        }
    }
}