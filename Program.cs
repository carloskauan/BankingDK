﻿namespace BankingDK{
  class Program{
    static void Main(){
      while(true){
        Console.Write("\n   -  W E L C O M E  -\n    Do you need help?\n \t| 1 - Create a account.\n\t| 2 - Deposit.\n\t| 3 - Withdraw.\n\t| 4 - Transfer.\n\t| 0 - Exit the program.\n\n > Select your option: ");
        switch(int.Parse(Console.ReadLine())){
          case 1:

            break;
          case 2:

            break;
          case 3:

            break;
          case 4:

            break;
          case 0 :
            System.Environment.Exit(0);
            break;
          default:
              System.Console.WriteLine("Invalid Option...");
              break;
        }
      }
    }
  }
}