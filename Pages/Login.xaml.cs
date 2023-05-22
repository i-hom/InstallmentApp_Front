using InstallmentApp_Front.ViewModel;

namespace InstallmentApp_Front.Pages;

public partial class Login : ContentPage
{
	public Login(CabinetViewModel user)
	{
		InitializeComponent();

		BindingContext = user;
	}
}