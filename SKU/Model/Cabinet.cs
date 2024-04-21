using System.Drawing;

namespace SKU.Model
{
    // Define a root object that matches the structure of the JSON data
    public class RootObject
    {
        public List<Cabinet> Cabinets { get; set; }
    }
    public class Cabinet
    {
        public int Number { get; set; }
        public List<Row>? Rows { get; set; }
        public Position? Position { get; set; }
        public Size? Size { get; set; }
    }

    public class Row
    {
        public int Number { get; set; }
        public List<Lane>? Lanes { get; set; }
        public int PositionZ { get; set; }
        public Size? Size { get; set; }
    }

    public class Lane
    {
        public int Number { get; set; }
        public string? JanCode { get; set; }
        public int Quantity { get; set; }
        public int PositionX { get; set; }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public class Size
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }
    }
}
