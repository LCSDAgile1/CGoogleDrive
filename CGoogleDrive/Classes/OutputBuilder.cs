using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGoogleDrive
{
    public class OutputBuilder : IDisposable
    {
        private readonly object _lock = new object();
        private FileStream _fileStream;
        private StreamWriter _streamWriter;

        public OutputBuilder(string outputflatPath)
        {
            string path = string.Empty;
            if (outputflatPath != string.Empty && outputflatPath != null)
            {
                path = System.IO.Path.Combine(outputflatPath, "output.csv");
            }
            else
            {
                path = "output.csv";
            }
            _fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            _streamWriter = new StreamWriter(_fileStream) { AutoFlush = true };
        }

        public void Write(string logLine)
        {
            lock (_lock)
            {
                _streamWriter.WriteLine(logLine);
            }
        }

        public void Dispose()
        {
            _streamWriter.Dispose(); _fileStream.Dispose();
        }
    }   
}
