using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ServiceReference1;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var basicHttpbinding = new BasicHttpBinding(BasicHttpSecurityMode.None) {Name = "Rest"};
      
      basicHttpbinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
      basicHttpbinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

      EndpointAddress endpointAddress = new EndpointAddress(@"http://localhost/RESfullWCFService/RestServiceImpl.svc");
      RestServiceImplClient proxyClient = new RestServiceImplClient(basicHttpbinding, endpointAddress);


      richTextBox1.Text = proxyClient.JSONData("lla");

    }
  }
}
