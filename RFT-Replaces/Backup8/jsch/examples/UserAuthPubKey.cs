using System;
using System.Windows.Forms;

namespace Tamir.SharpSsh.jsch.examples
{
	/* -*-mode:java; c-basic-offset:2; -*- */

	public class UserAuthPubKey
	{
		public static void RunExample(String[] arg)
		{

			try
			{
				JSch jsch=new JSch();

				OpenFileDialog chooser = new OpenFileDialog();
				chooser.Title ="Choose your privatekey(ex. ~/.ssh/id_dsa)";
				//chooser.setFileHidingEnabled(false);
				DialogResult returnVal = chooser.ShowDialog();
				if(returnVal == DialogResult.OK) 
				{
					Console.WriteLine("You chose "+
						chooser.FileName+".");
					jsch.addIdentity(chooser.FileName
						//			 , "passphrase"
						);
				}
				else
				{
					Console.WriteLine("Error getting key file...");
					return;
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

					// username and passphrase will be given via UserInfo interface.
					UserInfo ui=new MyUserInfo();
					session.setUserInfo(ui);
					session.connect();

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
			public String getPassword(){ return null; }
			public bool promptYesNo(String str)
			{
				returnVal = MessageBox.Show(
					str,
					"SharpSSH",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);
				return (returnVal==DialogResult.Yes);
			}
			internal String passphrase;
			//JTextField passphraseField=(JTextField)new JPasswordField(20);
			//InputForm inForm = null;
			DialogResult returnVal;

			public String getPassphrase(){ return passphrase; }
			public bool promptPassphrase(String message)
			{
				InputForm inForm = new InputForm();
				inForm.Text = message;
				inForm.PasswordField = true;
				
				if ( inForm.PromptForInput() )
				{
					passphrase=inForm.textBox1.Text;
					inForm.Close();
					return true;
				}
				else
				{
					inForm.Close();
					return false;
				}
			}
			public bool promptPassword(String message){ return true; }
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
