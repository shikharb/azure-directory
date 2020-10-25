if ($PSVersionTable.PSEdition -eq 'Desktop' -and (Get-Module -Name AzureRM -ListAvailable)) {
    Write-Warning -Message ('Az module not installed. Having both the AzureRM and ' +
      'Az modules installed at the same time is not supported. ' +
      'Recommend uninstalling Azure Powershell from the computer before installing new Az Modules.')
} else {
    Install-Module -Name Az -AllowClobber -Scope CurrentUser
}