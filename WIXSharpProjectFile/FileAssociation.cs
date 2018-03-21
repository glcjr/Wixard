using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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
namespace WIXSharpHelper
{
    [Serializable]
    public class FileAssociation : ISerializable, IComparable<FileAssociation>
    {
        private string Extension = "";
        private string ContentType = "";
        private string Command = "Open";
        private string CommandArguments = @"\""%1\""";

        public FileAssociation()
        { }
        public FileAssociation(string extension, string contentype=null, string command="Open", string commandarguments= @"\""%1\""")
        {
            Extension = extension;
            if (contentype == null)
                ContentType = $@"application/{extension}";
            else
                ContentType = contentype;
            Command = command;
            CommandArguments = commandarguments;
        }
        public string GetLine()
        {
            string temp = $",{Environment.NewLine} new FileAssociation(\"{Extension}\"";
            if (!(CommandArguments.Equals(@"\""%1\""")))
                temp += $",\"{ContentType}\",\"{Command}\", \"{CommandArguments}\"";
            else if (!(Command.Equals("Open")))
            {
                temp += $",\"{ContentType}\",\"{Command}\"";
            }
            temp += ")";
            return temp;
        }
        public FileAssociation(SerializationInfo info, StreamingContext ctxt)
        {
            this.Extension = (string)info.GetValue("Extension", typeof(string));
            this.ContentType = (string)info.GetValue("ContentType", typeof(string));
            this.Command = (string)info.GetValue("Command", typeof(string));
            this.CommandArguments = (string)info.GetValue("CommandArguments", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Extension", this.Extension, typeof(string));
            info.AddValue("ContentType", this.ContentType, typeof(string));
            info.AddValue("Command", this.Command, typeof(string));
            info.AddValue("CommandArguments", this.CommandArguments, typeof(string));
        }

        public int CompareTo(FileAssociation other)
        {
            if (Extension != other.GetExtension())
                return Extension.CompareTo(other.GetExtension());
            else if (ContentType != other.GetContentType())
                return ContentType.CompareTo(other.GetContentType());
            else if (Command != other.GetCommand())
                return Command.CompareTo(other.GetCommand());
            else if (CommandArguments != other.GetCommandArguments())
                return CommandArguments.CompareTo(other.GetCommandArguments());
            else
                return 0;
        }

        public string GetExtension()
        {
            return Extension;
        }

        public string GetContentType()
        {
            return ContentType;
        }

        public string GetCommand()
        {
            return Command;
        }

        public string GetCommandArguments()
        {
            return CommandArguments;
        }

        public void setExtension(string value)
        {
            Extension = value;
        }

        public void setContentType(string value)
        {
            ContentType = value;
        }
        public void setCommand(string value)
        {
            Command = value;
        }

        public void setCommandArguments(string value)
        {
            CommandArguments = value;
        }
        public override string ToString()
        {
            return $"{Extension}";
        }
    }
}
