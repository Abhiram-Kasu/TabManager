using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabManager.Models;
using TabManager.Views;

namespace TabManager.ViewModels
{
    [QueryProperty(nameof(TabGroupCache), "TabGroup")]
    public partial class MainPageViewModel:ObservableObject
    {

        public ObservableCollection<TabGroup> TabGroups { get; set; } = new();

        public TabGroup TabGroupCache { set {
                if(value is not null)
                    TabGroups.Add(value);
            }}

        [ICommand]
        public async void AddTabGroup()
        {
            await Shell.Current.GoToAsync(nameof(AddTabGroupPage));
        }

    }
}
