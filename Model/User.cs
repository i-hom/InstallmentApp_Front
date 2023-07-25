namespace InstallmentApp_Front.Model;

public class User
{
    public string ID { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Passport_ID { get; set; }
    public int CashBack { get; set; }
    public List<Installment> Installments { get; set; }
    public List<Card> Cards { get; set; }
}
