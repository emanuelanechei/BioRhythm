using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Ssepan.Application;
using Ssepan.Application.WinForms;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("BioRhythm")]
[assembly: AssemblyDescription("BioRhythm generator for .Net.\n\nEd Sepan deserves credit for:\n~ tracking down a suitable biorhythm algorithm\n~ coding the original implementation in QBasic\n\nSteve Sepan takes credit for:\n~ porting the original implementation to VB3\n~ porting the VB implementation to C#.Net")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Free Software Foundation, Inc.")]
[assembly: AssemblyProduct("BioRhythm")]
[assembly: AssemblyCopyright("Copyright (C) 1989, 1991 Free Software Foundation, Inc.  \n59 Temple Place - Suite 330, Boston, MA  02111-1307, USA")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("1345afe2-0e36-4614-9afa-980b319535b1")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("3.16")]

#region " Helper class to get information for the About form. "
/// <summary>
/// This class uses the System.Reflection.Assembly class to
/// access assembly meta-data
/// This class is ! a normal feature of AssemblyInfo.cs
/// </summary>
public class AssemblyInfo : 
    AssemblyInfoBase
{
    // Used by Helper Functions to access information from Assembly Attributes
    public AssemblyInfo()
    {
        base.myType = typeof(BioRhythm.BioRhythmViewer);
    }
}
#endregion
