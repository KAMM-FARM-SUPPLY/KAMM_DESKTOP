namespace KAMM_FARM_SERVICES.UI
{
    partial class Location
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CF_districts = new System.Windows.Forms.Label();
            this.district_info = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label7 = new System.Windows.Forms.Label();
            this.District_delete = new MaterialSkin.Controls.MaterialButton();
            this.District_update = new MaterialSkin.Controls.MaterialButton();
            this.District_add = new MaterialSkin.Controls.MaterialButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv1 = new KAMM_FARM_SERVICES.Components.DGV();
            this.district_name = new MaterialSkin.Controls.MaterialTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.sub_info = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label8 = new System.Windows.Forms.Label();
            this.County_delete = new MaterialSkin.Controls.MaterialButton();
            this.County_update = new MaterialSkin.Controls.MaterialButton();
            this.County_add = new MaterialSkin.Controls.MaterialButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv2 = new KAMM_FARM_SERVICES.Components.DGV();
            this.sub_name = new MaterialSkin.Controls.MaterialTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Sub = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.village_info = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label9 = new System.Windows.Forms.Label();
            this.materialButton7 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton8 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton9 = new MaterialSkin.Controls.MaterialButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgv3 = new KAMM_FARM_SERVICES.Components.DGV();
            this.village_name = new MaterialSkin.Controls.MaterialTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Vill = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CF_districts);
            this.panel1.Controls.Add(this.district_info);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.District_delete);
            this.panel1.Controls.Add(this.District_update);
            this.panel1.Controls.Add(this.District_add);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.district_name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 565);
            this.panel1.TabIndex = 0;
            // 
            // CF_districts
            // 
            this.CF_districts.AutoSize = true;
            this.CF_districts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CF_districts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.CF_districts.Location = new System.Drawing.Point(251, 5);
            this.CF_districts.Name = "CF_districts";
            this.CF_districts.Size = new System.Drawing.Size(83, 20);
            this.CF_districts.TabIndex = 23;
            this.CF_districts.Text = "Clear fields";
            this.CF_districts.Click += new System.EventHandler(this.CF_districts_Click);
            // 
            // district_info
            // 
            this.district_info.AnimateReadOnly = false;
            this.district_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.district_info.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.district_info.Depth = 0;
            this.district_info.HideSelection = true;
            this.district_info.Location = new System.Drawing.Point(95, 105);
            this.district_info.MaxLength = 32767;
            this.district_info.MouseState = MaterialSkin.MouseState.OUT;
            this.district_info.Name = "district_info";
            this.district_info.PasswordChar = '\0';
            this.district_info.ReadOnly = false;
            this.district_info.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.district_info.SelectedText = "";
            this.district_info.SelectionLength = 0;
            this.district_info.SelectionStart = 0;
            this.district_info.ShortcutsEnabled = true;
            this.district_info.Size = new System.Drawing.Size(214, 88);
            this.district_info.TabIndex = 22;
            this.district_info.TabStop = false;
            this.district_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.district_info.UseSystemPasswordChar = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(17, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Info";
            // 
            // District_delete
            // 
            this.District_delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.District_delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.District_delete.Depth = 0;
            this.District_delete.Enabled = false;
            this.District_delete.HighEmphasis = true;
            this.District_delete.Icon = null;
            this.District_delete.Location = new System.Drawing.Point(246, 212);
            this.District_delete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.District_delete.MouseState = MaterialSkin.MouseState.HOVER;
            this.District_delete.Name = "District_delete";
            this.District_delete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.District_delete.Size = new System.Drawing.Size(73, 36);
            this.District_delete.TabIndex = 20;
            this.District_delete.Text = "Delete";
            this.District_delete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.District_delete.UseAccentColor = false;
            this.District_delete.UseVisualStyleBackColor = true;
            this.District_delete.Click += new System.EventHandler(this.District_delete_Click);
            // 
            // District_update
            // 
            this.District_update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.District_update.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.District_update.Depth = 0;
            this.District_update.Enabled = false;
            this.District_update.HighEmphasis = true;
            this.District_update.Icon = null;
            this.District_update.Location = new System.Drawing.Point(124, 212);
            this.District_update.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.District_update.MouseState = MaterialSkin.MouseState.HOVER;
            this.District_update.Name = "District_update";
            this.District_update.NoAccentTextColor = System.Drawing.Color.Empty;
            this.District_update.Size = new System.Drawing.Size(77, 36);
            this.District_update.TabIndex = 19;
            this.District_update.Text = "Update";
            this.District_update.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.District_update.UseAccentColor = false;
            this.District_update.UseVisualStyleBackColor = true;
            this.District_update.Click += new System.EventHandler(this.District_update_Click);
            // 
            // District_add
            // 
            this.District_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.District_add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.District_add.Depth = 0;
            this.District_add.Enabled = false;
            this.District_add.HighEmphasis = true;
            this.District_add.Icon = null;
            this.District_add.Location = new System.Drawing.Point(17, 212);
            this.District_add.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.District_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.District_add.Name = "District_add";
            this.District_add.NoAccentTextColor = System.Drawing.Color.Empty;
            this.District_add.Size = new System.Drawing.Size(64, 36);
            this.District_add.TabIndex = 18;
            this.District_add.Text = "Add";
            this.District_add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.District_add.UseAccentColor = false;
            this.District_add.UseVisualStyleBackColor = true;
            this.District_add.Click += new System.EventHandler(this.District_add_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv1);
            this.panel4.Location = new System.Drawing.Point(3, 282);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(329, 282);
            this.panel4.TabIndex = 3;
            // 
            // dgv1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 25;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv1.Size = new System.Drawing.Size(329, 282);
            this.dgv1.TabIndex = 24;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // district_name
            // 
            this.district_name.AnimateReadOnly = false;
            this.district_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.district_name.Depth = 0;
            this.district_name.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.district_name.LeadingIcon = null;
            this.district_name.Location = new System.Drawing.Point(95, 38);
            this.district_name.MaxLength = 50;
            this.district_name.MouseState = MaterialSkin.MouseState.OUT;
            this.district_name.Multiline = false;
            this.district_name.Name = "district_name";
            this.district_name.Size = new System.Drawing.Size(214, 50);
            this.district_name.TabIndex = 2;
            this.district_name.Text = "";
            this.district_name.TrailingIcon = null;
            this.district_name.TextChanged += new System.EventHandler(this.district_name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "DISTRICT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.sub_info);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.County_delete);
            this.panel2.Controls.Add(this.County_update);
            this.panel2.Controls.Add(this.County_add);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.sub_name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Sub);
            this.panel2.Location = new System.Drawing.Point(363, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 565);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(249, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Clear fields";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // sub_info
            // 
            this.sub_info.AnimateReadOnly = false;
            this.sub_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sub_info.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.sub_info.Depth = 0;
            this.sub_info.HideSelection = true;
            this.sub_info.Location = new System.Drawing.Point(95, 115);
            this.sub_info.MaxLength = 32767;
            this.sub_info.MouseState = MaterialSkin.MouseState.OUT;
            this.sub_info.Name = "sub_info";
            this.sub_info.PasswordChar = '\0';
            this.sub_info.ReadOnly = false;
            this.sub_info.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sub_info.SelectedText = "";
            this.sub_info.SelectionLength = 0;
            this.sub_info.SelectionStart = 0;
            this.sub_info.ShortcutsEnabled = true;
            this.sub_info.Size = new System.Drawing.Size(214, 88);
            this.sub_info.TabIndex = 32;
            this.sub_info.TabStop = false;
            this.sub_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.sub_info.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(17, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Info";
            // 
            // County_delete
            // 
            this.County_delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.County_delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.County_delete.Depth = 0;
            this.County_delete.Enabled = false;
            this.County_delete.HighEmphasis = true;
            this.County_delete.Icon = null;
            this.County_delete.Location = new System.Drawing.Point(245, 212);
            this.County_delete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.County_delete.MouseState = MaterialSkin.MouseState.HOVER;
            this.County_delete.Name = "County_delete";
            this.County_delete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.County_delete.Size = new System.Drawing.Size(73, 36);
            this.County_delete.TabIndex = 30;
            this.County_delete.Text = "Delete";
            this.County_delete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.County_delete.UseAccentColor = false;
            this.County_delete.UseVisualStyleBackColor = true;
            this.County_delete.Click += new System.EventHandler(this.County_delete_Click);
            // 
            // County_update
            // 
            this.County_update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.County_update.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.County_update.Depth = 0;
            this.County_update.Enabled = false;
            this.County_update.HighEmphasis = true;
            this.County_update.Icon = null;
            this.County_update.Location = new System.Drawing.Point(123, 212);
            this.County_update.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.County_update.MouseState = MaterialSkin.MouseState.HOVER;
            this.County_update.Name = "County_update";
            this.County_update.NoAccentTextColor = System.Drawing.Color.Empty;
            this.County_update.Size = new System.Drawing.Size(77, 36);
            this.County_update.TabIndex = 29;
            this.County_update.Text = "Update";
            this.County_update.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.County_update.UseAccentColor = false;
            this.County_update.UseVisualStyleBackColor = true;
            this.County_update.Click += new System.EventHandler(this.County_update_Click);
            // 
            // County_add
            // 
            this.County_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.County_add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.County_add.Depth = 0;
            this.County_add.Enabled = false;
            this.County_add.HighEmphasis = true;
            this.County_add.Icon = null;
            this.County_add.Location = new System.Drawing.Point(16, 212);
            this.County_add.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.County_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.County_add.Name = "County_add";
            this.County_add.NoAccentTextColor = System.Drawing.Color.Empty;
            this.County_add.Size = new System.Drawing.Size(64, 36);
            this.County_add.TabIndex = 28;
            this.County_add.Text = "Add";
            this.County_add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.County_add.UseAccentColor = false;
            this.County_add.UseVisualStyleBackColor = true;
            this.County_add.Click += new System.EventHandler(this.County_add_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv2);
            this.panel5.Location = new System.Drawing.Point(3, 282);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(329, 280);
            this.panel5.TabIndex = 27;
            // 
            // dgv2
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2.EnableHeadersVisualStyles = false;
            this.dgv2.Location = new System.Drawing.Point(0, 0);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.RowTemplate.Height = 25;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv2.Size = new System.Drawing.Size(329, 280);
            this.dgv2.TabIndex = 24;
            this.dgv2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellClick);
            // 
            // sub_name
            // 
            this.sub_name.AnimateReadOnly = false;
            this.sub_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sub_name.Depth = 0;
            this.sub_name.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.sub_name.LeadingIcon = null;
            this.sub_name.Location = new System.Drawing.Point(95, 38);
            this.sub_name.MaxLength = 50;
            this.sub_name.MouseState = MaterialSkin.MouseState.OUT;
            this.sub_name.Multiline = false;
            this.sub_name.Name = "sub_name";
            this.sub_name.Size = new System.Drawing.Size(214, 50);
            this.sub_name.TabIndex = 26;
            this.sub_name.Text = "";
            this.sub_name.TrailingIcon = null;
            this.sub_name.TextChanged += new System.EventHandler(this.sub_name_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(16, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Name";
            // 
            // Sub
            // 
            this.Sub.AutoSize = true;
            this.Sub.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Sub.ForeColor = System.Drawing.Color.White;
            this.Sub.Location = new System.Drawing.Point(3, 0);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(113, 25);
            this.Sub.TabIndex = 1;
            this.Sub.Text = "SUBCOUNTY";
            this.Sub.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.village_info);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.materialButton7);
            this.panel3.Controls.Add(this.materialButton8);
            this.panel3.Controls.Add(this.materialButton9);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.village_name);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.Vill);
            this.panel3.Location = new System.Drawing.Point(713, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 565);
            this.panel3.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label10.Location = new System.Drawing.Point(245, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Clear fields";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // village_info
            // 
            this.village_info.AnimateReadOnly = false;
            this.village_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.village_info.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.village_info.Depth = 0;
            this.village_info.HideSelection = true;
            this.village_info.Location = new System.Drawing.Point(95, 115);
            this.village_info.MaxLength = 32767;
            this.village_info.MouseState = MaterialSkin.MouseState.OUT;
            this.village_info.Name = "village_info";
            this.village_info.PasswordChar = '\0';
            this.village_info.ReadOnly = false;
            this.village_info.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.village_info.SelectedText = "";
            this.village_info.SelectionLength = 0;
            this.village_info.SelectionStart = 0;
            this.village_info.ShortcutsEnabled = true;
            this.village_info.Size = new System.Drawing.Size(214, 88);
            this.village_info.TabIndex = 33;
            this.village_info.TabStop = false;
            this.village_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.village_info.UseSystemPasswordChar = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(17, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 25);
            this.label9.TabIndex = 32;
            this.label9.Text = "Info";
            // 
            // materialButton7
            // 
            this.materialButton7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton7.Depth = 0;
            this.materialButton7.Enabled = false;
            this.materialButton7.HighEmphasis = true;
            this.materialButton7.Icon = null;
            this.materialButton7.Location = new System.Drawing.Point(245, 212);
            this.materialButton7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton7.Name = "materialButton7";
            this.materialButton7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton7.Size = new System.Drawing.Size(73, 36);
            this.materialButton7.TabIndex = 31;
            this.materialButton7.Text = "Delete";
            this.materialButton7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton7.UseAccentColor = false;
            this.materialButton7.UseVisualStyleBackColor = true;
            this.materialButton7.Click += new System.EventHandler(this.materialButton7_Click);
            // 
            // materialButton8
            // 
            this.materialButton8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton8.Depth = 0;
            this.materialButton8.Enabled = false;
            this.materialButton8.HighEmphasis = true;
            this.materialButton8.Icon = null;
            this.materialButton8.Location = new System.Drawing.Point(123, 212);
            this.materialButton8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton8.Name = "materialButton8";
            this.materialButton8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton8.Size = new System.Drawing.Size(77, 36);
            this.materialButton8.TabIndex = 30;
            this.materialButton8.Text = "Update";
            this.materialButton8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton8.UseAccentColor = false;
            this.materialButton8.UseVisualStyleBackColor = true;
            this.materialButton8.Click += new System.EventHandler(this.materialButton8_Click);
            // 
            // materialButton9
            // 
            this.materialButton9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton9.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton9.Depth = 0;
            this.materialButton9.Enabled = false;
            this.materialButton9.HighEmphasis = true;
            this.materialButton9.Icon = null;
            this.materialButton9.Location = new System.Drawing.Point(16, 212);
            this.materialButton9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton9.Name = "materialButton9";
            this.materialButton9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton9.Size = new System.Drawing.Size(64, 36);
            this.materialButton9.TabIndex = 29;
            this.materialButton9.Text = "Add";
            this.materialButton9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton9.UseAccentColor = false;
            this.materialButton9.UseVisualStyleBackColor = true;
            this.materialButton9.Click += new System.EventHandler(this.materialButton9_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgv3);
            this.panel6.Location = new System.Drawing.Point(3, 282);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(329, 280);
            this.panel6.TabIndex = 28;
            // 
            // dgv3
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.dgv3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgv3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv3.EnableHeadersVisualStyles = false;
            this.dgv3.Location = new System.Drawing.Point(0, 0);
            this.dgv3.Name = "dgv3";
            this.dgv3.RowHeadersVisible = false;
            this.dgv3.RowTemplate.Height = 25;
            this.dgv3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv3.Size = new System.Drawing.Size(329, 280);
            this.dgv3.TabIndex = 24;
            this.dgv3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv3_CellClick);
            // 
            // village_name
            // 
            this.village_name.AnimateReadOnly = false;
            this.village_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.village_name.Depth = 0;
            this.village_name.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.village_name.LeadingIcon = null;
            this.village_name.Location = new System.Drawing.Point(95, 38);
            this.village_name.MaxLength = 50;
            this.village_name.MouseState = MaterialSkin.MouseState.OUT;
            this.village_name.Multiline = false;
            this.village_name.Name = "village_name";
            this.village_name.Size = new System.Drawing.Size(214, 50);
            this.village_name.TabIndex = 26;
            this.village_name.Text = "";
            this.village_name.TrailingIcon = null;
            this.village_name.TextChanged += new System.EventHandler(this.village_name_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(18, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Name";
            // 
            // Vill
            // 
            this.Vill.AutoSize = true;
            this.Vill.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Vill.ForeColor = System.Drawing.Color.White;
            this.Vill.Location = new System.Drawing.Point(3, 0);
            this.Vill.Name = "Vill";
            this.Vill.Size = new System.Drawing.Size(78, 25);
            this.Vill.TabIndex = 1;
            this.Vill.Text = "VILLAGE";
            // 
            // Location
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1092, 582);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Location";
            this.Text = "Location";
            this.Load += new System.EventHandler(this.Location_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label Sub;
        private Panel panel3;
        private Label Vill;
        private MaterialSkin.Controls.MaterialTextBox district_name;
        private Label label4;
        private MaterialSkin.Controls.MaterialTextBox sub_name;
        private Label label5;
        private MaterialSkin.Controls.MaterialTextBox village_name;
        private Label label6;
        private Panel panel4;
        private Components.DGV dgv1;
        private Panel panel5;
        private Components.DGV dgv2;
        private Panel panel6;
        private Components.DGV dgv3;
        private MaterialSkin.Controls.MaterialButton District_delete;
        private MaterialSkin.Controls.MaterialButton District_update;
        private MaterialSkin.Controls.MaterialButton District_add;
        private MaterialSkin.Controls.MaterialButton County_delete;
        private MaterialSkin.Controls.MaterialButton County_update;
        private MaterialSkin.Controls.MaterialButton County_add;
        private MaterialSkin.Controls.MaterialButton materialButton7;
        private MaterialSkin.Controls.MaterialButton materialButton8;
        private MaterialSkin.Controls.MaterialButton materialButton9;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 district_info;
        private Label label7;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 sub_info;
        private Label label8;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 village_info;
        private Label label9;
        private Label CF_districts;
        private Label label3;
        private Label label10;
    }
}