using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using PropertyManagementAPI.Models;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : Controller
    {
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            List<Property> properties = new List<Property>();
            Property property;
            var url = "https://samplerspubcontent.blob.core.windows.net/public/properties.json";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        //get the json result
                        var result = await content.ReadAsStringAsync();
                        var jsonObject = (JObject)JsonConvert.DeserializeObject(result);
                        var items = jsonObject.SelectToken("properties").Children().OfType<JObject>();
                        foreach (var item in items)
                        {
                            property = new Property();
                            foreach (JProperty p in item.Properties())
                            {
                                //Retrieve the address
                                if (p.Name == "address" && p.Value.HasValues)
                                {
                                    // Retrieve Address
                                    var address = p.Value.ToObject<JObject>();
                                    foreach (JProperty jp in address.Properties())
                                        if (jp.Name.Equals("address1"))
                                            property.Address = jp.Value.ToString();
                                }
                                if (p.Name == "financial" && p.Value.HasValues)
                                {
                                    // Retrieve List Price
                                    // Retrieve Monthly Rent
                                    var financial = p.Value.ToObject<JObject>();
                                    foreach (JProperty jp in financial.Properties())
                                        if (jp.Name.Equals("listPrice"))
                                            property.ListPrice = Decimal.Parse(jp.Value.ToString());
                                        else if (jp.Name.Equals("monthlyRent"))
                                            property.MonthlyRent = Decimal.Parse(jp.Value.ToString());

                                }
                                if (p.Name == "physical" && p.Value.HasValues)
                                {
                                    // Retrieve Year Built
                                    var physical = p.Value.ToObject<JObject>();
                                    foreach (JProperty jp in physical.Properties())
                                        if (jp.Name.Equals("yearBuilt"))
                                            property.YearBuilt = Int32.Parse(jp.Value.ToString());
                                }
                            }
                            property.GrossYield = property.ListPrice > 0 && property.MonthlyRent > 0 ?
                                            property.MonthlyRent * 12 / property.ListPrice : 0;
                            properties.Add(property);
                        }
                        
                        return new JsonResult(properties);
                    }
                }
            }
        }
    }
}
