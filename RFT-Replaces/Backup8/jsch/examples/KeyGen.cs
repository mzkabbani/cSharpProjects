using System;
using Tamir.SharpSsh.jsch;

namespace Tamir.SharpSsh.jsch.examples
{
	/* -*-mode:java; c-basic-offset:2; -*- */

	class KeyGen
	{
		public static void RunExample(String[] arg)
		{
			if(arg.Length<3)
			{
				Console.Error.WriteLine(
					"usage: java KeyGen rsa output_keyfile comment\n"+
					"       java KeyGen dsa  output_keyfile comment");
				Environment.Exit(-1);
			}
			String _type=arg[0];
			int type=0;
			if(_type.Equals("rsa")){type=KeyPair.RSA;}
			else if(_type.Equals("dsa")){type=KeyPair.DSA;}
			else 
			{
				Console.Error.WriteLine(
					"usage: java KeyGen rsa output_keyfile comment\n"+
					"       java KeyGen dsa  output_keyfile comment");
				Environment.Exit(-1);
			}
			String filename=arg[1];
			String comment=arg[2];

			JSch jsch=new JSch();

			String passphrase="";
			InputForm passphraseField=new InputForm();
			passphraseField.PasswordField = true;
			Object[] ob={passphraseField};
			
				passphraseField.Text="Enter passphrase (empty for no passphrase)";
				bool result=passphraseField.PromptForInput();
			if(result)
			{
				passphrase=passphraseField.getText();
			}

			try
			{
				KeyPair kpair=KeyPair.genKeyPair(jsch, type);
				kpair.setPassphrase(passphrase);
				kpair.writePrivateKey(filename);
				kpair.writePublicKey(filename+".pub", comment);
				Console.WriteLine("Finger print: "+kpair.getFingerPrint());
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
