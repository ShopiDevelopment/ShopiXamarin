﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopiXamarin.Resource {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResource {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResource() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("ShopiXamarin.Resource.AppResource", typeof(AppResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string OK {
            get {
                return ResourceManager.GetString("OK", resourceCulture);
            }
        }
        
        internal static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        internal static string Error {
            get {
                return ResourceManager.GetString("Error", resourceCulture);
            }
        }
        
        internal static string GenericErrorText {
            get {
                return ResourceManager.GetString("GenericErrorText", resourceCulture);
            }
        }
        
        internal static string Home {
            get {
                return ResourceManager.GetString("Home", resourceCulture);
            }
        }
        
        internal static string ShoppingBag {
            get {
                return ResourceManager.GetString("ShoppingBag", resourceCulture);
            }
        }
        
        internal static string Profile {
            get {
                return ResourceManager.GetString("Profile", resourceCulture);
            }
        }
        
        internal static string WelcomeText {
            get {
                return ResourceManager.GetString("WelcomeText", resourceCulture);
            }
        }
        
        internal static string EmailCanNotBeEmpty {
            get {
                return ResourceManager.GetString("EmailCanNotBeEmpty", resourceCulture);
            }
        }
        
        internal static string EmailIsNotValid {
            get {
                return ResourceManager.GetString("EmailIsNotValid", resourceCulture);
            }
        }
        
        internal static string PasswordCanNotBeEmpty {
            get {
                return ResourceManager.GetString("PasswordCanNotBeEmpty", resourceCulture);
            }
        }
    }
}
