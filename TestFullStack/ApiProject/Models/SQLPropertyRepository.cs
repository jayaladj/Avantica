using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public class SQLPropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext context;
        public SQLPropertyRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Property AddProperty(Property property)
        {
            context.Properties.Add(property);
            context.SaveChanges();
            return property;
        }

        public IEnumerable<Property> GetProperties()
        {
            return context.Properties;
        }

        public Property DeleteProperty(int id)
        {
            Property property = context.Properties.Find(id);
            if (property != null)
            {
                context.Remove(property);
                context.SaveChanges();
            }
            
            return property;
        }
    }
}
