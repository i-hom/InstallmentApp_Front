using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InstallmentApp_Front.Model;
using InstallmentApp_Front.Pages;
using InstallmentApp_Front.Services;

namespace InstallmentApp_Front.ViewModel;

public partial class CabinetViewModel : BaseViewModel
{
    Installment_Service service;
    IConnectivity connection;

    [ObservableProperty]
    string phoneNumber, password, cardnumber, cardexpdate;

    [ObservableProperty]
    User user_info;

    public CabinetViewModel(Installment_Service service, IConnectivity connection) 
    {
        this.service = service;
        this.connection = connection;
    }

    [RelayCommand]
    async Task OnSignIn(CabinetViewModel cabinet)
    {
        if (connection.NetworkAccess != NetworkAccess.Internet)
            await Shell.Current.DisplayAlert("No Internet!", "Check Internet Connection", "OK");
        IsBusy = true;
        Result<User> r_user_info = await service.Request<Result<User>>($"{{\r\n\"method\": \"user.get\",\r\n\"params\": {{\r\n\"phoneNumber\": \"{PhoneNumber}\",\r\n\"password\": \"{Password}\"\r\n}}\r\n}}");
        User_info = r_user_info.Data;
        IsBusy = false;
        if (User_info != null)
        {
            await Shell.Current.GoToAsync($"//{nameof(InstallmentApp_Front.Pages.Installment)}");
        }
        else
            await Shell.Current.DisplayAlert("Error", "Invalid SignIn Data", "OK");

    }

    [RelayCommand]
    async Task GoToCardAdd() 
    {
        await Shell.Current.GoToAsync(nameof(CardAdd));
    }

    [RelayCommand]
    async Task AddCard() 
    {
        if(Cardnumber.Length != 16 || Cardexpdate.Length != 4) 
            await Shell.Current.DisplayAlert("Invalid Data", "Please check your input", "OK");

        Response r_info = await service.Request<Response>($"{{\r\n\"method\": \"card.add\",\r\n\"params\": {{\r\n\"number\": \"{Cardnumber}\",\r\n\"expDate\": \"{Cardexpdate}\",\r\n\"ownerid\": \"{User_info.ID}\"\r\n}}\r\n}}");
        if (r_info.Code == 0)
            await Shell.Current.GoToAsync("..");
        else
            await Shell.Current.DisplayAlert("Error", r_info.Message, "OK");

        Cardexpdate = "";
        Cardnumber = "";
    }

    [RelayCommand]
    async Task GoToDetails(Model.Installment installment) 
    {
        Result<User> r_user_info = await service.Request<Result<User>>($"{{\r\n\"method\": \"user.get\",\r\n\"params\": {{\r\n\"phoneNumber\": \"{PhoneNumber}\",\r\n\"password\": \"{Password}\"\r\n}}\r\n}}");
        User_info = r_user_info.Data;

        installment = User_info.Installments.Find(x => x.ID == installment.ID);

        Details details = new()
        {
            Installment = installment,
            Cards = User_info.Cards
        };

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Details", details }
        });
    }
}
