namespace KAMM_FARM_SERVICES.UI.ExpenditureForms
{
    partial class AddExpenditure
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
            this.label74 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.amount = new MaterialSkin.Controls.MaterialTextBox();
            this.description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label23 = new System.Windows.Forms.Label();
            this.add = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label74.Location = new System.Drawing.Point(23, 78);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(80, 20);
            this.label74.TabIndex = 66;
            this.label74.Text = "Category :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(21, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 67;
            this.label1.Text = "Amount :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(21, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "Description :";
            // 
            // amount
            // 
            this.amount.AnimateReadOnly = false;
            this.amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amount.Depth = 0;
            this.amount.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.amount.LeadingIcon = null;
            this.amount.Location = new System.Drawing.Point(177, 133);
            this.amount.MaxLength = 50;
            this.amount.MouseState = MaterialSkin.MouseState.OUT;
            this.amount.Multiline = false;
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(197, 50);
            this.amount.TabIndex = 70;
            this.amount.Text = "";
            this.amount.TrailingIcon = null;
            // 
            // description
            // 
            this.description.AnimateReadOnly = false;
            this.description.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.description.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.description.Depth = 0;
            this.description.HideSelection = true;
            this.description.Location = new System.Drawing.Point(177, 203);
            this.description.MaxLength = 32767;
            this.description.MouseState = MaterialSkin.MouseState.OUT;
            this.description.Name = "description";
            this.description.PasswordChar = '\0';
            this.description.ReadOnly = false;
            this.description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.description.SelectedText = "";
            this.description.SelectionLength = 0;
            this.description.SelectionStart = 0;
            this.description.ShortcutsEnabled = true;
            this.description.Size = new System.Drawing.Size(204, 89);
            this.description.TabIndex = 71;
            this.description.TabStop = false;
            this.description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.description.UseSystemPasswordChar = false;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label23.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Silver;
            this.label23.Location = new System.Drawing.Point(23, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(195, 30);
            this.label23.TabIndex = 72;
            this.label23.Text = "ADD EXPENDITURE";
            // 
            // add
            // 
            this.add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.add.Depth = 0;
            this.add.HighEmphasis = true;
            this.add.Icon = null;
            this.add.Location = new System.Drawing.Point(369, 301);
            this.add.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.add.MouseState = MaterialSkin.MouseState.HOVER;
            this.add.Name = "add";
            this.add.NoAccentTextColor = System.Drawing.Color.Empty;
            this.add.Size = new System.Drawing.Size(150, 36);
            this.add.TabIndex = 73;
            this.add.Text = "Add Expenditure";
            this.add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.add.UseAccentColor = false;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KAMM_FARM_SERVICES.Properties.Resources.plus;
            this.pictureBox1.Location = new System.Drawing.Point(394, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // materialComboBox1
            // 
            this.materialComboBox1.AutoResize = false;
            this.materialComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialComboBox1.Depth = 0;
            this.materialComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox1.DropDownHeight = 174;
            this.materialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox1.DropDownWidth = 121;
            this.materialComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialComboBox1.FormattingEnabled = true;
            this.materialComboBox1.IntegralHeight = false;
            this.materialComboBox1.ItemHeight = 43;
            this.materialComboBox1.Location = new System.Drawing.Point(177, 66);
            this.materialComboBox1.MaxDropDownItems = 4;
            this.materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox1.Name = "materialComboBox1";
            this.materialComboBox1.Size = new System.Drawing.Size(197, 49);
            this.materialComboBox1.StartIndex = 0;
            this.materialComboBox1.TabIndex = 76;
            // 
            // AddExpenditure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(532, 350);
            this.Controls.Add(this.materialComboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.description);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label74);
            this.Name = "AddExpenditure";
            this.Text = "Add Expenditure";
            this.Load += new System.EventHandler(this.AddExpenditure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label74;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox amount;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 description;
        private Label label23;
        private MaterialSkin.Controls.MaterialButton add;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
    }
}