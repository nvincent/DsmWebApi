using System;
using System.Reflection;
using System.Resources;

[assembly: AssemblyTitle("DsmWebApi.Core")]
[assembly: AssemblyDescription("Set of APIs to access the Core module of a DSM system.")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("Nicolas VINCENT")]
[assembly: AssemblyProduct("DsmWebApi")]
[assembly: AssemblyCopyright("Copyright © Nicolas VINCENT 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: CLSCompliant(true)]

[assembly: NeutralResourcesLanguage("en-US")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
