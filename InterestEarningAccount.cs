namespace Classes;

public class InterestEarningAccount : BankAccount
{
  public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
  {


  }

  public override void PerformMonthEndTransactions()
  {
    if (this.Balance > 500m)
    {
      decimal interest = this.Balance * 0.2m;
      MakeDeposit(interest, DateTime.Now, "apply monthly intereset");
    }
  }
}