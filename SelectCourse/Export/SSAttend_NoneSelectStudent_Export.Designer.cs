namespace SelectCourse_JH.Export
{
    partial class SSAttend_NoneSelectStudent_Export
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboIdentity = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // chkSelectAll
            // 
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.Class = "";
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // lblExplanation
            // 
            // 
            // 
            // 
            this.lblExplanation.BackgroundStyle.Class = "";
            this.lblExplanation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblExplanation.Size = new System.Drawing.Size(101, 21);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(220, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.TabIndex = 77;
            this.labelX2.Text = "身分";
            // 
            // cboIdentity
            // 
            this.cboIdentity.DisplayMember = "Text";
            this.cboIdentity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboIdentity.FormattingEnabled = true;
            this.cboIdentity.ItemHeight = 19;
            this.cboIdentity.Location = new System.Drawing.Point(259, 14);
            this.cboIdentity.Name = "cboIdentity";
            this.cboIdentity.Size = new System.Drawing.Size(200, 25);
            this.cboIdentity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboIdentity.TabIndex = 78;
            this.cboIdentity.SelectedIndexChanged += new System.EventHandler(this.cboIdentity_SelectedIndexChanged);
            // 
            // SSAttend_NoneSelectStudent_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cboIdentity);
            this.DoubleBuffered = true;
            this.Name = "SSAttend_NoneSelectStudent_Export";
            this.Text = "SSAttend_NoneSelectStudent_Export";
            this.Controls.SetChildIndex(this.chkSelectAll, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.FieldContainer, 0);
            this.Controls.SetChildIndex(this.lblExplanation, 0);
            this.Controls.SetChildIndex(this.cboIdentity, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIdentity;


    }
}