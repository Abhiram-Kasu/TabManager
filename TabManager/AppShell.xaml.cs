using TabManager.Views;

namespace TabManager;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddTabGroupPage), typeof(AddTabGroupPage));
	}
}
