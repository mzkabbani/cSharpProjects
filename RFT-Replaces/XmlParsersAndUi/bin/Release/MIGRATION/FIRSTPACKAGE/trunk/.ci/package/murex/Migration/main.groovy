package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "AppDir======>" + AppDir;
		println "logDir======>" + logDir;
		println "backupDir===>" + backupDir;
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		println "aaaaaaaaaaaaaaaaaaaaa"
		properties.values().each { println it.toString() }
		println "====>>"+ properties.get("Customiztions_Logs_Dir");
		
		FrontendUtilities frontEndUtilities = new FrontendUtilities();
		frontEndUtilities.SetUtilsAppdirPath(AppDir);
		frontEndUtilities.SetUtilsLogDir(logDir);
		frontEndUtilities.SetUtilsBackupDir(backupDir);

}}




















