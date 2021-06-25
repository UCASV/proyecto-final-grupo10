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
using Project.View;

namespace Project.View
{
    public partial class FrmMain : Form
    {
        public Manager manager { get; set; }
        public FrmMain(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblManager.Text = "Bienvenido: " + manager.ManagerName + 
                " encargado de la cabina ubicada en " + manager.IdCabinNavigation.Adress;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            frmNewUser Window = new frmNewUser(manager);
            Window.ShowDialog();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnFollowApp_Click(object sender, EventArgs e)
        {
            FrmFollowAppointment Window = new FrmFollowAppointment();
            Window.ShowDialog();
        }

        private void btnSecondDate_Click(object sender, EventArgs e)
        {
            FrmSecondDate Window = new FrmSecondDate(manager);
            Window.ShowDialog();
        }
    }
}
