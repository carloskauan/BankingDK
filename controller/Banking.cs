using System.Collections.Generic;

namespace BankingDK{
  class Banking{
    private List<Account> Accounts = new List<Account>();
  
    public void NewAccount(string name, string cpf, string password, ulong balance){
      Account newAccount = new Account(name, cpf, password);
      if(balance != 0)
        newAccount.AttBalance(balance, "add");

      Accounts.Add(newAccount);
    }
    public bool Deposit(int numberAccount, sbyte agency, ulong value){
      int indexAccount = FindIndexAccount(numberAccount, agency);
      if(indexAccount == -1){
        return true;
      }

      Accounts[indexAccount].AttBalance(value, "add");
      return false;
    }

    public bool Withdraw(int accountNumber, sbyte agency, string password, ulong value){
      int index = FindIndexAccount(accountNumber, agency);
      Account account = Accounts[index];

      if(!(account.GetPassword() == password)){
        System.Console.WriteLine("ACESS INVALID");
        return true;
      }else if(account.GetBalance() < value){
        System.Console.WriteLine("Insufficient balance");
        return true;
      } 

      account.AttBalance(value, "sub");
      System.Console.WriteLine(account);
      return false;
    }

    public bool Transfer(object[] sender, object[] recept, ulong value){
      int account = int.Parse(sender[0].ToString());
      sbyte agency = sbyte.Parse(sender[1].ToString());
      string password = sender[2].ToString();
      if(Withdraw(account, agency, password,value))
        return true;
        
      account = int.Parse(recept[0].ToString());
      agency = sbyte.Parse(recept[1].ToString());
      
      if(Deposit(account, agency, value))
        return true;

      System.Console.WriteLine("TRANSFER SUCCESSFULL...");
      return false;
    }

    public int FindIndexAccount(int numberAccount, sbyte agency){
      return Accounts.FindIndex(param => (param.GetNumberAccount() == numberAccount && param.GetAgency() == agency));
    }

    //DEV METHOD
    public void TesteGetAccount(int numberAccount, sbyte agency){
      System.Console.WriteLine(FindIndexAccount(numberAccount, agency));
    }
    //DEV METHOD
    public void ShowAccountsData(){
      foreach (var account in Accounts){
        System.Console.WriteLine(account);
      }
    }
    
  }
}