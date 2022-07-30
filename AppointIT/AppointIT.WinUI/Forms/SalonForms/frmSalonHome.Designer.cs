
using System.Windows.Forms;

namespace AppointIT.WinUI.SalonForms
{
    partial class frmSalonHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalonHome));
            this.dgvSalons = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchSalon = new System.Windows.Forms.TextBox();
            this.btnAddSalon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchSalon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalons)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalons
            // 
            this.dgvSalons.AllowUserToAddRows = false;
            this.dgvSalons.AllowUserToDeleteRows = false;
            this.dgvSalons.AllowUserToResizeColumns = false;
            this.dgvSalons.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalons.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSalons.Location = new System.Drawing.Point(24, 189);
            this.dgvSalons.Name = "dgvSalons";
            this.dgvSalons.ReadOnly = true;
            this.dgvSalons.RowHeadersWidth = 51;
            this.dgvSalons.RowTemplate.Height = 24;
            this.dgvSalons.Size = new System.Drawing.Size(605, 392);
            this.dgvSalons.TabIndex = 0;
            this.dgvSalons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalons_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(29, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unesite naziv";
            // 
            // txtSearchSalon
            // 
            this.txtSearchSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchSalon.Location = new System.Drawing.Point(28, 118);
            this.txtSearchSalon.Multiline = true;
            this.txtSearchSalon.Name = "txtSearchSalon";
            this.txtSearchSalon.Size = new System.Drawing.Size(242, 29);
            this.txtSearchSalon.TabIndex = 1;
            // 
            // btnAddSalon
            // 
            this.btnAddSalon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddSalon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddSalon.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSalon.Image")));
            this.btnAddSalon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSalon.Location = new System.Drawing.Point(505, 103);
            this.btnAddSalon.Name = "btnAddSalon";
            this.btnAddSalon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAddSalon.Size = new System.Drawing.Size(129, 44);
            this.btnAddSalon.TabIndex = 4;
            this.btnAddSalon.Text = "Dodajte salon";
            this.btnAddSalon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSalon.UseVisualStyleBackColor = false;
            this.btnAddSalon.Click += new System.EventHandler(this.btnAddSalon_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(650, 66);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(276, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Saloni";
            // 
            // btnSearchSalon
            // 
            this.btnSearchSalon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.btnSearchSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSalon.ForeColor = System.Drawing.Color.White;
            this.btnSearchSalon.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSalon.Image")));
            this.btnSearchSalon.Location = new System.Drawing.Point(276, 118);
            this.btnSearchSalon.Name = "btnSearchSalon";
            this.btnSearchSalon.Size = new System.Drawing.Size(36, 31);
            this.btnSearchSalon.TabIndex = 8;
            this.btnSearchSalon.UseVisualStyleBackColor = false;
            this.btnSearchSalon.Click += new System.EventHandler(this.btnSearchSalon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(24, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Prikaz salona";
            // 
            // frmSalonHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 604);
            this.Controls.Add(this.dgvSalons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearchSalon);
            this.Controls.Add(this.txtSearchSalon);
            this.Controls.Add(this.btnAddSalon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalonHome";
            this.Text = "frmSalonHome";
            this.Load += new System.EventHandler(this.frmSalonHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalons)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchSalon;
        private System.Windows.Forms.Button btnAddSalon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchSalon;
        private System.Windows.Forms.Label label3;
    }
}