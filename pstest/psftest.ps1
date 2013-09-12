<#
.DESCRIPTION
Tests the import function for the PoshSec Framework.

.AUTHOR
Ben0xA
#>

# Begin Script Flow
Import-Module $PSFramework

Write-Output "Here is a listing of all PoshSecFramework commands:"
Get-Command -Module PoshSecFramework | Out-String
$PSMessageBox.Show("The psftest script is complete.", "My super awesome script!")
$PSAlert.Add("This is an alert that will show up in the GUI.", "Severe")
#End Script