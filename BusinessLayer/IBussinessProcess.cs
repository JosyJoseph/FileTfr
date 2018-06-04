namespace BusinessLayer
{
    /// <summary>
    /// interface for reading and writing functionality
    /// </summary>
    public interface IBussinessProcess
    {
        ReaderClass ReadWriteTextDataFiles(string inputPath);

        void WriteToOutPutFile(ReaderClass content, string outputPath);
    }
}
