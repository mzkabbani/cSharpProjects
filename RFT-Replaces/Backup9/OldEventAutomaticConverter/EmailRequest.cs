using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OldEventAutomaticConverter {
   public class EmailRequest {

       public void SendEmailToMultiUsers(string sender, string recipient, string subject, string body) {
           string[] recipients = recipient.Split(';');
           try {
               for (int i = 0; i < recipients.Length; i++) {
                   SendEmail(sender, recipients[i], subject, body);
               }                       
           } catch (Exception ex) {
               ShowCustomError(ex.Message, false);
           }       
       }

       public DialogResult ShowCustomError(string errorText, bool useYesNo) {
           if (!useYesNo) {               
               return MessageBox.Show(errorText, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           } else {               
               return MessageBox.Show(errorText, "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
           }
       }

       public void SendEmail(string sender,string recipient,string subject,string body){

           MailAddress mailfrom = new MailAddress(sender);
           MailAddress mailto = new MailAddress(recipient);
           MailMessage newmsg = new MailMessage(mailfrom, mailto);

           newmsg.Subject = subject;
           newmsg.Body = body;          

           //Attachment att = new Attachment("C:\\...file path");
           //newmsg.Attachments.Add(att);

           SmtpClient smtp = new SmtpClient("Barid.lb.murex.com");
           smtp.UseDefaultCredentials = false;
           smtp.Credentials = new NetworkCredential();
           //smtp.EnableSsl = true;           
               smtp.Send(newmsg);          
       }

    }
}
