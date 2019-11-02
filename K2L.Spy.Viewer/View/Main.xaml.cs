using DevExpress.Xpf.Ribbon;
using K2L.Spy.Viewer.ViewModel;

namespace K2L.Spy.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : DXRibbonWindow
    {
        public Main()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }
    }
}