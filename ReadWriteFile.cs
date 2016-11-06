using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP
{
    class ReadWriteFile
    {

        public string Read(string name)
        {
            string line;
            StreamReader file = new StreamReader(name);
            line = file.ReadToEnd();
            file.Close();
            return line;
        }

        public void Write(string lines, string name)
        {
            StreamWriter file = new StreamWriter(name);
            file.Write(lines);
            file.Close();
        }

    }
}
