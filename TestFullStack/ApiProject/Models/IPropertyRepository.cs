using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetProperties();
        Property AddProperty(Property property);
        Property DeleteProperty(int id);
    }
}
