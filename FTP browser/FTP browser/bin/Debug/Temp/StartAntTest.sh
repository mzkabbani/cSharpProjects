#!/bin/sh

date

cd /hp244srv1/mxclients/qa30104_TPK0001681_5649779

#--- Configuration
#####################
JAVAHOME=/usr/local/java/jdk1.6.0_27

SYBASE=/opt/sybase/oc15.0-EBF16084

ORACLE_HOME=/opt/oracle/10204


echo $SYBASE | grep oc12.0
if [ $? -eq 0 ]; then
    SYBASE_OCS=OCS-12_0
else
    SYBASE_OCS=OCS-12_5
fi
export SYBASE_OCS

MXJ_FILESERVER_HOST=hp244srv
MXJ_FILESERVER_PORT=30104
START_ANT_TEST_LOG=logs/StartAntTest.log
JVM_OPTIONS="-Xms128M -Xmx256M"
#DEBUG_ARGS=

XBOOTPATH=-Xbootclasspath/p:./jar/jaxp-api.jar:./jar/xerces.jar:./jar/xalan.jar

MXJ_JAR_FILELIST=quality.murex.download.client.download
MXJ_POLICY=java.policy
MXJ_BOOT=mxjboot.jar:mlcboot.jar

OS_TYPE=`uname`

#--- Java environment.
######################
# Path to the Java binaries, the 'libjvm.so' dynamic library
# Set it up here: Uncomment and/or modify the following lines according to your setup.

if [ "$JAVAHOME" = "" ] ; then
   $_ECHO "Mx G2000: Fatal ERROR: "
   $_ECHO "          Please specify the Java environment "
   $_ECHO "          in the $SETTINGS_FILE script file"
   exit 1
fi

if [ "$OS_TYPE" = "SunOS" ]; then
   if [ -d $JAVAHOME/jre ]; then
      JAVA_LIBRARY_PATH=$JAVAHOME/jre/lib/sparc
   else
      JAVA_LIBRARY_PATH=$JAVAHOME/lib/sparc
   fi
   PATH=$JAVAHOME/bin:$PATH
   LD_LIBRARY_PATH=$JAVA_LIBRARY_PATH:$LD_LIBRARY_PATH
   LIB_EXT=so
   export LD_LIBRARY_PATH
   # Set Numeric format for SUN
   LC_NUMERIC=en_US
   export LC_NUMERIC
fi
if [ "$OS_TYPE" = "AIX" ]; then
   JAVA_LIBRARY_PATH=$JAVAHOME/jre/bin/classic
   PATH=$JAVAHOME/jre/sh:$JAVAHOME/sh:$PATH
   LIBPATH=$JAVA_LIBRARY_PATH:$LIBPATH:$JAVAHOME/jre/bin
   LIB_EXT=a
   export LIBPATH
   # Set Numeric format for IBM
   LANG=en_US
   export LANG
   export AIXTHREAD_SCOPE=S
   export AIXTHREAD_MUTEX_DEBUG=OFF
   export AIXTHREAD_RWLOCK_DEBUG=OFF
   export AIXTHREAD_COND_DEBUG=OFF
fi

if [ "$OS_TYPE" = "HP-UX" ]; then
   JAVA_LIBRARY_PATH=$JAVAHOME/jre/lib/PA_RISC2.0/hotspot
   PATH=$JAVAHOME/bin:$PATH
   SHLIB_PATH=$JAVA_LIBRARY_PATH:$SHLIB_PATH
   LIB_EXT=sl
   export SHLIB_PATH
fi
if [ "$OS_TYPE" = "Linux" ]; then
   JAVA_VENDOR=`$JAVAHOME/jre/bin/java -version 2>&1 | grep IBM`
   if [ $? -ne 0 ] ; then
      #Assume we are using SUN JVM
      JAVA_LIBRARY_PATH=$JAVAHOME/jre/lib/i386/classic
   else
      #Assume we are using IBM JVM
      JAVA_LIBRARY_PATH=$JAVAHOME/jre/bin/classic
   fi
   LD_LIBRARY_PATH=$JAVA_LIBRARY_PATH:$LD_LIBRARY_PATH
   PATH=$JAVAHOME/bin:$PATH
   LIB_EXT=so
   LC_NUMERIC=en_US
   export LIB_EXT LC_NUMERIC LD_LIBRARY_PATH
