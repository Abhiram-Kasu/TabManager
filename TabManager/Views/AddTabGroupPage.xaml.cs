using TabManager.ViewModels;

namespace TabManager.Views;

public partial class AddTabGroupPage : ContentPage
{
	private readonly AddTabGroupViewModel _viewModel;
	public AddTabGroupPage(AddTabGroupViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
		_viewModel = viewModel;
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var button  = sender as Button;
		_viewModel.RemoveLink(Guid.Parse(button.AutomationId));
		
	}

	private void Entry_Completed(object sender, EventArgs e)
	{
		_viewModel.Update();
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        string name = await DisplayPromptAsync("Link Name:", "Enter the name of your link here");
		if(name is not null)
		{
            string link = await DisplayPromptAsync("Link:", "Enter link address here");
            _viewModel.AddTab((name, link));
        }
		
		

    }

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		var label = sender as Label;
		await Launcher.OpenAsync(label.Text);
	}
}