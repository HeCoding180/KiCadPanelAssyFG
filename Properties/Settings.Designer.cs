﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KiCadPanelAssyFG.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.11.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FootprintDirs {
            get {
                return ((string)(this["FootprintDirs"]));
            }
            set {
                this["FootprintDirs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseSeparatePlacementFiles {
            get {
                return ((bool)(this["UseSeparatePlacementFiles"]));
            }
            set {
                this["UseSeparatePlacementFiles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("252, 36, 228")]
        public global::System.Drawing.Color TopOutlineColor {
            get {
                return ((global::System.Drawing.Color)(this["TopOutlineColor"]));
            }
            set {
                this["TopOutlineColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("38, 233, 255")]
        public global::System.Drawing.Color BottomOutlineColor {
            get {
                return ((global::System.Drawing.Color)(this["BottomOutlineColor"]));
            }
            set {
                this["BottomOutlineColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public int BackgroundOpacity {
            get {
                return ((int)(this["BackgroundOpacity"]));
            }
            set {
                this["BackgroundOpacity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Yellow")]
        public global::System.Drawing.Color SelectionColor {
            get {
                return ((global::System.Drawing.Color)(this["SelectionColor"]));
            }
            set {
                this["SelectionColor"] = value;
            }
        }
    }
}
