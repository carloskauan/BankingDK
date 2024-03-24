using System.Text;
namespace BankingDK{
  class Validators{
    public static bool Name(string name){ 
      if((name.Length > 8 && name.Length <= 50) || string.IsNullOrEmpty(name))
        return false;  

      int spaceCount = 0;
      byte[] asciiBytes = Encoding.ASCII.GetBytes(name);
      
      foreach (var ascii in asciiBytes){
        spaceCount = ascii == 32 ? ++spaceCount : spaceCount;
        if(spaceCount > 6){
          return false;
        }else if(
          (
            !(ascii >= 65 && ascii <= 90) && 
            !(ascii >= 97 && ascii <= 122)
          ) &&
          ascii != 32
        ){
          return false;
        }
      }
      return true;
    }
  }
}