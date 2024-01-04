namespace KAMM_FARM_SERVICES.UI.LoanVisitsForms
{
    partial class CreateVisit
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
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label23.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Silver;
            this.label23.Location = new System.Drawing.Point(12, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(138, 30);
            this.label23.TabIndex = 14;
            this.label23.Text = "Create A Visit";
            // 
            // CreateVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(502, 242);
            this.Controls.Add(this.label23);
            this.Name = "CreateVisit";
            this.Text = "CreateVisit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label23;
    }
}