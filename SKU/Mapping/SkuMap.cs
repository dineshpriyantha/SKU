using CsvHelper.Configuration;
using SKU.Model;

namespace SKU.Mapping
{
    public class SkuMap : ClassMap<Sku>
    {
        public SkuMap()
        {
            Map(m => m.JanCode).Name("JanCode");
            Map(m => m.Name).Name("Name");
            Map(m => m.X).Name("X");
            Map(m => m.Y).Name("Y");
            Map(m => m.Z).Name("Z");
            Map(m => m.ImageURL).Name("ImageURL");
            //Map(m => m.Width).ConvertUsing(row => ConvertDimension(row.GetField("Size"), "Width"));
            //Map(m => m.Depth).ConvertUsing(row => ConvertDimension(row.GetField("Size"), "Depth"));
            //Map(m => m.Height).ConvertUsing(row => ConvertDimension(row.GetField("Size"), "Height"));
            Map(m => m.TimeStamp).Name("TimeStamp");
            Map(m => m.Shape).Name("Shape");
            //Map(m => m.Width).ConvertUsing(row => SomeConversionLogic(row));
        }

        private int ConvertDimension(string size, string dimension)
        {
            // Implement your custom logic to extract the dimension from the "Size" field
            // and convert it to an integer value.
            // This example assumes the "Size" field is formatted as "Width:Depth:Height".
            var dimensions = size.Split(':');
            switch (dimension)
            {
                case "Width":
                    return int.Parse(dimensions[0]);
                case "Depth":
                    return int.Parse(dimensions[1]);
                case "Height":
                    return int.Parse(dimensions[2]);
                default:
                    return 0; // Or handle the error as needed
            }
        }
    }

}
