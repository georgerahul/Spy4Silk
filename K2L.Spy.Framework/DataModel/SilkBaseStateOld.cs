using K2L.Spy.Framework.Properties;
using SilkTest.Ntf;
using System;
using System.IO;
using System.Threading;

namespace K2L.Spy.Framework.DataModel
{
    //public class SilkBaseStateOld
    //{
    //    #region Singleton

    //    private static readonly Lazy<SilkBaseStateOld> instance
    //        = new Lazy<SilkBaseStateOld>(() => new SilkBaseStateOld());

    //    public static SilkBaseStateOld Instance => instance.Value;

    //    private SilkBaseStateOld()
    //    {
    //        ReadSilkConfig();
    //    }

    //    ~SilkBaseStateOld()
    //    {
    //    }

    //    #endregion Singleton

    //    private Desktop _desktop = null;
    //    private TestObject _application = null;

    //    /// <summary> Provide the BaseState agent. </summary>
    //    internal BaseState BaseState { get; set; }

    //    /// <summary> Provide the Silk desktop agent. </summary>
    //    internal Desktop Desktop
    //    {
    //        get
    //        {
    //            if (_desktop == null || !_desktop.Exists())
    //                _desktop = Agent.Desktop;
    //            return _desktop;
    //        }
    //    }

    //    /// <summary> Provide the Application. </summary>
    //    public TestObject Application
    //    {
    //        get
    //        {
    //            if (_application == null || !_application.Exists())
    //            {
    //                BaseState.Execute();
    //                Thread.Sleep(500);
    //                _application = Desktop.Find(BaseState.Locator);
    //            }
    //            return _application;
    //        }
    //    }

    //    private void ReadSilkConfig()
    //    {
    //        recorderProject silkXml = null;

    //        try
    //        {
    //            System.Xml.Serialization.XmlSerializer xSerializer = new System.Xml.Serialization.XmlSerializer(typeof(recorderProject));

    //            //XDocument myxml = XDocument.Load(@"/K2L.Spy.Framework;component/config.silk4net");
    //            //System.IO.StreamReader stream = new System.IO.StreamReader(@"/K2L.Spy.Viewer;component/config.silk4net");

    //            Stream stream = new MemoryStream(Resources.config);
    //            silkXml = (recorderProject)xSerializer.Deserialize(stream);
    //            stream.Close();

    //            BaseState = new BaseState(silkXml.applicationConfiguration.baseStateInfo.executable,
    //                silkXml.applicationConfiguration.baseStateInfo.locator);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.ToString());
    //        }
    //    }
    //}
}