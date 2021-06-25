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
using Project.Services;

namespace Project.View
{
    public partial class frmNewUser : Form
    {
        public Manager manager { get; set; }
        public Citizen NewCitizen { get; set; }
        private CitizenServices citizens;
        private InstitutionServices institutions;
        private CabinServices cabins;
        private AppointmentServices appointments;
        private DiseaseServices diseases;
        public frmNewUser(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
            citizens = new CitizenServices();
            institutions = new InstitutionServices();
            cabins = new CabinServices();
            appointments = new AppointmentServices();
            diseases = new DiseaseServices();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            var ListCitizens = citizens.GetAll();
            List<Citizen> VerifyCitizen = ListCitizens.Where(c => c.Dui == txtDUI.Text).ToList();
            bool p = (txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."));

            if (VerifyCitizen.Count == 0)
            {
                if (txtName.TextLength < 10)
                    MessageBox.Show("Debe ingresar su nombre completo!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (!(txtDUI.TextLength == 10) && !txtDUI.Text.Contains("-"))
                {
                    MessageBox.Show("Su registro de DUI no es correcto!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToInt32(nudAge.Value) < 18)
                {
                    MessageBox.Show("No se puede ingresar a un menor de edad!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (p == false)
                {
                    MessageBox.Show("Su registro de correo electronico no es correcto!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToInt32(txtPhone.Text) < 9999999)
                {
                    MessageBox.Show("Numero de telefono invalido!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtAdress.TextLength < 10)
                {
                    MessageBox.Show("Direccion invalida invalida!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Usted ya esta realizando un proceso de vacunacion!", "MSPAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private Random r = new Random();
        private void btnComplete_Click(object sender, EventArgs e)
        {
            EssentialInstitution institution = new EssentialInstitution();
            institution = (EssentialInstitution)cmbInstitution.SelectedItem;


            if (
                Convert.ToInt32(nudAge.Value) >= 60 || institution.EssentialInstitution1 == "Salud" || institution.EssentialInstitution1 == "PNC"
                || institution.EssentialInstitution1 == "Fuerza armada" || institution.EssentialInstitution1 == "Frontera"
                || institution.EssentialInstitution1 == "Gobierno" || (Convert.ToInt32(nudAge.Value) >= 18 && (chkAlz.Checked || chkAsm.Checked
                || chkCan.Checked || chkDiab.Checked || chkEpi.Checked || chkPark.Checked))
                )
            {
                DateTime f = RandomDay();
                var db = new ProjectContext();
                EssentialInstitution BDD = db.Set<EssentialInstitution>().
                    SingleOrDefault(e => e.Id == institution.Id);

                var citizen = new Citizen
                {
                    Dui = txtDUI.Text,
                    Cname = txtName.Text,
                    Age = Convert.ToInt32(nudAge.Value),
                    PhoneNumber = Convert.ToInt32(txtPhone.Text),
                    Email = txtEmail.Text,
                    Adress = txtAdress.Text,
                    IdEssentialInstitution = BDD.Id
                };

                citizens.Create(citizen);
                MessageBox.Show("Usuario Registrado exitosamente!", "MSPAS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chkAlz.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkAlz.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }
                if (chkCan.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkCan.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }
                if (chkEpi.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkEpi.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }
                if (chkVIH.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkVIH.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }
                if (chkPark.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkPark.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }
                if (chkAsm.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkAsm.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }
                if (chkDiab.Checked)
                {
                    var disease = new Disease
                    {
                        Disease1 = chkDiab.Text,
                        IdCitizen = txtDUI.Text
                    };
                    diseases.Create(disease);
                }

                
                int v = r.Next(1, 5);

                var ListCabins = cabins.GetAll();
                List<Cabin> Place = ListCabins.Where(c => c.Id == v).ToList();

                var appointment = new Appointment
                {
                    Place = Place[0].Adress,
                    IdTypeAppointment = 1,
                    IdManager = manager.Id,
                    IdCitizen = txtDUI.Text,
                    ReservationDate = f,
                    ProcessDate = DateTime.Now
                };

                lblNameCitizen.Text = txtName.Text;
                lblDateReservation.Text = Convert.ToString(f);
                lblPlace.Text = Place[0].Adress;
                appointments.Create(appointment);

                tabControl1.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Lo sentimos, usted no pertenece a un grupo prioritario", "MSPAS",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        


        private void frmNewUser_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 1);
            cmbInstitution.DataSource = institutions.GetAll();
            cmbInstitution.DisplayMember = "EssentialInstitution1";
            cmbInstitution.ValueMember = "Id";
        }
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime end = new DateTime(2021, 8, 31);
            int range = (end - DateTime.Today).Days;
            DateTime f = DateTime.Now.AddDays(gen.Next(range));
            f.AddHours(4);
            return f;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

