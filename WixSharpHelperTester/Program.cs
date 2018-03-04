using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIXSharpHelper;
using WixSharpScriptBuilder;
using System.Windows.Forms;
/*********************************************************************************************************************************
Copyright and Licensing Message

This code is copyright 2018 Gary Cole Jr. 

This code is licensed by Gary Cole to others under the GPLv.3 https://opensource.org/licenses/GPL-3.0 
If you find the code useful or just feel generous a donation is appreciated.

Donate with this link: paypal.me/GColeJr
Please choose Friends and Family

Alternative Licensing Options

If you prefer to license under the LGPL for a project, https://opensource.org/licenses/LGPL-3.0
Single Developers working on their own project can do so with a donation of $20 or more. 
Small and medium companies can do so with a donation of $50 or more. 
Corporations can do so with a donation of $1000 or more.


If you prefer to license under the MS-RL for a project, https://opensource.org/licenses/MS-RL
Single Developers working on their own project can do so with a donation of $40 or more. 
Small and medium companies can do so with a donation of $100 or more.
Corporations can do so with a donation of $2000 or more.


if you prefer to license under the MS-PL for a project, https://opensource.org/licenses/MS-PL
Single Developers working on their own project can do so with a donation of $1000 or more. 
Small and medium companies can do so with a donation of $2000 or more.
Corporations can do so with a donation of $10000 or more.


If you use the code in more than one project, a separate license is required for each project.


Any modifications to this code must retain this message. 
*************************************************************************************************************************************/
namespace WixSharpHelperTester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            WIXSharpProject project = new WIXSharpProject("My Company", "My Great APP");
            Feature helpfiles = new Feature("helpfiles","Helpfiles");
            project.AddSourceFile(@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\mygreatapplibrary\mygreatapp\bin\Release\mygreatapp.exe", true, true, false);
            project.SetLicenseFile(@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\WixSharp Setup1\WixSharp Setup1\license.rtf");
            project.AddSourceFile(helpfiles,@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\WixSharp Setup1\WixSharp Setup1\Helpfulstuff.doc", @"APPROOT\HELPFUL");
            project.AddSourceFile(new FirewallException("somedll","198.121.2.1,127.0.0.1"), @"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\mygreatapplibrary\mygreatapp\bin\Release\somedll.dll", @"APPROOT\DLL");
            project.AddSourceFile(@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\mygreatapplibrary\mygreatapp\bin\Release\anotherdll.dll");
            project.AddSourceFile(@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\mygreatapplibrary\mygreatapp\bin\Release\onemoredll.dll");
            project.AddSourceFile(@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\mygreatapplibrary\mygreatapp\bin\Release\trs120.dll","SystemFolder");
            project.SetMinimumNetVersion("NOT WIX_IS_NETFRAMEWORK_452_OR_LATER_INSTALLED");
            project.NetVersionToInstall("NetFx461Web");
            project.SetSignIntaller(@"c:\certificate.pfx", "certpassword", "http://timestamp.globalsign.com/?signature=sha2", "/fd sha256");
            project.SetApplicationIcon(@"C:\Users\Downstairs Computer\Documents\Visual Studio 2015\Projects\helpwriterlibrary\HelpWriter\Icons\Help.ico");
            project.SetPublisherLink(@"http://www.mydomain.com");
            project.AddCertificate("Certificate", @"c:/mycertificate.pfx");
            project.AddCertificate("Certificate2", @"c:/mycert2.pfx");
            project.AddEnvironmentVariable("My_Great_App_Dir");
            project.AddEnvironmentVariable("Path", "[INSTALLDIR]", "EnvVarPart.last", "Condition.Installed");
            project.SetOptionalDesktopShortcut(true);
            project.AddUser("Gary", "password1234");
            project.AddUser("Gary2", "password3242");
            project.AddElement("SomeElement", "AnID", "A Value");
            project.AddElement("ANotherElement", "ID23", "Value2");
            Element el3 = new Element("AthirdElement", "3232", "32d2");
            el3.SetTitle("This is a title");
            el3.AddCustomElement("CustomLabel", "4324");
            el3.SetAssignGuid();            
            project.AddElement(el3);
            project.AddFileAssociation(new FileAssociation("myg"));
            project.AddFirewallException("mygreatapp", "127.0.0.1", "8080");
            project.AddRegistryValue(RegistryHive.CurrentUser, @"MyCompany/MyGreatApp", "Key", "3422032-3234342-422432-32123");
            project.AddRegistryValue(RegistryHive.CurrentUser, @"MyCompany/MyGreatApp", "num", 1);
            project.AddRegistryValue(RegistryHive.CurrentUser, @"MyCompany/MyGreatApp", "char", 'a');
            project.AddRegistryValue(RegistryHive.CurrentUser, @"MyCompany/MyGreatApp", "bool", true);
            project.SetBuild64(true);
            project.SetPromptReboot(true);
            WixSharpScript script = new WixSharpScript(project);

            Console.WriteLine(script.GetMSIScript());
            Console.WriteLine(project.GetSourceFiles().GetMainSubdirectories().Count);
            
            Clipboard.SetText(script.GetMSIScript());
            string scr = script.GetMSIScript();

        }
    }

}

