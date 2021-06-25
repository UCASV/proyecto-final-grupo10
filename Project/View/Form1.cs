using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Context;
using Microsoft.EntityFrameworkCore;
using Project.View;
using Project.Services;


namespace Project
{
    public partial class Form1 : Form
    {
        private LoginRegisterServices loginregisters;
        public Form1()
        {
            InitializeComponent();
            loginregisters = new LoginRegisterServices();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var db = new ProjectContext();
            var ManagerList = db.Managers
                .Include(m => m.IdCabinNavigation)
                .Include(m => m.IdEmployeeTypeNavigation)
                .OrderBy(m => m.Id)
                .ToList();

            string user = txtUser.Text;
            string password = txtPassword.Text;

            List<Manager> Result = ManagerList
                .Where(m => m.ManagerUser == user &&
                            m.Mpassword == password)
                .ToList();

            if (Result.Count() > 0)
            {
                MessageBox.Show("Bienvenido!", "MSPAS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var loginregister = new LoginRegister
                {
                    ManagerName = Result[0].ManagerName,
                    ManagerEmail = Result[0].Email,
                    CabinAdress = Result[0].IdCabinNavigation.Adress,
                    CabinEmail = Result[0].IdCabinNavigation.Email,
                    RegisterDate = DateTime.Now
                };

                loginregisters.Create(loginregister);
                FrmMain Window = new FrmMain(Result[0]);
                Window.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Usuario no existe!", "MSPAS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
