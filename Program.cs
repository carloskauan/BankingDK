namespace BankingDK{
  class Program{
    static void Main(){
      Banking banking = new Banking();
      while(true){
        Console.Write("\n   -  W E L C O M E  -\n    Do you need help?\n \t| 1 - Create a account.\n\t| 2 - Deposit.\n\t| 3 - Withdraw.\n\t| 4 - Transfer.\n\t| 0 - Exit the program.\n\n > Select your option: ");
        switch(int.Parse(Console.ReadLine())){
          case 1:
            System.Console.WriteLine("---CREATE NEW ACCOUNT---");

            string name = GetName();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("PASSWORD: ");
            string password = Console.ReadLine();

            System.Console.WriteLine("You wanna make a initial deposit? 0 to no");
            ulong balance =  ulong.Parse(Console.ReadLine());

            banking.NewAccount(name, cpf, password, balance);

            banking.ShowAccountsData();

            break;
          case 2:
            while(true){
              System.Console.WriteLine("INSERT NUMBER ACCOUNT: ");
              int numberAccount = int.Parse(Console.ReadLine());

              System.Console.WriteLine("INSERT AGENCY: ");
              sbyte agency = sbyte.Parse(Console.ReadLine());

              System.Console.WriteLine("INSERT VALUE TO DEPOSIT: ");
              ulong value = ulong.Parse(Console.ReadLine());

              if(!(banking.Deposit(numberAccount, agency, value)))
                break;
              System.Console.WriteLine("TRY AGAIN..");
            }
            
            break;
          case 3:

            break;
          case 4:

            break;

          //DEV METHOD
          case 5:
            banking.ShowAccountsData();
            banking.TesteGetAccount(int.Parse(Console.ReadLine()), sbyte.Parse(Console.ReadLine()));
            break;
          //DEV METHOD
          case 0 :
            System.Environment.Exit(0);
            break;
          default:
              System.Console.WriteLine("Invalid Option...");
              break;
        }
      }
    }

    static string GetName(){
      string name;
      while(true){
        Console.Write("Name: ");
        name = Console.ReadLine();
        
        if(Validators.Name(name))
          break;

        System.Console.WriteLine("Invalid name!!");
      }

      
      return name;
    }
  }
}