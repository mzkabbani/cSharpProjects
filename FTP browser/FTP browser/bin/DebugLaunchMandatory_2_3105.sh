#EM v3.1.* 0 1063985
#EMDESC This script launches the MX services that are needed to be able to launch an MX session.
#!/bin/bash

echo "Status 0 7"
echo "Launching FileServer"
./launchmxj.app -fs > /dev/null
sleep 3
echo "Status 1 7"
echo "Launching xmls"
./launchmxj.app -xmls > /dev/null
sleep 3
echo "Status 2 7"
echo "Launching murexnet"
./launchmxj.app -mxnet > /dev/null
sleep 3
echo "Status 3 7"
echo "Launching launcherall"
./launchmxj.app -l > /dev/null
sleep 3
echo "Status 4 7"
echo "Launching mxml"
./launchmxj.app -mxml > /dev/null
echo "Status 5 7"
echo "Launching mandatory"
./launchmxj.app -mandatory > /dev/null
sleep 3
echo "Status 6 7"
echo "Launching mandatory"
./launchmxj.app -warehouse > /dev/null
echo "Status 7 7"
echo "Services launched!"
exit 0