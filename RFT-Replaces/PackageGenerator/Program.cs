using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using System.IO;

namespace PackageGenerator {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            // Handler for exceptions in threads behind forms.
            System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try {
                Application.Run(new Mainform());
            } catch (Exception ex) {
                throw;
            }
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e) {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
            ILog log = LogManager.GetLogger(typeof(Program));
            log.Error(ex.Message + "\n" + ex.StackTrace);
        }

        private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e) {
            Exception ex = default(Exception);
            ex = e.Exception;
            ILog log = LogManager.GetLogger(typeof(Program)); //Log4NET
            log.Error(ex.Message + "\n" + ex.StackTrace);   
        }
    }
}
