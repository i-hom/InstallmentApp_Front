using InstallmentApp_Front.ViewModel;

namespace InstallmentApp_Front.Pages;

public partial class Installment : ContentPage
{
	public Installment(CabinetViewModel user)
	{
		InitializeComponent();

		BindingContext = user;
	}
}