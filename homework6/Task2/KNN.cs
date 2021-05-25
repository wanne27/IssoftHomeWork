using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Task2
{
    class KNN
    {
        private int lines;
        private int K;

        private List<string> testSetName = new List<string>();
        private List<double[]> testSetValues = new List<double[]>();

        public void LoadData(string path)
        {
            StreamReader file = new StreamReader(path);
            string line;

            lines = 0;

            while ((line = file.ReadLine()) != null) 
            {
                string[] splitLine = line.Split(',').ToArray();

                List<string> lineItems = new List<string>(splitLine.Length);
                lineItems.AddRange(splitLine);

                double[] lineDoubles = new double[lineItems.Count - 1];
                string lineName = lineItems.ElementAt(0);

                for(int i = 1; i<lineItems.Count - 1; i++)
                {
                    double val = Double.Parse(lineItems.ElementAt(i), CultureInfo.InvariantCulture);
                    lineDoubles[i] = val;
                }

                testSetName.Add(lineName);
                testSetValues.Add(lineDoubles);

                lines++;
            }

            file.Close();
        }

        public string IdentifyName(int K, Data data)
        {
            this.K = K;

            double[][] distances = new double[testSetValues.Count][];

            for (int i = 0; i < testSetValues.Count; i++) 
                distances[i] = new double[2];

            Parallel.For(0, testSetValues.Count, index  =>
            {
                var dist = EuclideanDistance(testSetValues[index], data.Coordinate);
                distances[index][0] = dist;
                distances[index][1] = index;
            });

            var sortedDistances = distances.AsParallel().OrderBy(t => t[0]).Take(this.K);

            int grapefruitCounter = 0;
            int orangeCounter = 0;

            foreach (var item  in sortedDistances)
            {
                if (string.Equals("orange", testSetName[(int)item[1]]) == true)
                    orangeCounter++;
                else
                    grapefruitCounter++;
            }

            return orangeCounter > grapefruitCounter ? "orange" : "grapefruit";
        }

        private static double EuclideanDistance(double[] sampleOne, (double, double) sampleTwo)
        {
            double d = 0.0;

            double temp = sampleOne[0] - sampleTwo.Item1;
            double temp2 = sampleOne[1] - sampleTwo.Item2;
            d = temp * temp + temp2 * temp2;

            return Math.Sqrt(d);
        }
    }
}
