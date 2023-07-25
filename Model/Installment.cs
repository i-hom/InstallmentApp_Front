namespace InstallmentApp_Front.Model;

public class Installment
{
    public string ID { get; set; }
    public string ElmakonID { get; set; }
    public Item Item { get; set; }
    public int Balance { get; set; }
    public bool IsActive { get; set; }
    public int MonthlyPayment { get; set; }
    public List<Payment> Payments { get; set; } 
}
