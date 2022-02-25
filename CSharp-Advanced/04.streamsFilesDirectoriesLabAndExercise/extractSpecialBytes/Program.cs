namespace extractSpecialBytes
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractBytes.ExtractBytes.ExtractBytesFromBinaryFile("example.png", "bytes.txt", "../../../output.bin");
        }
    }
}
