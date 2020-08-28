using System;
using System.Collections.Generic;
using System.Text;

namespace InspireCoders.Domain
{
    public class PermEntity
    {
        public PermEnums Permission { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Entity { get; set; }
    }
}
