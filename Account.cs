namespace BankingDK{
  class Account{
    private string Name;
    private int NumberAccount;
    private string Cpf;
    private sbyte Agency;
    private string Password;
    private ulong Balance;

    public bool AttBalance(ulong value, string type){ //"add"  "sub"
      if(value <= 0){
        System.Console.WriteLine("Invalid Value");
        return false;
      }

      switch (type){
        case "add":
          Balance += value;
          break;
        case "sub":
          Balance -= value;
          break;
        
      }
      System.Console.WriteLine("New Balance" + Balance);
      return true;
    }
  }
}