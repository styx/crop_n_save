using System.Reflection;
using System.Runtime.CompilerServices;
using Mono.Addins;

[assembly: Addin("crop_n_save", "1.0", Category = "Other")]
[assembly: AddinName ("Save selection as crop")]
[assembly: AddinDescription ("Saves the selected pixels to the file without any Q!")]
[assembly: AddinDependency ("Pinta", "1.5")]

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("crop_n_save")]
[assembly: AssemblyDescription("Plugin for Pinta")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("by.styx")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("styx")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.*")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
