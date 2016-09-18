using System;
using System.IO;

namespace PokeGo.Api.CSV
{
    public interface ICsvReader
    {
        void ReadLinesFrom(string filename, Action<string[]> forEachReadLine);
    }

    public class CsvReader : ICsvReader
    {
        public void ReadLinesFrom(string filename, Action<string[]> forEachReadLine)
        {
            using (var reader = new StreamReader(filename))
            {
                string stringLine;
                while ((stringLine = reader.ReadLine()) != null)
                    forEachReadLine(stringLine.Split(';'));                
            }
        }
    }
}
