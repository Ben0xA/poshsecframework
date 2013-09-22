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
  
  $rslts = Compare-SecOpenPort $baseline $active
  $rslts = $rslts | Where-Object { $_.SideIndicator -eq '=>' }
  
  foreach($rslt in $rslts)
  {
    if($rslt.InputObject.State="ESTABLISHED")
    {
      $protocol = $rslt.InputObject.Protocol
      $local = $rslt.InputObject.LocalAddress + ":" + $rslt.InputObject.LocalPort
      $remote = $rslt.InputObject.RemoteAddress + ":" + $rslt.InputObject.RemotePort
      $pname = $rslt.InputObject.ProcessName
      
      $PSAlert.Add("New port detected. $protocol $($local)<=>$($remote) ($pname)", 3)
      $baseline += $rslt
    }  
  }
} while ($scan)


#End Script