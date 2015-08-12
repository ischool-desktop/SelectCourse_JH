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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(298, 317);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(383, 317);
            // 
            // chkSelectAll
            // 
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.Class = "";
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSelectAll.Location = new System.Drawing.Point(34, 293);
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
            // FieldContainer
            // 
            this.FieldContainer.Size = new System.Drawing.Size(424, 232);
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
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(34, 319);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(230, 21);
            this.labelX1.TabIndex = 79;
            this.labelX1.Text = "[未選課]表示於該年級未選擇任意科目";
            // 
            // SSAttend_NoneSelectStudent_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 350);
            this.Controls.Add(this.labelX1);
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
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIdentity;
        private DevComponents.DotNetBar.LabelX labelX1;


    }
}