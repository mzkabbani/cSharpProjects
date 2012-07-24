using System;
using Tamir.SharpSsh.jsch;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Tamir.SharpSsh.jsch.examples
{

	public class ScpFrom
	{
		public static void RunExample(String[] arg)
		{
			if(arg.Length!=2)
			{
				Console.WriteLine("usage: java ScpFrom user@remotehost:file1 file2");
				return;
			}      

			try
			{

				String user=arg[0].Substring(0, arg[0].IndexOf('@'));
				arg[0]=arg[0].Substring(arg[0].IndexOf('@')+1);
				String host=arg[0].Substring(0, arg[0].IndexOf(':'));
				String rfile=arg[0].Substring(arg[0].IndexOf(':')+1);
				String lfile=arg[1];

				String prefix=null;
				if(Directory.Exists(lfile))
				{
					prefix=lfile+Path.DirectorySeparatorChar;
				}

				JSch jsch=new JSch();
				Session session=jsch.getSession(user, host, 22);

				// username and password will be given via UserInfo interface.
				UserInfo ui=new MyUserInfo();
				session.setUserInfo(ui);
				session.connect();

				// exec 'scp -f rfile' remotely
				String command="scp -f "+rfile;
				Channel channel=session.openChannel("exec");
				((ChannelExec)channel).setCommand(command);

				// get I/O streams for remote scp
				Stream outs=channel.getOutputStream();
				Stream ins=channel.getInputStream();

				channel.connect();

				byte[] buf=new byte[1024];

				// send '\0'
				buf[0]=0; outs.Write(buf, 0, 1); outs.Flush();

				while(true)
				{
					int c=checkAck(ins);
					if(c!='C')
					{
						break;
					}

					// read '0644 '
					ins.Read(buf, 0, 5);

					int filesize=0;
					while(true)
					{
						ins.Read(buf, 0, 1);
						if(buf[0]==' ')break;
						filesize=filesize*10+(buf[0]-'0');
					}

					String file=null;
					for(int i=0;;i++)
					{
						ins.Read(buf, i, 1);
						if(buf[i]==(byte)0x0a)
						{
							file=Util.getString(buf, 0, i);
							break;
						}
					}

					//Console.WriteLine("filesize="+filesize+", file="+file);

					// send '\0'
					buf[0]=0; outs.Write(buf, 0, 1); outs.Flush();

					// read a content of lfile
					FileStream fos=File.OpenWrite(prefix==null ? 
					lfile :
						prefix+file);
					int foo;
					while(true)
					{
						if(buf.Length<filesize) foo=buf.Length;
						else foo=filesize;
						ins.Read(buf, 0, foo);
						fos.Write(buf, 0, foo);
						filesize-=foo;
						if(filesize==0) break;
					}
					fos.Close();

					byte[] tmp=new byte[1];

					if(checkAck(ins)!=0)
					{
						Environment.Exit(0);
					}

					// send '\0'
					buf[0]=0; outs.Write(buf, 0, 1); outs.Flush();
				}
				Environment.Exit(0);
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		static int checkAck(Stream ins) 
		{
			int b=ins.ReadByte();
			// b may be 0 for success,
			//          1 for error,
			//          2 for fatal error,
			//          -1
			if(b==0) return b;
			if(b==-1) return b;

			if(b==1 || b==2)
			{
				StringBuilder sb=new StringBuilder();
				int c;
				do 
				{
					c=ins.ReadByte();
					sb.Append((char)c);
				}
				while(c!='\n');
				if(b==1)
				{ // error
					Console.Write(sb.ToString());
				}
				if(b==2)
				{ // fatal error
					Console.Write(sb.ToString());
				}
			}
			return b;
		}

		public class MyUserInfo : UserInfo
		{
			public String getPassword(){ return passwd; }
			public bool promptYesNo(String str)
			{
				DialogResult returnVal = MessageBox.Show(
					str,
					"SharpSSH",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);
				return (returnVal==DialogResult.Yes);
			}
  
			String passwd;
			

			public String getPassphrase(){ return null; }
			public bool promptPassphrase(String message){ return true; }
			public bool promptPassword(String message)
			{
				InputForm passwordField=new InputForm();
				passwordField.Text = message;
				passwordField.PasswordField = true;

				if ( passwordField.PromptForInput() )
				{
					passwd=passwordField.getText();
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
