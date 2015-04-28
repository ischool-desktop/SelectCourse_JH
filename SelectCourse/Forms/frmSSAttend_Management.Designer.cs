namespace SelectCourse.Forms
{
    partial class frmSSAttend_Management
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblGroup = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.lblGroupLimit = new DevComponents.DotNetBar.LabelX();
            this.lblGroupLimitlll = new DevComponents.DotNetBar.LabelX();
            this.lblCurrentSSAttendAmount = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.lblLimit = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cboSelectableSubject = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboIdentity = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblSemester = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblSchoolYear = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvSelectedStudent = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewLabelXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn4 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn3 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.RemoveSSAttend = new DevComponents.DotNetBar.ButtonX();
            this.AddSSAttend = new DevComponents.DotNetBar.ButtonX();
            this.lblNoneSelectedAmount = new DevComponents.DotNetBar.LabelX();
            this.lblSelectedAmount = new DevComponents.DotNetBar.LabelX();
            this.dgvSelectNoneStudent = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewLabelXColumn15 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn16 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn17 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn18 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.progress = new DevComponents.DotNetBar.Controls.CircularProgress();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectNoneStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 131);
            this.tabControl1.TabIndex = 77;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lblGroup);
            this.tabControlPanel1.Controls.Add(this.labelX14);
            this.tabControlPanel1.Controls.Add(this.lblGroupLimit);
            this.tabControlPanel1.Controls.Add(this.lblGroupLimitlll);
            this.tabControlPanel1.Controls.Add(this.lblCurrentSSAttendAmount);
            this.tabControlPanel1.Controls.Add(this.labelX10);
            this.tabControlPanel1.Controls.Add(this.lblLimit);
            this.tabControlPanel1.Controls.Add(this.labelX8);
            this.tabControlPanel1.Controls.Add(this.labelX7);
            this.tabControlPanel1.Controls.Add(this.cboSelectableSubject);
            this.tabControlPanel1.Controls.Add(this.labelX2);
            this.tabControlPanel1.Controls.Add(this.cboIdentity);
            this.tabControlPanel1.Controls.Add(this.lblSemester);
            this.tabControlPanel1.Controls.Add(this.labelX1);
            this.tabControlPanel1.Controls.Add(this.lblSchoolYear);
            this.tabControlPanel1.Controls.Add(this.labelX3);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(784, 102);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // lblGroup
            // 
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblGroup.BackgroundStyle.Class = "";
            this.lblGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGroup.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGroup.ForeColor = System.Drawing.Color.Blue;
            this.lblGroup.Location = new System.Drawing.Point(398, 56);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(211, 23);
            this.lblGroup.TabIndex = 86;
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(358, 57);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(34, 21);
            this.labelX14.TabIndex = 85;
            this.labelX14.Text = "群組";
            // 
            // lblGroupLimit
            // 
            this.lblGroupLimit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblGroupLimit.BackgroundStyle.Class = "";
            this.lblGroupLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGroupLimit.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGroupLimit.ForeColor = System.Drawing.Color.Blue;
            this.lblGroupLimit.Location = new System.Drawing.Point(720, 55);
            this.lblGroupLimit.Name = "lblGroupLimit";
            this.lblGroupLimit.Size = new System.Drawing.Size(40, 23);
            this.lblGroupLimit.TabIndex = 84;
            // 
            // lblGroupLimitlll
            // 
            this.lblGroupLimitlll.AutoSize = true;
            this.lblGroupLimitlll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblGroupLimitlll.BackgroundStyle.Class = "";
            this.lblGroupLimitlll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGroupLimitlll.Location = new System.Drawing.Point(615, 56);
            this.lblGroupLimitlll.Name = "lblGroupLimitlll";
            this.lblGroupLimitlll.Size = new System.Drawing.Size(101, 21);
            this.lblGroupLimitlll.TabIndex = 83;
            this.lblGroupLimitlll.Text = "群組選課數上限";
            // 
            // lblCurrentSSAttendAmount
            // 
            this.lblCurrentSSAttendAmount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCurrentSSAttendAmount.BackgroundStyle.Class = "";
            this.lblCurrentSSAttendAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCurrentSSAttendAmount.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCurrentSSAttendAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentSSAttendAmount.Location = new System.Drawing.Point(260, 54);
            this.lblCurrentSSAttendAmount.Name = "lblCurrentSSAttendAmount";
            this.lblCurrentSSAttendAmount.Size = new System.Drawing.Size(40, 23);
            this.lblCurrentSSAttendAmount.TabIndex = 82;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(167, 55);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(87, 21);
            this.labelX10.TabIndex = 81;
            this.labelX10.Text = "目前選課人數";
            // 
            // lblLimit
            // 
            this.lblLimit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblLimit.BackgroundStyle.Class = "";
            this.lblLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLimit.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLimit.ForeColor = System.Drawing.Color.Blue;
            this.lblLimit.Location = new System.Drawing.Point(109, 53);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(40, 23);
            this.lblLimit.TabIndex = 80;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(16, 54);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(87, 21);
            this.labelX8.TabIndex = 79;
            this.labelX8.Text = "修課人數上限";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(500, 11);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(60, 21);
            this.labelX7.TabIndex = 77;
            this.labelX7.Text = "可選科目";
            // 
            // cboSelectableSubject
            // 
            this.cboSelectableSubject.DisplayMember = "Text";
            this.cboSelectableSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSelectableSubject.FormattingEnabled = true;
            this.cboSelectableSubject.ItemHeight = 19;
            this.cboSelectableSubject.Location = new System.Drawing.Point(565, 9);
            this.cboSelectableSubject.Name = "cboSelectableSubject";
            this.cboSelectableSubject.Size = new System.Drawing.Size(200, 25);
            this.cboSelectableSubject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSelectableSubject.TabIndex = 78;
            this.cboSelectableSubject.SelectedIndexChanged += new System.EventHandler(this.cboSelectableSubject_SelectedIndexChanged);
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
            this.labelX2.Location = new System.Drawing.Point(251, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.TabIndex = 75;
            this.labelX2.Text = "身分";
            // 
            // cboIdentity
            // 
            this.cboIdentity.DisplayMember = "Text";
            this.cboIdentity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboIdentity.FormattingEnabled = true;
            this.cboIdentity.ItemHeight = 19;
            this.cboIdentity.Location = new System.Drawing.Point(290, 10);
            this.cboIdentity.Name = "cboIdentity";
            this.cboIdentity.Size = new System.Drawing.Size(200, 25);
            this.cboIdentity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboIdentity.TabIndex = 76;
            this.cboIdentity.SelectedIndexChanged += new System.EventHandler(this.cboIdentity_SelectedIndexChanged);
            // 
            // lblSemester
            // 
            this.lblSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSemester.BackgroundStyle.Class = "";
            this.lblSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSemester.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSemester.ForeColor = System.Drawing.Color.Blue;
            this.lblSemester.Location = new System.Drawing.Point(208, 11);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(31, 23);
            this.lblSemester.TabIndex = 67;
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
            this.labelX1.Location = new System.Drawing.Point(142, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 66;
            this.labelX1.Text = "選課學期";
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSchoolYear.BackgroundStyle.Class = "";
            this.lblSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSchoolYear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSchoolYear.ForeColor = System.Drawing.Color.Blue;
            this.lblSchoolYear.Location = new System.Drawing.Point(96, 11);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(40, 23);
            this.lblSchoolYear.TabIndex = 65;
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
            this.labelX3.Location = new System.Drawing.Point(16, 13);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 21);
            this.labelX3.TabIndex = 59;
            this.labelX3.Text = "選課學年度";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "步驟一：選擇科目";
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(693, 515);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 28);
            this.Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exit.TabIndex = 46;
            this.Exit.Text = "離  開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.Transparent;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.Location = new System.Drawing.Point(0, 146);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(784, 356);
            this.tabControl2.TabIndex = 78;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvSelectedStudent);
            this.tabControlPanel2.Controls.Add(this.RemoveSSAttend);
            this.tabControlPanel2.Controls.Add(this.AddSSAttend);
            this.tabControlPanel2.Controls.Add(this.lblNoneSelectedAmount);
            this.tabControlPanel2.Controls.Add(this.lblSelectedAmount);
            this.tabControlPanel2.Controls.Add(this.dgvSelectNoneStudent);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(784, 327);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // dgvSelectedStudent
            // 
            this.dgvSelectedStudent.AllowUserToAddRows = false;
            this.dgvSelectedStudent.AllowUserToDeleteRows = false;
            this.dgvSelectedStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLabelXColumn1,
            this.dataGridViewLabelXColumn2,
            this.dataGridViewLabelXColumn4,
            this.dataGridViewLabelXColumn3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectedStudent.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectedStudent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSelectedStudent.Location = new System.Drawing.Point(20, 36);
            this.dgvSelectedStudent.Name = "dgvSelectedStudent";
            this.dgvSelectedStudent.ReadOnly = true;
            this.dgvSelectedStudent.RowHeadersWidth = 25;
            this.dgvSelectedStudent.RowTemplate.Height = 24;
            this.dgvSelectedStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedStudent.Size = new System.Drawing.Size(300, 264);
            this.dgvSelectedStudent.TabIndex = 82;
            // 
            // dataGridViewLabelXColumn1
            // 
            this.dataGridViewLabelXColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewLabelXColumn1.HeaderText = "班級";
            this.dataGridViewLabelXColumn1.Name = "dataGridViewLabelXColumn1";
            this.dataGridViewLabelXColumn1.ReadOnly = true;
            this.dataGridViewLabelXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn1.Width = 59;
            // 
            // dataGridViewLabelXColumn2
            // 
            this.dataGridViewLabelXColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewLabelXColumn2.HeaderText = "座號";
            this.dataGridViewLabelXColumn2.Name = "dataGridViewLabelXColumn2";
            this.dataGridViewLabelXColumn2.ReadOnly = true;
            this.dataGridViewLabelXColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn2.Width = 40;
            // 
            // dataGridViewLabelXColumn4
            // 
            this.dataGridViewLabelXColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewLabelXColumn4.HeaderText = "學號";
            this.dataGridViewLabelXColumn4.Name = "dataGridViewLabelXColumn4";
            this.dataGridViewLabelXColumn4.ReadOnly = true;
            this.dataGridViewLabelXColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn4.Width = 59;
            // 
            // dataGridViewLabelXColumn3
            // 
            this.dataGridViewLabelXColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewLabelXColumn3.HeaderText = "姓名";
            this.dataGridViewLabelXColumn3.Name = "dataGridViewLabelXColumn3";
            this.dataGridViewLabelXColumn3.ReadOnly = true;
            this.dataGridViewLabelXColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn3.Width = 59;
            // 
            // RemoveSSAttend
            // 
            this.RemoveSSAttend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.RemoveSSAttend.BackColor = System.Drawing.Color.Transparent;
            this.RemoveSSAttend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.RemoveSSAttend.Location = new System.Drawing.Point(346, 154);
            this.RemoveSSAttend.Name = "RemoveSSAttend";
            this.RemoveSSAttend.Size = new System.Drawing.Size(93, 23);
            this.RemoveSSAttend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RemoveSSAttend.TabIndex = 81;
            this.RemoveSSAttend.Text = ">>  退選";
            this.RemoveSSAttend.Click += new System.EventHandler(this.RemoveSSAttend_Click);
            // 
            // AddSSAttend
            // 
            this.AddSSAttend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AddSSAttend.BackColor = System.Drawing.Color.Transparent;
            this.AddSSAttend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.AddSSAttend.Location = new System.Drawing.Point(346, 92);
            this.AddSSAttend.Name = "AddSSAttend";
            this.AddSSAttend.Size = new System.Drawing.Size(93, 23);
            this.AddSSAttend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AddSSAttend.TabIndex = 80;
            this.AddSSAttend.Text = "<<  加選";
            this.AddSSAttend.Click += new System.EventHandler(this.AddSSAttend_Click);
            // 
            // lblNoneSelectedAmount
            // 
            this.lblNoneSelectedAmount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblNoneSelectedAmount.BackgroundStyle.Class = "";
            this.lblNoneSelectedAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNoneSelectedAmount.Location = new System.Drawing.Point(465, 9);
            this.lblNoneSelectedAmount.Name = "lblNoneSelectedAmount";
            this.lblNoneSelectedAmount.Size = new System.Drawing.Size(300, 21);
            this.lblNoneSelectedAmount.TabIndex = 79;
            this.lblNoneSelectedAmount.Text = "未選修學生";
            // 
            // lblSelectedAmount
            // 
            this.lblSelectedAmount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSelectedAmount.BackgroundStyle.Class = "";
            this.lblSelectedAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSelectedAmount.Location = new System.Drawing.Point(20, 9);
            this.lblSelectedAmount.Name = "lblSelectedAmount";
            this.lblSelectedAmount.Size = new System.Drawing.Size(300, 21);
            this.lblSelectedAmount.TabIndex = 78;
            this.lblSelectedAmount.Text = "已選修學生";
            // 
            // dgvSelectNoneStudent
            // 
            this.dgvSelectNoneStudent.AllowUserToAddRows = false;
            this.dgvSelectNoneStudent.AllowUserToDeleteRows = false;
            this.dgvSelectNoneStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectNoneStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLabelXColumn15,
            this.dataGridViewLabelXColumn16,
            this.dataGridViewLabelXColumn17,
            this.dataGridViewLabelXColumn18});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectNoneStudent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectNoneStudent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSelectNoneStudent.Location = new System.Drawing.Point(465, 36);
            this.dgvSelectNoneStudent.Name = "dgvSelectNoneStudent";
            this.dgvSelectNoneStudent.ReadOnly = true;
            this.dgvSelectNoneStudent.RowHeadersWidth = 25;
            this.dgvSelectNoneStudent.RowTemplate.Height = 24;
            this.dgvSelectNoneStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectNoneStudent.Size = new System.Drawing.Size(300, 264);
            this.dgvSelectNoneStudent.TabIndex = 77;
            // 
            // dataGridViewLabelXColumn15
            // 
            this.dataGridViewLabelXColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewLabelXColumn15.HeaderText = "班級";
            this.dataGridViewLabelXColumn15.Name = "dataGridViewLabelXColumn15";
            this.dataGridViewLabelXColumn15.ReadOnly = true;
            this.dataGridViewLabelXColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn15.Width = 59;
            // 
            // dataGridViewLabelXColumn16
            // 
            this.dataGridViewLabelXColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewLabelXColumn16.HeaderText = "座號";
            this.dataGridViewLabelXColumn16.Name = "dataGridViewLabelXColumn16";
            this.dataGridViewLabelXColumn16.ReadOnly = true;
            this.dataGridViewLabelXColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn16.Width = 40;
            // 
            // dataGridViewLabelXColumn17
            // 
            this.dataGridViewLabelXColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewLabelXColumn17.HeaderText = "學號";
            this.dataGridViewLabelXColumn17.Name = "dataGridViewLabelXColumn17";
            this.dataGridViewLabelXColumn17.ReadOnly = true;
            this.dataGridViewLabelXColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn17.Width = 59;
            // 
            // dataGridViewLabelXColumn18
            // 
            this.dataGridViewLabelXColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewLabelXColumn18.HeaderText = "姓名";
            this.dataGridViewLabelXColumn18.Name = "dataGridViewLabelXColumn18";
            this.dataGridViewLabelXColumn18.ReadOnly = true;
            this.dataGridViewLabelXColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn18.Width = 59;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "步驟二：調整修課學生";
            // 
            // progress
            // 
            this.progress.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.progress.BackgroundStyle.Class = "";
            this.progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progress.Location = new System.Drawing.Point(615, 515);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(55, 28);
            this.progress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progress.TabIndex = 79;
            this.progress.Visible = false;
            // 
            // frmSSAttend_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 554);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Exit);
            this.DoubleBuffered = true;
            this.Name = "frmSSAttend_Management";
            this.Text = "學生選修科目設定";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectNoneStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSelectableSubject;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIdentity;
        private DevComponents.DotNetBar.LabelX lblSemester;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.LabelX lblCurrentSSAttendAmount;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX lblLimit;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX lblGroup;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX lblGroupLimit;
        private DevComponents.DotNetBar.LabelX lblGroupLimitlll;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSelectedStudent;
        private DevComponents.DotNetBar.ButtonX RemoveSSAttend;
        private DevComponents.DotNetBar.ButtonX AddSSAttend;
        private DevComponents.DotNetBar.LabelX lblNoneSelectedAmount;
        private DevComponents.DotNetBar.LabelX lblSelectedAmount;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSelectNoneStudent;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn4;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn3;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn15;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn16;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn17;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn18;
        private DevComponents.DotNetBar.Controls.CircularProgress progress;
    }
}