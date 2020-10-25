# Reference (Azure Connection): https://docs.microsoft.com/en-us/powershell/module/az.accounts/connect-azaccount?view=azps-4.6.1
# Reference (Create Resource Group): https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/new-azurermresourcegroup?view=azurermps-6.13.0

Write-Host 'First connect to your Azure account...'
$Tenant = Read-Host -Prompt 'Azure TenantId '
$SubscriptionId = Read-Host -Prompt 'Azure SubscriptionId '
Write-Host 'Continuing to connect you to your Azure account...'
Connect-AzAccount -Tenant $Tenant -SubscriptionId $SubscriptionId

Write-Host
Write-Host 'Starting creation of Resource Group...'
$Name = Read-Host 'Resource Group Name '
$Location = Read-Host 'Resource Group Location '
Write-Host 'Attempting to create Resource Group $Name in $Location...'
New-AzResourceGroup -Name $Name -Location $Location
Write-Host 'Finished attempting to create your Resource Group!'