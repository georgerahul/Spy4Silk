using K2L.Spy.Framework.DataModel;
using K2L.Spy.Framework.SilkSetting;
using System;
using System.Windows.Forms;

namespace K2L.Spy.Viewer.PopupForms
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            set
            {
                lBoxApplication.DataSource = value;
                //lBoxApplication.DisplayMember = "Locator";
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            AppToSpy.Instance
                .SetApplication(lBoxApplication.SelectedItem as DesktopBaseState);

            if (chkDefault.Checked)
            {
                var state = new DefaultBaseState();
                state.SetDefaultBaseState(lBoxApplication.SelectedItem as DesktopBaseState);
            }

            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LBoxApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lBoxApplication.SelectedValue == null)
                btnSelect.Enabled = false;
            else
                btnSelect.Enabled = true;
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {

            if (lBoxApplication.SelectedValue == null)
                return;

            (lBoxApplication.SelectedItem as DesktopBaseState).Application.HighlightObject(1000);
        }
    }
}