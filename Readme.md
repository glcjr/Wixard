**Wixard**

A GUI for the WixSharp that creates installers with the help of the Wix Toolset. WixSharp is a project by Oleg Shilo https://github.com/oleg-shilo/wixsharp

With Wixard you use a GUI ti add the necessary files to your Setup. It then creates a C# script based on what you entered. 

It can then compile the script. When the editor is opened, it will download the latest versions of the WixToolset and WixSharp from Nuget to prepare for compiling unless there is a local copy and an environmental variable is set. This can be done by selecting to download a permanent copy. Or the location can be set locally manually by opening up the options.

It can create MSI, Wix files, or a Bootstrapper exe with the help of WixSharp.

For the editor it uses **AvalonEdit** https://github.com/icsharpcode/AvalonEdit

For the compiler it uses my **EasyCompiler**. It needs to be downloaded from my repository in order to compile the Wixard project.

It also uses my **DownloadNuget** project. It also needs to be downloaded from its resository as well. Both source files are linked into Wixard by Visual Studio from their location on my computer. So you'll need to update that.

You can see more information on the Wiki with screenshots.

Latest release is under releases.

If you find the application helpful, a donation would be appreciated.
Donate with this link: paypal.me/GColeJr
Please choose Friends and Family