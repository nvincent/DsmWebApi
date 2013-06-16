using System;
using System.Reflection;
using System.Resources;

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

#if !NETFX_CORE
[assembly: CLSCompliant(true)]
#endif

[assembly: NeutralResourcesLanguage("en-US")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
