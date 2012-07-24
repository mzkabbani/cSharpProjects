#EM v* 0 100000000
#EMDESC This script retrieves all the users currently having an MX session opened on a given environment.
OS=`uname`
case $OS in
	SunOS)
		PS_COMMAND="/usr/ucb/ps -auwwwxxx"
		AWK_COMMAND="/usr/xpg4/bin/awk"
		CAT_COMMAND="/usr/bin/cat"
		GREP_COMMAND="/usr/bin/grep"
		SED_COMMAND="/usr/xpg4/bin/sed"
		;;
	Linux)
		PS_COMMAND="/bin/ps xeafww -o user=VeryLongUserNames,pid,pcpu,pmem,vsz,rss,tty,stat,start,time,cmd"
		AWK_COMMAND="/usr/bin/awk"
		CAT_COMMAND="/bin/cat"
		GREP_COMMAND="/bin/grep"
		SED_COMMAND="/usr/bin/sed"
		;;
	AIX)
		PS_COMMAND="/bin/ps eauxww"
		AWK_COMMAND="/usr/bin/awk"
		CAT_COMMAND="/usr/bin/cat"
		GREP_COMMAND="/usr/bin/grep"
		SED_COMMAND="/usr/bin/sed"
		;;
	*)
		echo "Operating system $OS not supported"
		exit 1
		;;
esac

MUREXNET_PORT=`$CAT_COMMAND mxg2000_settings.sh | $GREP_COMMAND "MUREXNET_PORT=" |cut -c 1-2500| $AWK_COMMAND -F"=" ' { print $2 } '`
MXJ_FILESERVER_HOST=loth
mxIds=`$PS_COMMAND | $GREP_COMMAND -v $GREP_COMMAND | $GREP_COMMAND ":$MUREXNET_PORT" | $GREP_COMMAND -v $$  |  $GREP_COMMAND "./mx" | $GREP_COMMAND $MXJ_FILESERVER_HOST |cut -c 1-2500|$AWK_COMMAND '{pids = pids " " $2} END {print pids}'`

for b in $mxIds; do
echo `$PS_COMMAND $b | $SED_COMMAND 's/MXJ_CLIENT_HOST:/*/g'| $SED_COMMAND 's/MXJ_CLIENT_LOGIN:/*/g' | $AWK_COMMAND -F"*" '{ print $2,$3}' | cut -d " " -f4`
done
