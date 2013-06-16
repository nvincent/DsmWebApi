To build the project, you need a code signing key called DsmWebApi.snk in this directory.

To create this file, you can either :

- Use the command line (part of the Windows SDK, use Visual Studio's Developer Command Prompt) :

sn.exe -k DsmWebApi.snk

- Or, in PowerShell :

. .\Create-DsmWebApiSnk.ps1
Create-DsmWebApiSnk
