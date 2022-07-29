﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using AppointIT.Model.Models;
using AppointIT.WinUI.helper;

namespace AppointIT.WinUI
{
    public partial class frmLogin : Form
    {
        ApiService _baseUserService = new ApiService("BaseUser");
        ApiService _employeeService = new ApiService("Employee");

        public frmLogin()
        {
            InitializeComponent();
        }


        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            ApiService.UserName = txtUserName.Text;
            ApiService.Password = txtPassword.Text;

            try
            {
                if (ValidateChildren())
                {
                    var result = await _baseUserService.GetAll<IEnumerable<BaseUser>>();
                    BaseUser user = result?.FirstOrDefault(x => x.Email == ApiService.UserName);

                    if (user != null)
                    {
                        ApiService.UserRoles = user?.BaseUserRoles.ToList();
                        var employee = await _employeeService.GetById<Employee>(user.Id);
                        if (employee != null)
                            ApiService.CurrentUserSalonId = employee.SalonId;

                        frmParent frmParent = new frmParent();
                        this.Hide();
                        frmParent.Show();
                    }
                    else
                    {
                        MessageBox.Show(Resource.ErrorMsgUserNameOrPassword);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ErrorMsg);
            }


        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(txtUserName, e, errorProvider, Resource.RequiredField);
        }

       
        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(txtPassword, e, errorProvider, Resource.RequiredField);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
