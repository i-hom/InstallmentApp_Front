using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InstallmentApp_Front.Model;

namespace InstallmentApp_Front.ViewModel;


[QueryProperty(nameof(Details), "Details")]

public partial class DetailsViewModel : BaseViewModel
{
    Services.Installment_Service service = new();

    [ObservableProperty]
    Details details;

    [ObservableProperty]
    public Card selectedcard;

    [ObservableProperty]
    UInt32 amount;

    [RelayCommand]
    async Task Pay(DetailsViewModel details)
    {
        if (Amount <= 0 || Amount > Selectedcard.Balance)
            await Shell.Current.DisplayAlert("Error", "Entered invalid amount of payment", "OK");
        else
        {
            Response response = await service.Request<Response>($"{{\"method\": \"installment.pay\",\"params\": {{\"installment_id\": \"{Details.Installment.ID}\",\"card_id\": \"{Selectedcard.ID}\",\"amount\": {Amount}}}}}");

            if (response.Code != 0)
                await Shell.Current.DisplayAlert("Error", response.Message, "OK");
            else
                await Shell.Current.GoToAsync("..");
        }
    }
}
