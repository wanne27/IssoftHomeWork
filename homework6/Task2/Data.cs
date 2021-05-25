namespace Task2
{
    class Data
    {
        private string name;
        private (double, double) coordinate;

        public string Name { get => name; set { name = value; } }

        public (double, double) Coordinate { get => coordinate; set { coordinate = value; } }

        public Data(string name, (double, double) coordinate)
        {
            Name = name;
            Coordinate = coordinate;
        }

        public Data((double, double) coordinate)
        {
            Coordinate = coordinate;
        }
    }
}
