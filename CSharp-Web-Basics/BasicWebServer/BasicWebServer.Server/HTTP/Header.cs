using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; init; }

        public string Value { get; set; }
    }
}
