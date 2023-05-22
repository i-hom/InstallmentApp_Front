using InstallmentApp_Front.Model;
using InstallmentApp_Front.ViewModel;

namespace InstallmentApp_Front.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();

		BindingContext = detailsViewModel;

        Cards.Scrolled += (object sender, ItemsViewScrolledEventArgs e) => 
        {
            int firstVisibleItemIndex = e.FirstVisibleItemIndex;

            if (firstVisibleItemIndex >= 0)
            {
               detailsViewModel.Selectedcard = Cards.ItemsSource.Cast<Card>().ElementAt(firstVisibleItemIndex);
            }
        };
	}
}