namespace OutlookToolkit.WinForms
{
    partial class SelectOutlookStoreForm
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
            label1 = new Label();
            comboBoxAvailableStoreNames = new ComboBox();
            Cancel = new Button();
            buttonOk = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 20);
            label1.TabIndex = 0;
            label1.Text = "Select one of available Ouplook stores:";
            // 
            // comboBoxAvailableStoreNames
            // 
            comboBoxAvailableStoreNames.FormattingEnabled = true;
            comboBoxAvailableStoreNames.Location = new Point(12, 32);
            comboBoxAvailableStoreNames.Name = "comboBoxAvailableStoreNames";
            comboBoxAvailableStoreNames.Size = new Size(267, 28);
            comboBoxAvailableStoreNames.Sorted = true;
            comboBoxAvailableStoreNames.TabIndex = 1;
            comboBoxAvailableStoreNames.SelectedIndexChanged += comboBoxAvailableStoreNames_SelectedIndexChanged;
            // 
            // Cancel
            // 
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.Location = new Point(185, 66);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(94, 29);
            Cancel.TabIndex = 2;
            Cancel.Text = "buttonCancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(85, 66);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(94, 29);
            buttonOk.TabIndex = 3;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // SelectOutlookStoreForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new Size(293, 105);
            ControlBox = false;
            Controls.Add(buttonOk);
            Controls.Add(Cancel);
            Controls.Add(comboBoxAvailableStoreNames);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SelectOutlookStoreForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Outlook Store";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxAvailableStoreNames;
        private Button Cancel;
        private Button buttonOk;
    }
}