fi

export PATH


#--- Sybase environment used only by the launcher.
##################################################

if [ "$SYBASE" != "" ] ; then
export SYBASE
case $OS_TYPE in
        SunOS )
        LD_LIBRARY_PATH=$SYBASE/$SYBASE_OCS/lib:$SYBASE/lib:.:$LD_LIBRARY_PATH
        export LD_LIBRARY_PATH
        ;;
        AIX )
        LIBPATH=$SYBASE/$SYBASE_OCS/lib:.:$LIBPATH
        export LIBPATH
        ;;
        HP-UX )
        SHLIB_PATH=$SYBASE/$SYBASE_OCS/lib:$SYBASE/lib:.:$SHLIB_PATH
        export SHLIB_PATH
        ;;
        Linux )
        LD_LIBRARY_PATH=$SYBASE/$SYBASE_OCS/lib:$SYBASE/lib:.:$LD_LIBRARY_PATH
        export LD_LIBRARY_PATH
        ;;
        * )
        $_ECHO "Warning : Do not know how to handle this OS type $OS_TYPE."
        ;;
esac
PATH=$SYBASE/$SYBASE_OCS/bin:$PATH
export PATH
fi

#--- Oracle environment.
##################################################

if [ "$ORACLE_HOME" != "" ] ; then
export ORACLE_HOME
case $OS_TYPE in
        SunOS )
        LD_LIBRARY_PATH_64=$ORACLE_HOME/lib
        LD_LIBRARY_PATH=$ORACLE_HOME/lib32:$ORACLE_HOME/lib:/usr/ccs/lib:.:$LD_LIBRARY_PATH
        export LD_LIBRARY_PATH
        export LD_LIBRARY_PATH_64
        ;;
        AIX )
        LIBPATH=$ORACLE_HOME/lib32:$ORACLE_HOME/lib:.:$LIBPATH
        export LIBPATH
        ;;
        HP-UX )
        SHLIB_PATH=$ORACLE_HOME/lib32:$ORACLE_HOME/lib:.:$SHLIB_PATH
        export SHLIB_PATH
        ;;
        Linux )
        LD_LIBRARY_PATH=$ORACLE_HOME/lib32:$ORACLE_HOME/lib:/usr/ccs/lib:.:$LD_LIBRARY_PATH
        export LD_LIBRARY_PATH
        ;;
        * )
        $_ECHO "Warning : Do not know how to handle this OS type $OS_TYPE."
        ;;
esac
PATH=$ORACLE_HOME/bin:$PATH
export PATH
fi


if [ ! -d logs ];then
    mkdir logs
fi

echo "****************************************" 2>&1 | /usr/bin/tee -a $START_ANT_TEST_LOG
echo "`date`" 2>&1 | /usr/bin/tee -a $START_ANT_TEST_LOG
echo "****************************************" 2>&1 | /usr/bin/tee -a $START_ANT_TEST_LOG

$JAVAHOME/bin/java -cp $MXJ_BOOT ${DEBUG_ARGS} $JVM_OPTIONS -Djava.awt.headless=true -Dorg.apache.tools.ant.ProjectHelper=murex.quality.automation.runtime.extensions.ant.framework.ProjectHelper23 -Djava.rmi.server.codebase=http://$MXJ_FILESERVER_HOST:$MXJ_FILESERVER_PORT/$MXJ_JAR_FILELIST murex.rmi.loader.RmiLoader /MXJ_CLASS_NAME:murex.quality.automation.runtime.kernel.runner.AutomationTestRunnable /QAJ_CLASS_NAME:murex.quality.automation.runtime.extensions.ant.framework.AutomationAntMain /MXJ_POMS:murex.qaruntime:qaruntime-all\;murex.qaruntime:qaruntime-public-all\;murex:murex-server\;murex:murex-gui $*  2>&1 | /usr/bin/tee -a $START_ANT_TEST_LOG
