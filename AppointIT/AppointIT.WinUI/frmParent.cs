﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointIT.WinUI.SalonForms;
using AppointIT.WinUI.helper;
using AppointIT.WinUI.EmployeeForms;
using AppointIT.WinUI.ServiceForms;
using AppointIT.WinUI.TermForms;
using AppointIT.WinUI.NewsForms;
using AppointIT.WinUI.CouponForms;
using AppointIT.WinUI.Report;
using AppointIT.Model.Models;

namespace AppointIT.WinUI
{
    public partial class frmParent : Form
    {
        ApiService _salonService = new ApiService("Salon");
        ApiService _customService = new ApiService("TermCustom");


        public frmParent()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            pnlParent.Controls.Clear();

            if (UserHelper.IsCurrentUserAdmin(ApiService.UserRoles))
            {
                var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
                if (salon != null)
                {
                    frmAddSalon frmAddSalon = new frmAddSalon(salon);
                    FormMaker.CreateFormFromParent(frmAddSalon, this, pnlParent);
                }
            }
            else if(UserHelper.IsCurrentUserSuAdmin(ApiService.UserRoles))
            {
                //oprez - dodati i slucaj zaposelnika
                frmSalonHome salonHome = new frmSalonHome();
                FormMaker.CreateFormFromParent(salonHome, this, pnlParent);
            }

        }

        private async void frmParent_Load(object sender, EventArgs e)
        {
            if (!UserHelper.IsCurrentUserSuAdmin(ApiService.UserRoles) || UserHelper.IsCurrentUserAdmin(ApiService.UserRoles))
            {
                btnSalon.Enabled = false;
                btnEmployee.Enabled = false;
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeHome employeeHome = new frmEmployeeHome();
            FormMaker.CreateFormFromParent(employeeHome, this, pnlParent);

        }

        private void pnlParent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnService_Click(object sender, EventArgs e)
        { 
            frmServiceHome serviceHome = new frmServiceHome();
            FormMaker.CreateFormFromParent(serviceHome, this, pnlParent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTermHome frmTermHome = new frmTermHome();
            FormMaker.CreateFormFromParent(frmTermHome, this, pnlParent);


        }

        private void btnNews_Click(object sender, EventArgs e)
        {
            frmNewsHome frmNewsHome = new frmNewsHome();
            FormMaker.CreateFormFromParent(frmNewsHome, this, pnlParent);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCouponHome frmCouponHome = new frmCouponHome();
            FormMaker.CreateFormFromParent(frmCouponHome, this, pnlParent);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmServiceReport frmServiceReport = new frmServiceReport();
            FormMaker.CreateFormFromParent(frmServiceReport, this, pnlParent);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCustomerReport frmCustomerReport = new frmCustomerReport();
            FormMaker.CreateFormFromParent(frmCustomerReport, this, pnlParent);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
