namespace BankingDK{
  class Account{
    private string Name;
    private int NumberAccount;
    private string Cpf;
    private sbyte Agency;
    private string Password;
    private ulong Balance = 0;

    public Account(string name, string cpf, string password){
      Name = name;
      NumberAccount = GenerateAccountNumber();
      Cpf = cpf;
      Agency = ChoiceAgency();
      Password = password;
    }

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
    public sbyte ChoiceAgency(){ 
      sbyte[] Aggencies = new sbyte[4]{01, 06, 07, 05};
      Random random = new Random(); 
      int choicedIndex = random.Next(4);
      return Aggencies[choicedIndex];
    }
    public int GenerateAccountNumber(){
      int[] accountDigits = new int[6];
      Random random = new Random(); 
      for(int i = 0; i < accountDigits.Length; accountDigits[i] = random.Next(10), i++){}
      return int.Parse(String.Join("", accountDigits));
    }

    public override string ToString(){
     return $"\n--------NAME: {Name}\n ACCOUNT NUMBER: {NumberAccount}\nCPF: {Cpf}\nAGENCY: {Agency}\nPASSWORD: {Password}\nBALANCE: {Balance}";
    }

    //Getters e Setters
    public int GetNumberAccount(){
      return NumberAccount;
    }
    public sbyte GetAgency(){
      return Agency;
    }

  }
}