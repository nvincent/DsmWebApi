function Publish-DsmWebApiRelease
{
<#
.SYNOPSIS
  Publishes the NuGet packages created by the Build-DsmWebApiRelease command
.DESCRIPTION
  Publishes the NuGet packages to nuget.org
.PARAMETER Version
  Version of the project to publish
.PARAMETER SourcesDir
  Root sources directory
.PARAMETER OutDir
  Output directory of the build
.EXAMPLE
  Buils :
  Build-DsmWebApiRelease
#>
    param([parameter(Mandatory = $true)][string]$Version
         ,[parameter(Mandatory = $true)][string]$SourcesDir
         ,[parameter(Mandatory = $true)][string]$OutDir
         )

    # Expand paths
    $SourcesDir = Resolve-Path $SourcesDir
    $OutDir = Resolve-Path $OutDir

    # Get NuGet.exe
    $nuget = Join-Path $SourcesDir ".nuget\NuGet.exe"

    $packagesDir = Join-Path $OutDir "NuGet"
    $packages = Get-ChildItem $packagesDir `
        | ForEach-Object { $_.FullName } `
        | Where-Object { $_ -like "*.$Version.nupkg" }
    $packages | ForEach-Object {
        &$nuget push $_
    }
}
