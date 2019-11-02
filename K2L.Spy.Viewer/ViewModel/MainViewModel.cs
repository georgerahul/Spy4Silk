using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Docking.Base;
using K2L.Spy.Framework.SilkSetting;
using K2L.Spy.Viewer.PopupForms;
using K2L.Spy.Viewer.Utils;
using K2L.Spy.Viewer.View;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace K2L.Spy.Viewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Main _mainView;

        public TabViewModel TabViewModel;

        public MainViewModel(Main main)
        {
            _mainView = main;
            TabViewModel = new TabViewModel(this, null);
            if (AppToSpy.Instance.Application == null)
            {
                EditBaseStateClick();
            }
            OnTabAddClick();
        }

        #region Tools

        public ICommand AddTabCommand
        {
            get { return new RelayCommand(o => OnTabAddClick()); }
        }

        public void OnTabAddClick()
        {
            AddTab("Main Control");
        }

        public ICommand EditBaseStateCommand
        {
            get { return new RelayCommand(o => EditBaseStateClick()); }
        }

        public async void EditBaseStateClick()
        {
            var apps = new DesktopApp();
            ApplicationForm form = null;
            await Task.Run(() => {
                form = new ApplicationForm();
                form.DataSource = apps.GetLocators();
            });
            form.ShowDialog();
        }

        #endregion Tools

        #region Gui Tools

        public ICommand GetPropertiesCommand
        {
            get { return new RelayCommand(o => GetPropertiesCommandOnClick(), o => TabViewModel?.IsSelectedValidGuiElements() ?? false); }
        }

        public void GetPropertiesCommandOnClick()
        {
            TabViewModel?.GetPropertiesButtonCommand.Execute(null);
        }

        public ICommand HighlightObjectCommand
        {
            get { return new RelayCommand(o => HighlightObjectCommandOnClick(), o => TabViewModel?.IsSelectedValidGuiElements() ?? false); }
        }

        public void HighlightObjectCommandOnClick()
        {
            TabViewModel?.HighlightObjectButtonCommand.Execute(null);
        }

        public ICommand ClickObjectCommand
        {
            get { return new RelayCommand(o => ClickObjectCommandOnClick(), o => TabViewModel?.IsSelectedValidGuiElements() ?? false); }
        }

        private void ClickObjectCommandOnClick()
        {
            TabViewModel?.ClickObjectButtonCommand.Execute(null);
        }

        #endregion Gui Tools

        #region XPath Tools

        public ICommand HighlightXPathObjectCommand
        {
            get { return new RelayCommand(o => HighlightXPathObjectCommandOnClick(), o => TabViewModel?.IsXpathObjectValidGuiElements() ?? false); }
        }

        public void HighlightXPathObjectCommandOnClick()
        {
            TabViewModel?.HighlightXPathObjectButtonCommand.Execute(null);
        }

        public ICommand ClickXPathObjectCommand
        {
            get { return new RelayCommand(o => ClickXPathObjectCommandOnClick(), o => TabViewModel?.IsXpathObjectValidGuiElements() ?? false); }
        }

        private void ClickXPathObjectCommandOnClick()
        {
            TabViewModel?.ClickXPathObjectButtonCommand.Execute(null);
        }

        #endregion XPath Tools

        public void AddTab(string tabCaption, TabViewModel tabViewModel = null)
        {
            if (tabViewModel != null)
            {
                TabViewModel = tabViewModel;
            }

            var view = new TabView
            {
                DataContext = TabViewModel
            };

            if (tabViewModel != null)
            {
                tabCaption = tabViewModel.Analyzer.State.GuiString;
                //tabCaption = tabViewModel.TextBoxProperty;
            }

            var documentGroup = _mainView.DockLayoutManager.GetItems()
                .OfType<DocumentGroup>()
                .First(dg => dg.Name == "DocumentRegionGroup");

            var layoutPanel = _mainView.DockLayoutManager.DockController.AddDocumentPanel(documentGroup);
            _mainView.DockLayoutManager.DockItemActivated += DockLayoutManagerOnDockItemActivated;

            layoutPanel.Content = view;
            layoutPanel.Caption = tabCaption;

            _mainView.DockLayoutManager.DockController.Activate(layoutPanel);
        }

        private void DockLayoutManagerOnDockItemActivated(object sender, DockItemActivatedEventArgs ea)
        {
            var documentLayoutManager = sender as DockLayoutManager;
            var documentPanel = documentLayoutManager?.ActiveDockItem as DocumentPanel;
            var tabView = documentPanel?.Content as TabView;
            if (tabView == null)
            {
                return;
            }

            this.TabViewModel = tabView.DataContext as TabViewModel;
        }
    }
}