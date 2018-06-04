using System.Collections.Generic;
using System.IO;

namespace BusinessLayer
{
    /// <summary>
    /// abstract class implementing the interface
    /// </summary>
    public abstract class AbstractWriter : IBussinessProcess
    {
        /// <summary>
        /// function for reading text file
        /// </summary>
        /// <param name="inputPath"></param>
        /// <returns></returns>
        public ReaderClass ReadWriteTextDataFiles(string inputPath)
        {
            ReaderClass readData = new ReaderClass();
            List<string> fileNames = new List<string>();
            List<string> codes = new List<string>();
            List<string> descriptions = new List<string>();
            FileInfo file;
            List<string> datas = new List<string>();

            string[] fileAry = Directory.GetFiles(inputPath, "*.txt");
            foreach (string filePath in fileAry)
            {
                file = new FileInfo(filePath);
                fileNames.Add(file.Name);
                using (TextReader tr = new StreamReader(filePath))
                {
                    string line;
                    string lineCode = "";
                    bool nextLine = true;
                    while ((line = tr.ReadLine()) != null)
                    {
                        nextLine = true;
                        if (line == "[Code]")
                        {
                            nextLine = false;
                            lineCode = "Code";
                        }
                        else if (line == "[Description]")
                        {
                            nextLine = false;
                            lineCode = "Desc";
                        }
                        else if (line == "[Data]")
                        {
                            nextLine = false;
                            lineCode = "Data";
                        }
                        if (nextLine)
                        {
                            if (lineCode == "Code")
                            {
                                codes.Add(line);
                            }
                            else if (lineCode == "Desc")
                            {
                                descriptions.Add(line);
                            }
                            else if (lineCode == "Data")
                            {
                                datas.Add(line);
                            }
                        }
                    }

                    tr.Close();
                    tr.Dispose();
                }
            }
            readData.FileNames = string.Join(",", fileNames);
            readData.Code = string.Join(",", codes);
            readData.FileDescription = string.Join(",", descriptions);
            readData.Datas = datas;
            return readData;
        }

        /// <summary>
        /// abstract method for writing text file in xml/html format
        /// </summary>
        /// <param name="content"></param>
        /// <param name="outPutPath"></param>
        public abstract void WriteToOutPutFile(ReaderClass content, string outputPath);        
    }
}
