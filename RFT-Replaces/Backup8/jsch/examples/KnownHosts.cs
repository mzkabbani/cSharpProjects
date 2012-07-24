using System;
using System.IO;
using System.Windows.Forms;

namespace Tamir.SharpSsh.jsch.examples
{
	/* -*-mode:java; c-basic-offset:2; -*- */

	public class KnownHosts
	{
		public static void RunExample(String[] arg)
		{

			try
			{
				JSch jsch=new JSch();

				OpenFileDialog chooser = new OpenFileDialog();
				chooser.Title = "Choose your known_hosts(ex. ~/.ssh/known_hosts)";
				//chooser.setFileHidingEnabled(false);
				DialogResult returnVal = chooser.ShowDialog();
				if(returnVal == DialogResult.OK) 
				{
					Console.WriteLine("You chose "+
						chooser.FileName+".");
					jsch.setKnownHosts(chooser.FileName);
				}
				else
				{
					Console.WriteLine("Error getting host file...");
					return;
				}

				HostKeyRepository hkr=jsch.getHostKeyRepository();
				HostKey[] hks=hkr.getHostKey();
				if(hks!=null)
				{
					Console.WriteLine("Host keys in "+hkr.getKnownHostsRepositoryID());
					for(int i=0; i<hks.Length; i++)
					{
						HostKey hk=hks[i];
						Console.WriteLine(hk.getHost()+" "+
							hk.getType()+" "+
							hk.getFingerPrint(jsch));
					}
					Console.WriteLine("");
				}

				InputForm inForm = new InputForm();
				inForm.Text = "Enter username@hostname";
				inForm.textBox1.Text = Environment.UserName+"@localhost"; 
					
				if (inForm.PromptForInput())
				{
					String host = inForm.textBox1.Text;
					String user=host.Substring(0, host.IndexOf('@'));
					host=host.Substring(host.IndexOf('@')+1);

					Session session=jsch.getSession(user, host, 22);

					// username and password will be given via UserInfo interface.
					UserInfo ui=new MyUserInfo();
					session.setUserInfo(ui);

					session.connect();

					HostKey hk=session.getHostKey();
					Console.WriteLine("HostKey: "+
						hk.getHost()+" "+
						hk.getType()+" "+
						hk.getFingerPrint(jsch));
			

					Channel channel=session.openChannel("shell");

					channel.setInputStream(Console.OpenStandardInput());
					channel.setOutputStream(Console.OpenStandardOutput());

					channel.connect();
				}
				inForm.Close();
			

			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public class MyUserInfo : UserInfo
		{
			public String getPassword(){ return passwd; }
			public bool promptYesNo(String str)
			{
				returnVal = MessageBox.Show(
					str,
					"SharpSSH",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);
				return (returnVal==DialogResult.Yes);
			}
  
			DialogResult returnVal;
			String passwd;
			//JTextField passwordField=(JTextField)new JPasswordField(20);

			public String getPassphrase(){ return null; }
			public bool promptPassphrase(String message){ return true; }
			public bool promptPassword(String message)
			{
				InputForm inForm = new InputForm();
				inForm.Text = message;
				inForm.PasswordField = true;
				
				if ( inForm.PromptForInput() )
				{
					passwd=inForm.getText();
					return true;
				}
				else{ return false; }
			}
			public void showMessage(String message)
			{
				MessageBox.Show(
					message,
					"SharpSSH",
					MessageBoxButtons.OK,
					MessageBoxIcon.Asterisk);
			}
		}

	}



}
