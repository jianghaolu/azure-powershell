﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using System;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Gets the available Microsoft Azure environments.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureEnvironment"), OutputType(typeof(PSAzureEnvironment))]
    public class GetAzureEnvironmentCommand : SubscriptionCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The environment name")]
        public string Name { get; set; }

        public GetAzureEnvironmentCommand() : base(false) { }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            List<PSAzureEnvironment> environments = ProfileClient.ListEnvironments(Name).Select((e) => (PSAzureEnvironment)e).ToList();
            WriteObject(environments, true);
        }
    }
}