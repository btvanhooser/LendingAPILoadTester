﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LendingAPILoadTester.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LendingAPILoadTester.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	&quot;username&quot;: &quot;{{Username}}&quot;,
        ///	&quot;password&quot;: &quot;{{Password}}&quot;
        ///}.
        /// </summary>
        internal static string auth {
            get {
                return ResourceManager.GetString("auth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	&quot;id&quot;:        &quot;{{id}}&quot;,
        ///	&quot;firstname&quot;: &quot;{{Firstname}}&quot;,
        ///	&quot;lastname&quot;:  &quot;{{Lastname}}&quot;,
        ///	&quot;ssn&quot;:       {{SSN}},
        ///	&quot;employer&quot;:  &quot;{{Employer}}&quot;,
        ///	&quot;income&quot;:    {{Income}},
        ///	&quot;incomeFrequency&quot;: &quot;{{IncomeFrequency}}&quot;,
        ///	&quot;requestedAmount&quot;: {{Amount}},
        ///	&quot;requestedTerm&quot;:   {{Term}},
        ///	&quot;phoneNumber&quot;:     &quot;{{Phone}}&quot;,
        ///	&quot;emailAddress&quot;:    &quot;{{Email}}&quot;,
        ///	&quot;isBranchEmployee&quot;:&quot;{{IsBranchEmployee}}&quot;,
        ///	&quot;employeeID&quot;:      {{EmployeeID}},
        ///	&quot;lendercode&quot;:      &quot;{{Lendercode}}&quot;,
        ///	&quot;status&quot;:          &quot;{{Status}}&quot;
        ///}.
        /// </summary>
        internal static string SaveApplication {
            get {
                return ResourceManager.GetString("SaveApplication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	&quot;firstname&quot;: &quot;{{Firstname}}&quot;,
        ///	&quot;lastname&quot;:  &quot;{{Lastname}}&quot;,
        ///	&quot;ssn&quot;:       {{SSN}},
        ///	&quot;employer&quot;:  &quot;{{Employer}}&quot;,
        ///	&quot;income&quot;:    {{Income}},
        ///	&quot;incomeFrequency&quot;: &quot;{{IncomeFrequency}}&quot;,
        ///	&quot;requestedAmount&quot;: {{Amount}},
        ///	&quot;requestedTerm&quot;:   {{Term}},
        ///	&quot;phoneNumber&quot;:     &quot;{{Phone}}&quot;,
        ///	&quot;emailAddress&quot;:    &quot;{{Email}}&quot;,
        ///	&quot;isBranchEmployee&quot;:&quot;{{IsBranchEmployee}}&quot;,
        ///	&quot;employeeID&quot;:      {{EmployeeID}},
        ///	&quot;lendercode&quot;:      &quot;{{Lendercode}}&quot;
        ///}.
        /// </summary>
        internal static string SubmitApplication {
            get {
                return ResourceManager.GetString("SubmitApplication", resourceCulture);
            }
        }
    }
}