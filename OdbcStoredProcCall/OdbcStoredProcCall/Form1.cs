using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdbcStoredProcCall
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var connection = new OdbcConnection("DSN=Local");
      
      var command = connection.CreateCommand();
      command.CommandText = "{ CALL AuthenticateAccount(?, ?, ?, ?) }";
      command.CommandType = CommandType.StoredProcedure;

      command.Parameters.Add("@TLogin", OdbcType.NVarChar).Value = textBox1.Text;
      command.Parameters.Add("@TPIN", OdbcType.NVarChar).Value = textBox2.Text;

      var pResult = command.Parameters.Add("@Result", OdbcType.Bit);
      pResult.Direction = ParameterDirection.Output;
      var pAccountLocked = command.Parameters.Add("@AccountLocked", OdbcType.Bit);
     // pAccountLocked.IsNullable = true;
      pAccountLocked.Direction = ParameterDirection.Output;

      connection.Open();
      command.ExecuteNonQuery();

      checkBox1.Checked = (Boolean)pResult.Value;    
      var accountLocked = pAccountLocked.Value != DBNull.Value && (Boolean)pAccountLocked.Value;
      checkBox2.Checked =  accountLocked;
    }
  }
}
