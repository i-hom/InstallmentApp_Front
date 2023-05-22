using InstallmentApp_Front.ViewModel;

namespace InstallmentApp_Front.Pages;

public partial class CardAdd : ContentPage
{
	public CardAdd(CabinetViewModel user)
	{
		InitializeComponent();

		BindingContext = user;
	}
}