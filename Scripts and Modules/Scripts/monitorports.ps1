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
$remotewhitelist = @(0)
$processwhitelist = @("ssh-agent", "firefox", "tweetdeck", "thunderbird", "Idle")

$PSStatus.Update("Setting a baseline.")
$baseline = Get-SecOpenPorts
do
{
  $PSStatus.Update("Pausing for 5 seconds")
  Start-Sleep -s 5
  
  $PSStatus.Update("Getting current ports.")
  $active = Get-SecOpenPorts
  
  $rslts = Compare-SecOpenPort $baseline $active
  
  foreach($rslt in $rslts)
  {
    if(($rslt.InputObject.State="ESTABLISHED") -and
        ($rslt.SideIndicator -eq "=>") -and
        ($remotewhitelist -notcontains $rslt.InputObject.RemotePort) -and
        ($processwhitelist -notcontains $rslt.InputObject.ProcessName))
    {
      $protocol = $rslt.InputObject.Protocol
      $local = $rslt.InputObject.LocalAddress + ":" + $rslt.InputObject.LocalPort
      $remote = $rslt.InputObject.RemoteAddress + ":" + $rslt.InputObject.RemotePort
      $pname = $rslt.InputObject.ProcessName
      
      $PSAlert.Add("Port Opened: $protocol $($local)<=>$($remote) ($pname)", 2)
      $baseline += $rslt.InputObject
    }
    if(($rslt.SideIndicator -eq "<=") -and
        ($remotewhitelist -notcontains $rslt.InputObject.RemotePort) -and
        ($processwhitelist -notcontains $rslt.InputObject.ProcessName))
    {
      $protocol = $rslt.InputObject.Protocol
      $local = $rslt.InputObject.LocalAddress + ":" + $rslt.InputObject.LocalPort
      $remote = $rslt.InputObject.RemoteAddress + ":" + $rslt.InputObject.RemotePort
      $pname = $rslt.InputObject.ProcessName
      
      $PSAlert.Add("Port Closed: $protocol $($local)<=>$($remote) ($pname)",0)
      
      # You can't remove items from an array. You have to rebuild it.
      [int]$blidx = 0
      $newbl = @()
      do
      {
        $blobj = $baseline[$blidx]
        if($blobj -ne $rslt.InputObject)
        {
            $newbl += $blobj
        }
        $blidx++
      } while (($blidx -lt $baseline.count))
      $baseline = $newbl
      $newbl = $null
    }
  }
} while ($scan)


#End Script