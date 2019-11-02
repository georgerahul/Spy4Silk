namespace K2L.Spy.Viewer.PopupForms
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.lBoxApplication = new System.Windows.Forms.ListBox();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(15, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(189, 17);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Select the application to spy.";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(178, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(48, 322);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new System.Drawing.Point(111, 287);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(93, 17);
            this.chkDefault.TabIndex = 3;
            this.chkDefault.Text = "Set as Default";
            this.chkDefault.UseVisualStyleBackColor = true;
            this.chkDefault.Visible = false;
            // 
            // lBoxApplication
            // 
            this.lBoxApplication.FormattingEnabled = true;
            this.lBoxApplication.Location = new System.Drawing.Point(18, 63);
            this.lBoxApplication.Name = "lBoxApplication";
            this.lBoxApplication.Size = new System.Drawing.Size(297, 199);
            this.lBoxApplication.TabIndex = 4;
            this.lBoxApplication.SelectedIndexChanged += new System.EventHandler(this.LBoxApplication_SelectedIndexChanged);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Location = new System.Drawing.Point(23, 268);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(50, 24);
            this.btnHighlight.TabIndex = 5;
            this.btnHighlight.Text = "Glow";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 358);
            this.Controls.Add(this.btnHighlight);
            this.Controls.Add(this.lBoxApplication);
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblHeader);
            this.Name = "ApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application to spy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.ListBox lBoxApplication;
        private System.Windows.Forms.Button btnHighlight;
    }
}