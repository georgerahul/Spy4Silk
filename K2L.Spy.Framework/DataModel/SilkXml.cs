namespace K2L.Spy.Framework.DataModel
{// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
 /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class recorderProject
    {
        private recorderProjectApplicationConfiguration applicationConfigurationField;

        private recorderProjectEntry[] agentOptionsField;

        private decimal versionField;

        /// <remarks/>
        public recorderProjectApplicationConfiguration applicationConfiguration
        {
            get
            {
                return this.applicationConfigurationField;
            }
            set
            {
                this.applicationConfigurationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("entry", IsNullable = false)]
        public recorderProjectEntry[] agentOptions
        {
            get
            {
                return this.agentOptionsField;
            }
            set
            {
                this.agentOptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class recorderProjectApplicationConfiguration
    {
        private string moduleNamePatternField;

        private recorderProjectApplicationConfigurationBaseStateInfo baseStateInfoField;

        /// <remarks/>
        public string moduleNamePattern
        {
            get
            {
                return this.moduleNamePatternField;
            }
            set
            {
                this.moduleNamePatternField = value;
            }
        }

        /// <remarks/>
        public recorderProjectApplicationConfigurationBaseStateInfo baseStateInfo
        {
            get
            {
                return this.baseStateInfoField;
            }
            set
            {
                this.baseStateInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class recorderProjectApplicationConfigurationBaseStateInfo
    {
        private string executableField;

        private string workingDirectoryField;

        private string locatorField;

        /// <remarks/>
        public string executable
        {
            get
            {
                return this.executableField;
            }
            set
            {
                this.executableField = value;
            }
        }

        /// <remarks/>
        public string workingDirectory
        {
            get
            {
                return this.workingDirectoryField;
            }
            set
            {
                this.workingDirectoryField = value;
            }
        }

        /// <remarks/>
        public string locator
        {
            get
            {
                return this.locatorField;
            }
            set
            {
                this.locatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class recorderProjectEntry
    {
        private string stringField;

        private bool booleanField;

        private bool booleanFieldSpecified;

        private uint intField;

        private bool intFieldSpecified;

        /// <remarks/>
        public string @string
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }

        /// <remarks/>
        public bool boolean
        {
            get
            {
                return this.booleanField;
            }
            set
            {
                this.booleanField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool booleanSpecified
        {
            get
            {
                return this.booleanFieldSpecified;
            }
            set
            {
                this.booleanFieldSpecified = value;
            }
        }

        /// <remarks/>
        public uint @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intSpecified
        {
            get
            {
                return this.intFieldSpecified;
            }
            set
            {
                this.intFieldSpecified = value;
            }
        }
    }
}