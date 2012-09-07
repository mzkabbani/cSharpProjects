package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){		
		println "Package Deployment Starting!"
		println "AppDir======>" + AppDir;
		println "logDir======>" + logDir;
		println "backupDir===>" + backupDir;		
		boolean logFileExists =  new File(AppDir+logDir+"/CustomizationsLog.log").exists();
		
		if	(logFileExists){		
		println "This Package has already been run before!";
		return;
		}
		
		FrontendUtilities frontEndUtilities = new FrontendUtilities();
		frontEndUtilities.SetUtilsAppdirPath(AppDir);
		frontEndUtilities.SetUtilsLogDir(logDir);
		frontEndUtilities.SetUtilsBackupDir(backupDir);
	
		
		
		
		
		
		
	def PROP_GenericProp = properties.get("GenericProp");


//Start-Operations
	
	/*Add comment here...*/
	frontEndUtilities.ExecuteCommandInShell( "launchmxj.app -c -scriptant /MXJ_ANT_BUILD_FILE:public.mxres.script.assembly.MXpress-Install-Navigation-Maintenance.mxres /MXJ_ANT_TARGET:install" ,"new File(\"/dell037srv/apps/qa16485_TPK0000982_7018645/\")" );
	
	/*Add comment here...*/
	frontEndUtilities.ExecuteCommandInShell( "launchmxj.app -c -scriptant /MXJ_ANT_BUILD_FILE:public.mxres.script.assembly.MXpress-Install-Navigation-Maintenance.mxres /MXJ_ANT_TARGET:install > MXpress-Installer-maintenance.log" ,"new File(\"/dell037srv/apps/qa16485_TPK0000982_7018645/\")" );
	//End-Operations
		
}}





















