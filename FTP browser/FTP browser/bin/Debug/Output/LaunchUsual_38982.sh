#EM v3.1.* 0 10000000
#EMDESC This script launches the MX services that are needed to be able to launch an MX session, plus some common services.
#!/bin/bash
#mandatory services

array=(fs xmls mxnet l mandatory warehouse mxml launcheraagent)
i=1
echo "Status 0 16"
echo "Launching FileServer"
./launchmxj.app -fs > /dev/null
sleep 3
while [ $i -lt 7 ]; do	
	echo "Status $i 16"
	echo "Launching ${array[$i]}"
	./launchmxj.app -${array[$i]} > /dev/null
	sleep 3
	let i++	
done
echo "Status 7 16"
echo "Launching Amendment agent"
./launchmxj.app -l /MXJ_CONFIG_FILE:launcheraagent.mxres > /dev/null
sleep 3
echo "Launching mxhibernate"
./launchmxj.app -mxhibernate > /dev/null
sleep 3
#usual services
array2=(mxcontribution mxrepository mxcache ireporting mxactivityfeeders common guiclient)
let i=0
let k=8
let len=${#array2[*]}
while [ $i -lt $len ]; do
	echo "Status $k 16"
	echo "Launching ${array2[$i]}"
	./launchmxj.app -l /MXJ_CONFIG_FILE:public.mxres.common.launcher${array2[$i]}.mxres > /dev/null
	sleep 3
	let i++	
	let k++
done
echo "Status 16 16"
echo "All services launched!"