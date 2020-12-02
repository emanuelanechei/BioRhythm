BioRhythm v3.15

Purpose:
To let the user create biorhythm graphs for viewing, printing, or copying. 
Also demonstrates my interpretation of the Model-View-Controller pattern. The BioRhythm class acts as the Model, the main form as the View, and the usually under-used Program class as the Controller. 


Usage notes:

~The user sets the properties for their birthday and optional offset date. The tool then generates a graph of the user's biorhythm for the present or selected date. The graph consists of 3 plots for emotion, physique, and intellect, as well as a 4th plot for the average. 
~The settings can be saved in XML format, with either an .XML or .BIORHYTHM (default) extension.


Enhancements:

3.15: (RELEASED)
~Handler in Program.cs was not wired up in forms or console; added 'PropertyChanged += PropertyChangedEventHandlerDelegate;' to Main.
~No handler wired up to Settings in forms or console. Renamed 'PropertyChangedEventHandlerDelegate' to 'ModelPropertyChangedEventHandlerDelegate'. Wired up latter in 'InitViewModel' after model handler in view. Currently handling 'Dirty' property.
~Added 'SettingsPropertyChangedEventHandlerDelegate' to new static property 'DefaultHandler' in SettingsController. 
~Modified OnPropertyChanged in SettingsBase to fire OnChanged for 'Dirty' when property name is not 'Dirty'.
~Fixed bug in GetPathForSave in Ssepan.Io where SaveAs did not display dialog for '(new)'.
~TODO:Modified Settings in Ssepan.Application to implement part of it interfaces as a new interface ISettingsComponent, and implemented an example as a property SomeComponent which copies the PropertyChanged handlers from settings and implements its own Equals, Dirty, CopyTo, Sync, etc, so Settings does not need to know the details.

3.14: 
~Refactored to use new MVVM / MVC hybrid.
~Updated Ssepan.* to 2.6
~Fixed progress bar and status message logic.
~Fixed problem with Model not being instantiated before View form move tries to access it and trigger a Refresh.
~Moved CalculateCurve, CalculatePoint to controller and made private
~Deprecated use of NPlot, and replaced with DataVisualization library.

3.13: 
~Refactored Settings / SettingsController, and their bases in Ssepan.Application, to put the static Settings property into the Settings class instead of the SettingsController class. This will make Settings more like SettingsController and the model / controller classes, and hopefully make Settings easier to understand and maintain.
~Projects are using .Net Framework 4.0.
~Using version 2.0 of Ssepan.* libraries, all of which are using .Net Framework 3.5.

3.12:
~Refactor image resources.

3.11:
~Added missing error display to Clipboard menu function.
~Refactor UI File IO logic in menu events to eliminate duplication.
~Refactored IEquality implementation.
~Modified Sepan.Application to include _ValueChanging flag from sub-class, and to check and set it from the Controller base class Refresh method.

3.10:
~Moved common portions of settings I/O into base classes in Ssepan.Application library.

3.9:
~Fixed missing display of errors in Catch in model controller, settings.

3.8:
~Fixed field initialization of File|New, File|Open.

3.7:
~Refactored <appnamespace>.frmAbout to Ssepan.Application.WinForms.AboutDialog.
~Refactored Ssepan.Configuration.PropertiesViewer to Ssepan.Application.WinForms.PropertyDialog.

3.6:
~Clean up solution structure and setup project details.

3.5:
~More Internal refactoring -- retro-fitting calls to additional common libraries (Ssepan.Io, Ssepan.Configuration).
~Using simple databinding more, and relying on MVC observer notifications only where necessary.

3.4:
~Internal refactoring -- cleaned up settings logic.

3.3:
~Updated library for event logging, to proved better description of its own config file warning.

3.2:
~Added library implementation of design-pattern support classes.

3.1:
~Upgraded project to Visual Studio 2008.
~Compiled project against .Net 3.5.
~Added error handling.
~Add distinctive namespace ...
~Implemented standard return-value handling.
~Implemented error logging.

3.0:
~Re-written from scratch in C#.Net and Visual Studio 2005, and distributed as open-source.
~Core biorhythm algorithms preserved and converted.
~NPlot open-source graphing engine used.
~Model-View-Controller design pattern used.
~PropertyGrid control used in conjunction with Settings class.
~Open/Save dialogs now default to MyDocuments.
~App now checks for file association (.biorhythm) on start-up, and creates if necessary. (This may eventually become an option.)
~App now checks for single filename in command line arguments, and opens if present. 


1.0 .. 2.0:
~Legacy app written in VB1..VB6, and distributed under PorchView Software logo as shareware.

Fixes:
~Fixed chart resize bug; control was retaining design size on app start. Used databinding after InitializeComponent() by calling BindSizeAndLocation().
~Re-applied feature to use .BIORHYTHM extension. (Lost code when reverting to older copy to squash bug in solution file that caused VS to crash when opening project.) Fixed: 2/23/2007, SJS.
~Fixed bug that caused exception when user performs following sequence: Choose File|Open, cancel Open dialog, move or resize form. Program was setting ReferenceSettings to null when dialog was cancelled. Changed code to make no change to ReferenceSettings instead. Fixed: 2/23/2007, SJS.
~Added missing display of error message in Copy To Clipboard function.

Known Issues:
~Filename passed in command line argument is converted/passed in DOS 8.3 equivalent format. Cannot compare file extension directly. Status: research. 
~Running this app under Vista or Windows 7 requires that the library that writes to the event log (Ssepan.Utility.dll) have its name added to the list of allowed 'sources'. Rather than do it manually, the one way to be sure to get it right is to simply run the application the first time As Administrator, and the settings will be added. After that you may run it normally. To register additional DLLs for the event log, you can use this trick any time you get an error indicating that you cannot write to it. Or you can manually register DLLs by adding a key called '<filename>.dll' under HKLM\System\CurrentControlSet\services\eventlog\Application\, and adding the string value 'EventMessageFile' with the value like <C>:\<Windows>\Microsoft.NET\Framework\v2.0.50727\EventLogMessages.dll (where the drive letter and Windows folder match your system). Status: work-around. 

Possible Enhancements:
~n/a


Steve Sepan
ssepanus@yahoo.com
5/23/2014