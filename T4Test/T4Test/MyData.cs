using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Test
{
  public class Client
  {
    public Client()
    {
      Accounts = new List<Account>();
    }

    public List<Account> Accounts { get; set; }  

    public String FirstName;
    public String LastName;
  }

  public class Account
  {
    public Account(String number, String currency)
    {
      Number = number;
      Currency = currency;
    }

    public String Number { get; set; }
    public String Currency { get; set; }
  }
 
}
