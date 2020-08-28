using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace tracert2csv {

    /// <summary>
    /// Traceroute model comprising of route components
    /// </summary>
    struct Traceroute {

        public int Index { get; private set; }

        public ICollection<int> TransitDelays { get; private set; }

        public double AverageDelay { get; private set; }

        public string Host { get; private set; }

        public bool IsTimedOut { get; private set; }

        public Traceroute(string line) {

            char[] l = line.ToCharArray();
            l[6] = ',';
            l[15] = ',';
            l[24] = ',';
            l[31] = ',';

            string[] pieces = new string(l).Split(',');

            Index = int.Parse(pieces[0].Trim());

            TransitDelays = new List<int>();
            AverageDelay = 0;
            for(int i = 1; i <= pieces.Length - 2; i++) {
                string p = pieces[i].Trim();
                int d = 0;

                if(!p.Contains("*")) {
                    d = int.Parse(Regex.Match(p, @"\d+").Value);
                }

                TransitDelays.Add(d);

                AverageDelay += d;
            }
            AverageDelay = AverageDelay / (pieces.Length - 2);

            Host = pieces[pieces.Length - 1].Trim();

            IsTimedOut = (line.Split('*').Length - 1) == 3;

        }

        public string ToCommaDelimitedString() {

            string compiled = Index.ToString() + ",";

            foreach(int td in TransitDelays) {
                compiled += td.ToString() + ",";
            }

            compiled += Host;
            return compiled;
        }


    }
}
