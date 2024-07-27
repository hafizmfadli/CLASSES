using Classes;


class Program
{
  static void Main(string[] args)
  {
    var account = new BankAccount("<name>", 1000);
    Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

    account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
    Console.WriteLine(account.Balance);

    account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
    Console.WriteLine(account.Balance);

    BankAccount invalidAccount;
    try
    {
      invalidAccount = new BankAccount("invalid", -55);
    }
    catch (ArgumentOutOfRangeException e)
    {
      Console.WriteLine("Exception caught creating account with negative balance");
      Console.WriteLine(e.ToString());
    }

    Console.WriteLine(account.GetAccountHistory());

    var giftcard = new GiftCardAccount("gift card", 100, 50);
    giftcard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
    giftcard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
    giftcard.PerformMonthEndTransactions();
    giftcard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
    Console.WriteLine(giftcard.GetAccountHistory());

    var savings = new InterestEarningAccount("savings account", 10000);
    savings.MakeDeposit(750, DateTime.Now, "save some money");
    savings.MakeDeposit(1250, DateTime.Now, "add more saving");
    savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
    savings.PerformMonthEndTransactions();
    Console.WriteLine(savings.GetAccountHistory());

    var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
    lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "take out monthly advance");
    lineOfCredit.MakeDeposit(50m, DateTime.Now, "pay back small amount");
    lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "emergency funds for repairs");
    lineOfCredit.MakeDeposit(150m, DateTime.Now, "parital restoration on repairs");
    lineOfCredit.PerformMonthEndTransactions();
    Console.WriteLine(lineOfCredit.GetAccountHistory());
  }

}

