using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Models
{
    public class Role
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Role(string name)
        {
            Name = name;
        }
    }
}
