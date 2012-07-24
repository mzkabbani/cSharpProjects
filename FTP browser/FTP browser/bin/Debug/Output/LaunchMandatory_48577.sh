#EM v3.1.* 1063985 10000000
#EMDESC This script launches the MX services that are needed to be able to launch an MX session.
#!/bin/bash


echo "Status 0 8"
echo "Launching FileServer"
./launchmxj.app -fs > /dev/null
sleep 3
echo "Status 1 8"
echo "Launching xmls"
./launchmxj.app -xmls > /dev/null
sleep 3
echo "Status 2 8"
echo "Launching murexnet"
./launchmxj.app -mxnet > /dev/null
sleep 3
echo "Status 3 8"
echo "Launching launcherall"
./launchmxj.app -l > /dev/null
sleep 3
echo "Status 4 8"
echo "Launching mxml"
./launchmxj.app -mxml > /dev/null
sleep 3
echo "Status 5 8"
echo "Launching mandatory"
./launchmxj.app -mandatory > /dev/null
sleep 3
echo "Status 6 8"
echo "Launching warehouse"
./launchmxj.app -warehouse > /dev/null
sleep 3
echo "Status 7 8"
echo "Launching Amendment agent"
./launchmxj.app -l /MXJ_CONFIG_FILE:launcheraagent.mxres > /dev/null
echo "Status 8 8"
echo "Services launched!"
exit 0