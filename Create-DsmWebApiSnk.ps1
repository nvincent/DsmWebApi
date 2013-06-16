function Create-DsmWebApiSnk
{
<#
.SYNOPSIS
  Creates a code signing key (.snk)
.DESCRIPTION
  The projects in the DsmWebApi.sln solution need a code signing key named DsmWebApi.snk in the same directory as the solution to build.
  This function creates this key file.
.EXAMPLE
  Creates the signing key file in the current directory :
  Create-DsmWebApiSnk
#>

    Push-Location
    cd "HKLM:\SOFTWARE\Microsoft\Microsoft SDKs\Windows"
    $windowsSdkFolders = Get-ChildItem `
        | Sort-Object -Descending { $_.Name } `
        | Foreach-Object { ($_ | Get-ItemProperty -Name InstallationFolder).InstallationFolder }
    Pop-Location

    $snExePaths = $windowsSdkFolders `
        | ForEach-Object { Join-Path $_ "bin\sn.exe" } `
        | Where-Object { Test-Path $_ }
    $selectedSnExe = $snExePaths | Select-Object -First 1
    &$selectedSnExe -k DsmWebApi.snk
}
