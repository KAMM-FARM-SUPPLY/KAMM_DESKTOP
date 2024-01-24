namespace KAMM_FARM_SERVICES.UI.ExpenditureForms
{
    partial class AddExpenditureCategory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.name = new MaterialSkin.Controls.MaterialTextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label23 = new System.Windows.Forms.Label();
            this.add = new MaterialSkin.Controls.MaterialButton();
            this.update = new MaterialSkin.Controls.MaterialButton();
            this.delete = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv1 = new KAMM_FARM_SERVICES.Components.DGV();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AnimateReadOnly = false;
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.name.LeadingIcon = null;
            this.name.Location = new System.Drawing.Point(124, 75);
            this.name.MaxLength = 50;
            this.name.MouseState = MaterialSkin.MouseState.OUT;
            this.name.Multiline = false;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(250, 50);
            this.name.TabIndex = 72;
            this.name.Text = "";
            this.name.TrailingIcon = null;
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label74.Location = new System.Drawing.Point(19, 87);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(58, 20);
            this.label74.TabIndex = 71;
            this.label74.Text = "Name :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(19, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 73;
            this.label1.Text = "Description : ";
            // 
            // Description
            // 
            this.Description.AnimateReadOnly = false;
            this.Description.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Description.Depth = 0;
            this.Description.HideSelection = true;
            this.Description.Location = new System.Drawing.Point(124, 166);
            this.Description.MaxLength = 32767;
            this.Description.MouseState = MaterialSkin.MouseState.OUT;
            this.Description.Name = "Description";
            this.Description.PasswordChar = '\0';
            this.Description.ReadOnly = false;
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Description.SelectedText = "";
            this.Description.SelectionLength = 0;
            this.Description.SelectionStart = 0;
            this.Description.ShortcutsEnabled = true;
            this.Description.Size = new System.Drawing.Size(250, 100);
            this.Description.TabIndex = 74;
            this.Description.TabStop = false;
            this.Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Description.UseSystemPasswordChar = false;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label23.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Silver;
            this.label23.Location = new System.Drawing.Point(29, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(212, 30);
            this.label23.TabIndex = 75;
            this.label23.Text = "Expenditure Category";
            // 
            // add
            // 
            this.add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.add.Depth = 0;
            this.add.HighEmphasis = true;
            this.add.Icon = null;
            this.add.Location = new System.Drawing.Point(327, 330);
            this.add.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.add.MouseState = MaterialSkin.MouseState.HOVER;
            this.add.Name = "add";
            this.add.NoAccentTextColor = System.Drawing.Color.Empty;
            this.add.Size = new System.Drawing.Size(64, 36);
            this.add.TabIndex = 76;
            this.add.Text = "ADD";
            this.add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.add.UseAccentColor = false;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // update
            // 
            this.update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.update.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.update.Depth = 0;
            this.update.HighEmphasis = true;
            this.update.Icon = null;
            this.update.Location = new System.Drawing.Point(488, 330);
            this.update.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.update.MouseState = MaterialSkin.MouseState.HOVER;
            this.update.Name = "update";
            this.update.NoAccentTextColor = System.Drawing.Color.Empty;
            this.update.Size = new System.Drawing.Size(77, 36);
            this.update.TabIndex = 77;
            this.update.Text = "UPDATE";
            this.update.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.update.UseAccentColor = false;
            this.update.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.delete.Depth = 0;
            this.delete.HighEmphasis = true;
            this.delete.Icon = null;
            this.delete.Location = new System.Drawing.Point(658, 330);
            this.delete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delete.MouseState = MaterialSkin.MouseState.HOVER;
            this.delete.Name = "delete";
            this.delete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.delete.Size = new System.Drawing.Size(73, 36);
            this.delete.TabIndex = 78;
            this.delete.Text = "DELETE";
            this.delete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.delete.UseAccentColor = false;
            this.delete.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv1);
            this.panel1.Location = new System.Drawing.Point(398, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 246);
            this.panel1.TabIndex = 79;
            // 
            // dgv1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 25;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv1.Size = new System.Drawing.Size(368, 246);
            this.dgv1.TabIndex = 25;
            // 
            // AddExpenditureCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(778, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label74);
            this.Name = "AddExpenditureCategory";
            this.Text = "AddExpenditureCategory";
            this.Load += new System.EventHandler(this.AddExpenditureCategory_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox name;
        private Label label74;
        private Label label1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 Description;
        private Label label23;
        private MaterialSkin.Controls.MaterialButton add;
        private MaterialSkin.Controls.MaterialButton update;
        private MaterialSkin.Controls.MaterialButton delete;
        private Panel panel1;
        private Components.DGV dgv1;
    }
}