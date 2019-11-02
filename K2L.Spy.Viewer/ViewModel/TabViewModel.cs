using K2L.Spy.Framework;
using K2L.Spy.Framework.DataModel;
using K2L.Spy.Viewer.Model;
using K2L.Spy.Viewer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace K2L.Spy.Viewer.ViewModel
{
    public class TabViewModel : ViewModelBase
    {
        private List<Property> _previousProperty;
        private string _prevXpath;
        private List<Property> _properties;
        private List<DynamicMethod> _dynamicMethods;
        private InformationColor _informationType = InformationColor.Green;
        private InformationColor _methodInformationType = InformationColor.Green;
        private bool _isProcessRunning = false;
        private readonly MainViewModel _mainViewModel;

        private object _selectedModelBase;

        public TabViewModel(MainViewModel mainViewModel, object selectedvalue)
        {
            _mainViewModel = mainViewModel;
            //if (selectedvalue is PropertyBase value)
            //{
            //    LoadPropertybySelectedValue(value.GuiObjectValue);
            //}

            if (selectedvalue is string stateValue)
            {
                LoadPropertybyStateValue(stateValue);
            }

            _previousProperty = null;
            _prevXpath = null;
        }

        // if you use List use should notify to UI otherwise use Observable collection it will care of notifying to view
        public List<Property> Properties
        {
            get => _properties;
            set
            {
                _properties = value;
                OnPropertyChanged(nameof(Properties));
            }
        }

        public List<DynamicMethod> DynamicMethods
        {
            get => _dynamicMethods;
            set
            {
                _dynamicMethods = value;
                OnPropertyChanged(nameof(DynamicMethods));
            }
        }

        public object SelectedModelBase
        {
            get => _selectedModelBase;
            set
            {
                _selectedModelBase = value;
                OnPropertyChanged(nameof(SelectedModelBase));
            }
        }

        private string _textBoxProperty;

        public string TextBoxProperty
        {
            get => _textBoxProperty;
            set
            {
                _textBoxProperty = value;

                //if (_textBoxProperty != null || _textBoxProperty != string.Empty)
                //   App.Current.Dispatcher.Invoke(()=> ProcessButtonCommand.CanExecute(true));
                //else
                //    App.Current.Dispatcher.Invoke(() => ProcessButtonCommand.CanExecute(false));

                OnPropertyChanged(nameof(TextBoxProperty));
            }
        }

        private string _parameterTextProperty = string.Empty;

        public string ParameterTextProperty
        {
            get => _parameterTextProperty;
            set
            {
                _parameterTextProperty = value;
                OnPropertyChanged(nameof(ParameterTextProperty));
            }
        }

        public Analyzer Analyzer { get; set; }

        private MethodResult MethodResults { get; set; }

        #region Validation

        public InformationColor ValidationType
        {
            get => _informationType;
            set
            {
                _informationType = value;
                OnPropertyChanged(nameof(ValidationType));
            }
        }

        private string _validationText;

        public string ValidationText
        {
            get => _validationText;
            set
            {
                _validationText = value;
                OnPropertyChanged(nameof(ValidationText));
            }
        }

        private void Validation(InformationColor type, string text)
        {
            ValidationType = type;
            ValidationText = text;
        }

        #endregion Validation

        #region Method Validation

        public InformationColor MethodValidationType
        {
            get => _methodInformationType;
            set
            {
                _methodInformationType = value;
                OnPropertyChanged(nameof(MethodValidationType));
            }
        }

        private string _MethodvalidationText;

        public string MethodValidationText
        {
            get => _MethodvalidationText;
            set
            {
                _MethodvalidationText = value;
                OnPropertyChanged(nameof(MethodValidationText));
            }
        }

        private void MethodValidation(InformationColor type, string text)
        {
            MethodValidationType = type;
            MethodValidationText = text;
        }

        #endregion Method Validation

        #region Highlight Control

        public ICommand HighlightObjectButtonCommand
        {
            get { return new RelayCommand(o => OnHighlightObjectButtonClick()); }
        }

        public void OnHighlightObjectButtonClick()
        {
            if (SelectedModelBase is PropertyBase property)
            {
                if (property.IsValueGuiObject)
                {
                    property.GuiObjectValue.HighlightObject();
                }
            }
        }

        #endregion Highlight Control

        #region Click Property Control

        public ICommand ClickObjectButtonCommand
        {
            get { return new RelayCommand(o => OnClickObjectButtonClick()); }
        }

        private void OnClickObjectButtonClick()
        {
            if (SelectedModelBase is PropertyBase property)
            {
                if (property.IsValueGuiObject)
                {
                    property.GuiObjectValue.ClickObject();
                }
            }
            //else
            //if (MethodResults is MethodResult method)
            //{
            //    if (property.IsValueGuiObject)
            //    {
            //        property.GuiObjectValue.ClickObject();
            //    }
            //}
            //MethodResult
        }

        #endregion Click Property Control

        #region Click XPath Control

        public ICommand ClickXPathObjectButtonCommand
        {
            get { return new RelayCommand(o => OnClickXpathObjectButtonClick()); }
        }

        private void OnClickXpathObjectButtonClick()
        {
            if (Analyzer.ObjectUnderAnalyzsis != null)
                Analyzer.ObjectUnderAnalyzsis.ClickObject();
        }

        #endregion Click XPath Control

        #region Highlight XPath Control

        public ICommand HighlightXPathObjectButtonCommand
        {
            get { return new RelayCommand(o => OnHighlightXPathObjectButtonClick()); }
        }

        public void OnHighlightXPathObjectButtonClick()
        {
            if (Analyzer.ObjectUnderAnalyzsis != null)
                Analyzer.ObjectUnderAnalyzsis.HighlightObject();
        }

        #endregion Highlight XPath Control

        #region Process the XPath

        public ICommand ProcessButtonCommand
        {
            get { return new RelayCommand(o => OnProcessButtonClick(), o => GetProcessButtonState()); }
        }

        private bool GetProcessButtonState()
        {
            if (_textBoxProperty.Trim() == string.Empty)
                return false;

            if (_isProcessRunning == true)
                return false;

            return true;
        }

        public async void OnProcessButtonClick()
        {
            try
            {
                _isProcessRunning = true;

                Properties = null;
                DynamicMethods = null;

                MethodValidation(InformationColor.Green, "");
                Validation(InformationColor.Green, "Processing...");

                await Task.Run(() =>
                {
                    Analyzer = new Analyzer(TextBoxProperty);
                });

                if (Analyzer.ObjectUnderAnalyzsis == null)
                {
                    Validation(InformationColor.Red, "Error: " + Analyzer.ErrorDetails);
                    return;
                }

                Validation(InformationColor.Green, "Getting property and method details.");

                var taskList = new List<Task>();
                taskList.Add(Task.Factory.StartNew(() =>
                {
                    LoadProperty();
                }));
                taskList.Add(Task.Factory.StartNew(() =>
                {
                    LoadMethods();
                }));

                await Task.Run(() => CheckTaskState(taskList));
            }
            finally
            {
                _isProcessRunning = false;
            }
        }

        public void CheckTaskState(List<Task> tasks)
        {
            Task.WaitAll(tasks.ToArray());
            Validation(InformationColor.Green, "Processing Completed.");
        }

        public void LoadMethods() => DynamicMethods = Analyzer.GetMethods();

        public void LoadProperty()
        {
            var tempPropertyList = Analyzer.GetProperties();

            if (_prevXpath == null || _prevXpath.Trim() == string.Empty) // If Property is loading for the first time.
            {
                Properties = tempPropertyList;
            }
            else if (TextBoxProperty != _prevXpath) // If the XPath is new.
            {
                Properties = tempPropertyList;
            }
            else // If same XPath is processed.
            {
                if (_previousProperty != null && _previousProperty.Count != 0)
                    for (int i = 0; i < tempPropertyList.Count; i++)
                    {
                        //if (tempPropertyList[i].IsArrayList == false)
                        {
                            var matchingProperty = _previousProperty.Where(w => w.Name == tempPropertyList[i].Name).FirstOrDefault();

                            if (matchingProperty == null)                                   // New property.
                                tempPropertyList[i].PropertyState = PropertyState.NewlyAdded;
                            else if (matchingProperty.Value != tempPropertyList[i].Value)    // Property Value changed.
                                tempPropertyList[i].PropertyState = PropertyState.Changed;
                            else                                                            // Property value same as before.
                                tempPropertyList[i].PropertyState = PropertyState.NoChange;
                        }
                    }
                Properties = tempPropertyList;
            }
            _previousProperty = tempPropertyList;
            _prevXpath = TextBoxProperty;
        }

        #endregion Process the XPath

        #region Invoke Method

        public ICommand InvokeButtonCommand
        {
            get { return new RelayCommand(o => OnInvokeButtonClick(), o => IsMethodSelected()); }
        }

        public void OnInvokeButtonClick()
        {
            if (SelectedModelBase is DynamicMethod method)
            {
                try
                {
                    var result = Analyzer.ExecuteMethod(method, ParameterTextProperty.Trim('(', ')'));

                    if (method.IsReturn == false)
                        MethodValidation(InformationColor.Green, method.MethodName + " executed.");
                    else
                        MethodValidation(InformationColor.Green, method.MethodName + " executed. Result is:" + '\n' + result.ToString());
                }
                catch (Exception ex)
                {
                    MethodValidation(InformationColor.Red, ex.Message);
                }

                //method.
            }
        }

        #endregion Invoke Method

        #region Get Child Control Details

        public ICommand GetPropertiesButtonCommand
        {
            get
            {
                return new RelayCommand(o => OnGetPropertiesButtonClick());
            }
        }

        public void OnGetPropertiesButtonClick()
        {
            _mainViewModel.AddTab("Parent Tab", new TabViewModel(_mainViewModel, Analyzer.State.ToString() + "." + (SelectedModelBase as PropertyBase).Relationship));
        }

        #endregion Get Child Control Details

        public bool IsSelectedValidGuiElements()
        {
            if (SelectedModelBase is PropertyBase property)
            {
                if (SelectedModelBase == null)
                {
                    return false;
                }

                return property.IsValueGuiObject;
            }

            return false;
        }

        public bool IsXpathObjectValidGuiElements()
        {
            if (Analyzer == null)
                return false;

            if (Analyzer.ObjectUnderAnalyzsis == null)
                return false;

            return true;
        }

        public bool IsMethodSelected()
        {
            if (SelectedModelBase is DynamicMethod method)
            {
                if (SelectedModelBase == null)
                    return false;

                if (method.Invokable == true)
                    return true;
            }

            return false;
        }

        public ICommand ChildModelButton
        {
            get
            {
                return new RelayCommand(o => OnChildModelButtonClick(),
                    o => (SelectedModelBase as ChildModel)?.IsSelected ?? false);
            }
        }

        public void OnChildModelButtonClick()
        {
        }

        public void LoadPropertybyStateValue(string stateValue)
        {
            Analyzer = new Analyzer(stateValue);
            TextBoxProperty = Analyzer.XPath;
            OnProcessButtonClick();
        }
    }

    public enum InformationColor
    {
        Red,
        Green,
        Yellow
    }
}