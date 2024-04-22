using SKU.Model;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using SKU.Mapping;

namespace SKU.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ShelfApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetCabinets")]
        // Action method to get cabinet data
        public ActionResult GetCabinets()
        {
            // Read JSON data
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), 
                                               _configuration.GetSection("AppSettings")["App_Data"], 
                                               _configuration.GetSection("AppSettings")["jsonFile"]);
            var cabinets = ReadCabinetData(jsonFilePath);

            // Read CSV data
            string csvFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                                              _configuration.GetSection("AppSettings")["App_Data"], 
                                              _configuration.GetSection("AppSettings")["csvFile"]);
            var skus = ReadSkuData(csvFilePath);

            // Match SKUs with lanes in each cabinet
            List<LaneWithSkuViewModel> skuViewmodel = MatchSkusWithLanes(cabinets, skus);

            // Return cabinets as JSON
            return new JsonResult(cabinets);
        }

        private List<Cabinet> ReadCabinetData(string jsonFilePath)
        {
            List<Cabinet> cabinets = new List<Cabinet>();
            try
            {
                // Read JSON data from the file
                using (StreamReader streamReader = new StreamReader(jsonFilePath))
                {
                    string jsonData = streamReader.ReadToEnd();

                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        // Deserialize JSON data to a root object
                        var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);

                        // Check if the deserialized object is not null
                        if (rootObject != null && rootObject.Cabinets != null)
                        {
                            // Add cabinets from the root object to the list
                            cabinets.AddRange(rootObject.Cabinets);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found, JSON parsing error)
                // Log the error, return an empty list, or throw an exception as needed
            }
            return cabinets;
        }

        private List<Sku> ReadSkuData(string csvFilePath)
        {
            List<Sku> skus = new List<Sku>();
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Context.RegisterClassMap<SkuMap>();
                    skus = csv.GetRecords<Sku>().ToList();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found, CSV parsing error)
                // Log the error, return an empty list, or throw an exception as needed
            }
            return skus;
        }

        private List<LaneWithSkuViewModel> MatchSkusWithLanes(List<Cabinet> cabinets, List<Sku> skus)
        {
            List<LaneWithSkuViewModel> lanesWithSkus = new List<LaneWithSkuViewModel>();

            foreach (var cabinet in cabinets)
            {
                foreach (var row in cabinet.Rows)
                {
                    foreach (var lane in row.Lanes)
                    {
                        // Find the corresponding SKU based on the JanCode
                        var matchingSku = skus.FirstOrDefault(sku => sku.JanCode == lane.JanCode);

                        if (matchingSku != null)
                        {
                            // Create a new LaneWithSkuViewModel and populate its properties
                            var laneWithSku = new LaneWithSkuViewModel
                            {
                                CabinetNumber = cabinet.Number,
                                RowNumber = row.Number,
                                PositionZ = row.PositionZ,
                                LaneNumber = lane.Number,
                                JanCode = lane.JanCode,
                                Quantity = lane.Quantity,
                                PositionX = lane.PositionX,
                                Name = matchingSku.Name,
                                X = matchingSku.X,
                                Y = matchingSku.Y,
                                Z = matchingSku.Z,
                                ImageURL = matchingSku.ImageURL
                            };

                            // Add the LaneWithSkuViewModel to the list
                            lanesWithSkus.Add(laneWithSku);
                        }
                        else
                        {
                            // Handle the case where no matching SKU is found
                            // You can log a message or handle it as needed
                        }
                    }
                }
            }

            return lanesWithSkus;
        }
    }
}