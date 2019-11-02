using SilkTest.Ntf;

namespace K2L.Spy.Framework.DataModel
{
    public class SilkBaseState
    {
        public SilkBaseState(string exec, string workDir, string locator)
        {
            Executable = exec;
            WorkingDirectory = workDir;
            Locator = locator;
        }

        private string executableField;

        private string workingDirectoryField;

        private string locatorField;

        /// <remarks/>
        public string Executable
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
        public string WorkingDirectory
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
        public string Locator
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

        public override string ToString()
        {
            return Locator;
        }
    }

    public class DesktopBaseState : SilkBaseState
    {
        public DesktopBaseState(TestObject application) : base(null, null, application.GenerateLocator())
        {
            Application = application;
        }

        public DesktopBaseState(string locator) : base(null, null, locator) { }

        private TestObject _application;

        public TestObject Application
        {
            get { return _application; }
            set
            {
                _application = value;
            }
        }

        //public override string ToString()
        //{
        //    return Locator;
        //    //return Application.GenerateLocator();
        //    //return Application.Text;
        //}
    }
}