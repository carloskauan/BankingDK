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
              ulong valueCase2 = ulong.Parse(Console.ReadLine());

              if(!(banking.Deposit(numberAccount, agency, valueCase2))){
                System.Console.WriteLine("DESPOSIT SUCESSFULL");
                break;
              }

              System.Console.WriteLine("DESPOSIT FAILD");
              System.Console.WriteLine("TRY AGAIN..");
            }
            
            break;
          case 3:
            while(true){
              System.Console.WriteLine("INSERT NUMBER ACCOUNT...");
              int numberAccount = int.Parse(Console.ReadLine());

              System.Console.WriteLine("INSERT AGENCY...");
              sbyte agency = sbyte.Parse(Console.ReadLine());

              System.Console.WriteLine("INSERT PASSWORD...");
              string passwordCase3 = Console.ReadLine();

              System.Console.WriteLine("INSERT VALUE TO WITHDRAW...");
              ulong valueCase3 = ulong.Parse(Console.ReadLine());

              if(!(banking.Withdraw(numberAccount, agency, passwordCase3, valueCase3))){
                System.Console.WriteLine("WITHDRAW SUCCESS...");
                break;
              }

              System.Console.WriteLine("TRY AGAIN");
            }

            break;
          case 4:
            while(true){
              int numberAccountSender;
              sbyte agencySender;
              string passwordCase3Sender;
              ulong valueCase4;

              while(true){
                System.Console.WriteLine("INSERT NUMBER ACCOUNT...");
                numberAccountSender = int.Parse(Console.ReadLine());

                System.Console.WriteLine("INSERT AGENCY...");
                agencySender = sbyte.Parse(Console.ReadLine());

                System.Console.WriteLine("INSERT PASSWORD...");
                passwordCase3Sender = Console.ReadLine();

                System.Console.WriteLine("INSERT VALUE TO WITHDRAW...");
                valueCase4 = ulong.Parse(Console.ReadLine());

                if(banking.FindIndexAccount(numberAccountSender, agencySender) != -1)
                  break;

                System.Console.WriteLine("ACCOUNT SENDER NOT FOUND... try again");
              }

              int numberAccountRecept;
              sbyte agencyRecept;

              while(true){
                System.Console.WriteLine("INSERT NUMBER ACCOUNT TO SEND: ");
                numberAccountRecept = int.Parse(Console.ReadLine());

                System.Console.WriteLine("INSERT AGENCY TO SEND: ");
                agencyRecept = sbyte.Parse(Console.ReadLine());
                
                if(banking.FindIndexAccount(numberAccountRecept, agencyRecept) != -1)
                  break;
                System.Console.WriteLine("ACCOUNT RECEPT NOT FOUND... TRY AGAIN");
              }

              Object[] senderData = new object[3]{numberAccountSender, agencySender, passwordCase3Sender};
              Object[] receptData = new object[2]{numberAccountRecept,  agencyRecept};
              
              if(!(banking.Transfer(senderData, receptData, valueCase4))){
                break;
              }
              System.Console.WriteLine("TRANSFER FAILD... TRY AGAIN");
            }

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