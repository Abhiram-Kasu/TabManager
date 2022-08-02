using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabManager.Models
{
    public class TabGroup
    {
        public string Name { get; set; }
        public ObservableCollection<Tab> Tabs { get; set; } = new();
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}
