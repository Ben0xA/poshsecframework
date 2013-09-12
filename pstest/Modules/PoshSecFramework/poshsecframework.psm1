Get-ChildItem $PSScriptRoot | ? { $_.PSIsContainer -and $_.Name -ne "PoshSec.PowerShell.Commands" } | % { Import-Module $_.FullName }
Import-Module $PSScriptRoot\PoshSec.PowerShell.Commands\PoshSec.PowerShell.Commands\bin\Debug\PoshSec.PowerShell.Commands.dll

#List Custom Modules Here
Import-Module $PSModRoot\getdrives.psm1