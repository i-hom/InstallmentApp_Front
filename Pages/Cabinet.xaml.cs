using InstallmentApp_Front.ViewModel;

namespace InstallmentApp_Front.Pages;

public partial class Cabinet : ContentPage
{
	public Cabinet(CabinetViewModel user)
	{
		InitializeComponent();

		BindingContext = user;
	}
}