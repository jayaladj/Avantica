using Microsoft.AspNetCore.Http;
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
    [Route("[controller]")]
    [ApiController]
    public class PropertyDBController : ControllerBase
    {
        private IPropertyRepository _propertyRepository;

        public PropertyDBController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpPost]
        public JsonResult Add(Property property)
        {
            Property prop = _propertyRepository.AddProperty(property);
            return new JsonResult(prop);
        }

        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Property> prop = _propertyRepository.GetProperties();
            return new JsonResult(prop);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete([FromRoute] int id)
        {
            Property property = _propertyRepository.DeleteProperty(id);
            return new JsonResult(property);
        }
    }
}
