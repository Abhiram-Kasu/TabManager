using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabManager.Models
{
    public class Tab
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Link { get; set; }

        public bool AlwaysOpen { get; set; }

    }
}
