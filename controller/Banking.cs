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
    public void Deposit(){

    }
    public void Withdraw(){

    }
    public void Transfer(){
      
    }
    public void ShowAccountsData(){
      foreach (var account in Accounts){
        System.Console.WriteLine(account);
      }
    }
    
  }
}