using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace tracert2csv {
    class Program {
        static void Main(string[] args) {

            bool started = false;
            string line;
            List<string> lines = new List<string>();
            List<Traceroute> traces = new List<Traceroute>();

            StreamReader file = new StreamReader(@"tracerts\test.txt");
            Regex regex = new Regex("^  1.*");

            while ((line = file.ReadLine()) != null) {

                if (line.Length == 0 && started) {
                    break;
                }
                else if (!started) {
                    if(regex.IsMatch(line)) {
                        started = true;
                        lines.Add(line);
                    }
                }
                else {
                    lines.Add(line);
                }
            }

            foreach(string l in lines) {
                Traceroute tr = new Traceroute(l);
                traces.Add(tr);
            }

            WriteOutput(traces, args[1]);

        }

        static void WriteOutput(ICollection<Traceroute> traces, string path) {

            using (StreamWriter swriter = new StreamWriter(path)) {

                foreach(Traceroute tr in traces) {
                    swriter.WriteLine(tr.ToCommaDelimitedString());
                }
                swriter.Flush();
            }
        }
    }
}
