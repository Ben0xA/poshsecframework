<#
.DESCRIPTION
This script is for active monitoring of ports on a specified machine.

.FRAMEWORK
PoshSec Framework

.FRAMEWORKVERSION
0.2.0.0

.AUTHOR
Ben0xA
#>

# Begin Script Flow
Import-Module $PSFramework

[boolean]$scan = $True;
$baseline = @()
$active = @()

$PSStatus.Update("Setting a baseline.")
$baseline = Get-SecOpenPorts

do
{
  $PSStatus.Update("Pausing for 5 seconds")
  Start-Sleep -s 5
  
  $PSStatus.Update("Getting current ports.")
  $active = Get-SecOpenPorts
  
  $rslts = Compare-Object $baseline $active
  
  $rslts = $rslts | Where-Object { $_.SideIndicator -eq '=>' }
  
  foreach($rslt in $rslts)
  {
    if($rslt.InputObject.State="ESTABLISHED")
    {
      $protocol = $rslt.InputObject.Protocol
      $rport = $rslt.InputObject.RemotePort
      $pname = $rslt.InputObject.ProcessName
      $PSAlert.Add("New port detected. $protocol/$rport ($pname)", 2)
    }  
  }
} while ($scan)


#End Script