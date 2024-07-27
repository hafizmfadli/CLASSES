namespace Classes;

public class LineOfCreditAccount : BankAccount
{

  public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
  {

  }

  public override void PerformMonthEndTransactions()
  {
    if (this.Balance < 0)
    {
      decimal interest = -this.Balance * 0.07m;
      MakeWithdrawal(interest, DateTime.Now, "charge monthly interest");
    }
  }

  protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => isOverdrawn ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default;

}