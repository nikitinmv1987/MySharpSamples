using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4Test
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var client = new Client {FirstName = "Max", LastName = "Nikitin"};
      client.Accounts.Add(new Account("KZR", "12345"));
      client.Accounts.Add(new Account("EUR", "23456"));

      var t = new RuntimeTextTemplate1(client);

      richTextBox1.Text = t.TransformText();
      
    }
  }
}
