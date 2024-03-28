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
        System.Console.WriteLine("DESPOSIT FAILD");
        return true;
      }

      Accounts[indexAccount].AttBalance(value, "add");
      System.Console.WriteLine("DESPOSIT SUCESSFULL");
      return false;
    }
    public void Withdraw(){

    }
    public void Transfer(){
      
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