namespace SelectCourse_JH.Forms
{
    partial class frmSubject_Management
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Add = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Institute = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.SubjectName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Level = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Credit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Type = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Limit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Goal = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Content = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Memo = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Delete = new DevComponents.DotNetBar.ButtonX();
            this.cboSchoolYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Addd = new DevComponents.DotNetBar.ButtonX();
            this.Update = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(692, 518);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 28);
            this.Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exit.TabIndex = 7;
            this.Exit.Text = "離  開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Add,
            this.Institute,
            this.SubjectName,
            this.Level,
            this.Credit,
            this.Type,
            this.Limit,
            this.Goal,
            this.Content,
            this.Memo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(19, 59);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(745, 441);
            this.dgvData.TabIndex = 6;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvData_DataBindingComplete);
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Add.HeaderText = "加入";
            this.Add.Name = "Add";
            this.Add.ReadOnly = true;
            this.Add.Text = "";
            this.Add.Width = 40;
            // 
            // Institute
            // 
            this.Institute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Institute.HeaderText = "教學單位";
            this.Institute.Name = "Institute";
            this.Institute.ReadOnly = true;
            this.Institute.Width = 66;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SubjectName.HeaderText = "科目名稱";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            this.SubjectName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubjectName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SubjectName.Width = 85;
            // 
            // Level
            // 
            this.Level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Level.HeaderText = "級別";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Level.Width = 59;
            // 
            // Credit
            // 
            this.Credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Credit.HeaderText = "學分數";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Credit.Width = 72;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Type.HeaderText = "課程類別";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Type.Width = 85;
            // 
            // Limit
            // 
            this.Limit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Limit.HeaderText = "修課人數上限";
            this.Limit.Name = "Limit";
            this.Limit.ReadOnly = true;
            this.Limit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Limit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Limit.Width = 111;
            // 
            // Goal
            // 
            this.Goal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Goal.HeaderText = "教學目標";
            this.Goal.Name = "Goal";
            this.Goal.ReadOnly = true;
            this.Goal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Goal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Goal.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.Goal.Width = 85;
            // 
            // Content
            // 
            this.Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Content.HeaderText = "教學內容";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Content.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Content.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.Content.Width = 85;
            // 
            // Memo
            // 
            this.Memo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Memo.HeaderText = "備註";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Memo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Memo.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.Memo.Width = 59;
            // 
            // Delete
            // 
            this.Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.BackColor = System.Drawing.Color.Transparent;
            this.Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Delete.Location = new System.Drawing.Point(595, 518);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(72, 28);
            this.Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Delete.TabIndex = 8;
            this.Delete.Text = "刪  除";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // cboSchoolYear
            // 
            this.cboSchoolYear.DisplayMember = "Text";
            this.cboSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSchoolYear.FormattingEnabled = true;
            this.cboSchoolYear.ItemHeight = 19;
            this.cboSchoolYear.Location = new System.Drawing.Point(67, 16);
            this.cboSchoolYear.Name = "cboSchoolYear";
            this.cboSchoolYear.Size = new System.Drawing.Size(80, 25);
            this.cboSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSchoolYear.TabIndex = 33;
            this.cboSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cboSchoolYear_SelectedIndexChanged);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(19, 18);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 21);
            this.labelX3.TabIndex = 30;
            this.labelX3.Text = "學年度";
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
            this.labelX1.Location = new System.Drawing.Point(159, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 31;
            this.labelX1.Text = "學期";
            // 
            // cboSemester
            // 
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(194, 16);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(80, 25);
            this.cboSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSemester.TabIndex = 32;
            this.cboSemester.SelectedIndexChanged += new System.EventHandler(this.cboSemester_SelectedIndexChanged);
            // 
            // Addd
            // 
            this.Addd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Addd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Addd.BackColor = System.Drawing.Color.Transparent;
            this.Addd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Addd.Location = new System.Drawing.Point(404, 518);
            this.Addd.Name = "Addd";
            this.Addd.Size = new System.Drawing.Size(72, 28);
            this.Addd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Addd.TabIndex = 34;
            this.Addd.Text = "新  增";
            this.Addd.Click += new System.EventHandler(this.Addd_Click);
            // 
            // Update
            // 
            this.Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Update.BackColor = System.Drawing.Color.Transparent;
            this.Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Update.Location = new System.Drawing.Point(498, 518);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(72, 28);
            this.Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Update.TabIndex = 35;
            this.Update.Text = "修  改";
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // frmSubject_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Addd);
            this.Controls.Add(this.cboSchoolYear);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.Delete);
            this.DoubleBuffered = true;
            this.Name = "frmSubject_Management";
            this.Text = "科目管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.ButtonX Delete;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.ButtonX Addd;
        private DevComponents.DotNetBar.ButtonX Update;
        private System.Windows.Forms.DataGridViewLinkColumn Add;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Institute;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SubjectName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Level;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Credit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Type;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Limit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Goal;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Content;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Memo;
    }
}