
namespace AppointIT.WinUI.ServiceForms
{
    partial class frmServiceHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceHome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnNewService = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.fpnlServices = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbSalon = new System.Windows.Forms.ComboBox();
            this.lblSalon = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(654, 66);
            this.panel1.TabIndex = 19;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(317, 21);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(80, 26);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Usluge";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnNewService);
            this.pnlButtons.Controls.Add(this.button3);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Location = new System.Drawing.Point(462, 82);
            this.pnlButtons.MaximumSize = new System.Drawing.Size(153, 122);
            this.pnlButtons.MinimumSize = new System.Drawing.Size(153, 48);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(153, 112);
            this.pnlButtons.TabIndex = 28;
            // 
            // btnNewService
            // 
            this.btnNewService.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNewService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewService.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewService.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewService.Location = new System.Drawing.Point(0, 78);
            this.btnNewService.Name = "btnNewService";
            this.btnNewService.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNewService.Size = new System.Drawing.Size(153, 33);
            this.btnNewService.TabIndex = 31;
            this.btnNewService.Text = "Nova usluga";
            this.btnNewService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewService.UseVisualStyleBackColor = false;
            this.btnNewService.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 47);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(153, 33);
            this.button3.TabIndex = 30;
            this.button3.Text = "Nova kategorija";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(153, 48);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Dodajte";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // fpnlServices
            // 
            this.fpnlServices.AutoScroll = true;
            this.fpnlServices.Location = new System.Drawing.Point(12, 160);
            this.fpnlServices.Name = "fpnlServices";
            this.fpnlServices.Size = new System.Drawing.Size(618, 398);
            this.fpnlServices.TabIndex = 29;
            // 
            // cmbSalon
            // 
            this.cmbSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSalon.FormattingEnabled = true;
            this.cmbSalon.Location = new System.Drawing.Point(39, 108);
            this.cmbSalon.Name = "cmbSalon";
            this.cmbSalon.Size = new System.Drawing.Size(127, 25);
            this.cmbSalon.TabIndex = 30;
            this.cmbSalon.SelectedIndexChanged += new System.EventHandler(this.cmbSalon_SelectedIndexChanged);
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSalon.Location = new System.Drawing.Point(36, 82);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(44, 17);
            this.lblSalon.TabIndex = 31;
            this.lblSalon.Text = "Salon";
            // 
            // frmServiceHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 604);
            this.Controls.Add(this.lblSalon);
            this.Controls.Add(this.cmbSalon);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fpnlServices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServiceHome";
            this.Text = "frmServiceHome";
            this.Load += new System.EventHandler(this.frmServiceHome_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnNewService;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel fpnlServices;
        private System.Windows.Forms.ComboBox cmbSalon;
        private System.Windows.Forms.Label lblSalon;
    }
}