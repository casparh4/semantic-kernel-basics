using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UsingSemanticKernelFromNET
{
    internal class UserPlugin
    {
        [KernelFunction]
        [Description("get information about the current user: ")]
        public string UserInformation()
        {
            return "Address: Southwell Nottinghamshire, Bank Balance: £2500 Name: Caspar Huntley, Interests: programming, xbox Pets: dog, cat";
        }
    }
}
