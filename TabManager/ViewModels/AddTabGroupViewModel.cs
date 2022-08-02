using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabManager.Models;
using TabManager.Views;

namespace TabManager.ViewModels
{
    public partial class AddTabGroupViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _errorText = "All Fields are not filled";

        [ObservableProperty]
        private string _name;
        public ObservableCollection<Models.Tab> Tabs { get; set; } = new()
        {
            new Models.Tab()
            {
                Name = "Test",
                Link = @"https://docs.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups",
                AlwaysOpen = false
            }
        };

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotValid))]
        private bool _isValid;

        public bool IsNotValid => !IsValid;

        [ICommand]
        public async Task OpenLink(string link) => await Launcher.OpenAsync(link);

        [ICommand]
        public void AddTab((string, string) namelink)
        {
            if (namelink.Item1 is not null && Uri.TryCreate(namelink.Item2, UriKind.Absolute, out var uri))
            {
                Tabs.Add(new Models.Tab
                {
                    Name = namelink.Item1,
                    Link = uri.ToString(),
                    AlwaysOpen = false
                });
            }
            else
            {
                IsValid = false;
                ErrorText = "Name or link was not valid";
            }
        }


        [ICommand]
        public void RemoveLink(Guid id)
        {
            Tabs.Remove(Tabs.Where(x => x.Id.Equals(id)).First());
        }

        [ICommand]
        public void Update()
        {
            
            var invalidLinks = Tabs.Where(x => !Uri.TryCreate(x.Link, UriKind.Absolute, out var _) || x.Name is null);
            if (Name is null || Name == string.Empty)
            {
                ErrorText = "Name cannot be empty";
                IsValid = false;
                
            }
            
            else if (invalidLinks.Any())
            {
                ErrorText = $"Tabs with links: {string.Join(", ", invalidLinks.Select(x => x.Link).ToList())} are invalid or dont have a name";
                IsValid = false;
                
            }
            else
            {
                IsValid = true;
            }
        }

        [ICommand]
        public async Task Save()
        {
            await Shell.Current.GoToAsync("..", new Dictionary<string, object>()
            {
                ["TabGroup"] = new TabGroup()
                {
                    Name = Name,
                    Tabs = Tabs
                },
               
            });
        }

    }
}
