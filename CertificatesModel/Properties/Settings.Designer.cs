﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CertificatesModel.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Alfa\\06 - метрологическая служба\\Метрология\\База\\MetrologyDB.sdf")]
        public string DataBasePath {
            get {
                return ((string)(this["DataBasePath"]));
            }
            set {
                this["DataBasePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Alfa\\06 - метрологическая служба\\Метрология\\Метрология")]
        public string CertificatesFolderPath {
            get {
                return ((string)(this["CertificatesFolderPath"]));
            }
            set {
                this["CertificatesFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Alfa\\06 - метрологическая служба\\Метрология\\Служба главного метролога\\Метрологи" +
            "я")]
        public string CertificatesZipFolderPath {
            get {
                return ((string)(this["CertificatesZipFolderPath"]));
            }
            set {
                this["CertificatesZipFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoPreviewEnabled {
            get {
                return ((bool)(this["AutoPreviewEnabled"]));
            }
            set {
                this["AutoPreviewEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SaveUserCredential {
            get {
                return ((bool)(this["SaveUserCredential"]));
            }
            set {
                this["SaveUserCredential"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserLogin {
            get {
                return ((string)(this["UserLogin"]));
            }
            set {
                this["UserLogin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserPassword {
            get {
                return ((string)(this["UserPassword"]));
            }
            set {
                this["UserPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Alfa\\06 - метрологическая служба\\Метрология\\Метрология\\Методики Поверки")]
        public string VerificationMethodFolder {
            get {
                return ((string)(this["VerificationMethodFolder"]));
            }
            set {
                this["VerificationMethodFolder"] = value;
            }
        }
    }
}
