﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Resources.Areas.Identity.Account {
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
    public class Login {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Login() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("App.Resources.Areas.Identity.Account.Login", typeof(Login).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please Enter Your Login and Password!.
        /// </summary>
        public static string ActionDescription {
            get {
                return ResourceManager.GetString("ActionDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Account Login.
        /// </summary>
        public static string HeadTitle {
            get {
                return ResourceManager.GetString("HeadTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login.
        /// </summary>
        public static string LoginButton {
            get {
                return ResourceManager.GetString("LoginButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login.
        /// </summary>
        public static string LoginTitle {
            get {
                return ResourceManager.GetString("LoginTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Don&apos;t Have an Account?.
        /// </summary>
        public static string NewAccountAction {
            get {
                return ResourceManager.GetString("NewAccountAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password.
        /// </summary>
        public static string PasswordPlaceholder {
            get {
                return ResourceManager.GetString("PasswordPlaceholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sign Up.
        /// </summary>
        public static string SingUp {
            get {
                return ResourceManager.GetString("SingUp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username.
        /// </summary>
        public static string UsernamePlaceholder {
            get {
                return ResourceManager.GetString("UsernamePlaceholder", resourceCulture);
            }
        }
    }
}