using System;
using System.IO;
using System.Windows.Forms;

namespace Tamir.SharpSsh.jsch.examples
{

	class ChangePassphrase
	{
		public static void RunExample(String[] arg)
		{
			if(arg.Length!=1)
			{
				Console.WriteLine("usage: java ChangePassphrase private_key");
				Environment.Exit(-1);
			}

			JSch jsch=new JSch();

			String pkey=arg[0];

			try
			{
				KeyPair kpair=KeyPair.load(jsch, pkey);

				Console.WriteLine(pkey+" has "+(kpair.isEncrypted()?"been ":"not been ")+"encrypted");

				String passphrase="";
				InputForm passphraseField = null;

				while(kpair.isEncrypted())
				{
					passphraseField=new InputForm();
					passphraseField.PasswordField = true;


					if(!passphraseField.PromptForInput())
					{
						Environment.Exit(-1);
					}
					passphrase=passphraseField.getText();
					if(!kpair.decrypt(passphrase))
					{
						Console.WriteLine("failed to decrypt "+pkey);
					}
					else
					{
						Console.WriteLine(pkey+" is decrypted.");
					}
				}

				passphrase="";

				passphraseField=new InputForm();
				passphraseField.PasswordField = true;

				if(!passphraseField.PromptForInput())
				{
					Environment.Exit(-1);
				}
				passphrase=passphraseField.getText();

				kpair.setPassphrase(passphrase);
				kpair.writePrivateKey(pkey);
				kpair.dispose();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
			Environment.Exit(0);
		}
	}
}
