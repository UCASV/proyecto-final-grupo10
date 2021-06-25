using Project.Context;
using Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.View
{
    public partial class FrmSecondDate : Form
    {
        public Manager manager { get; set; }
        private CitizenServices citizens;
        private SideEffectServices sideEffects;
        private AppointmentServices appointments;
        private VaccinationServices vaccinations;
        private CitizenxVaccinationServices citizenxvaccinations;
        private CabinServices cabins;
        public FrmSecondDate(Manager manager)
        {
            InitializeComponent();
            citizens = new CitizenServices();
            sideEffects = new SideEffectServices();
            appointments = new AppointmentServices();
            vaccinations = new VaccinationServices();
            citizenxvaccinations = new CitizenxVaccinationServices();
            cabins = new CabinServices();
            this.manager = manager;
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            var ListCitizens = citizens.GetAll();
            List<Citizen> VerifyCitizen = ListCitizens.Where(c => c.Dui == txtDUI.Text).ToList();

            var ListAppointment = appointments.GetAll();
            List<Appointment> VerifyAppointment = ListAppointment
                .Where(a => a.IdTypeAppointment == 2 && a.IdCitizen == txtDUI.Text).ToList();

            if (VerifyCitizen.Count == 0)
            {
                MessageBox.Show("Este DUI de ciudadano no esta registrado!", "MSPAS",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(VerifyAppointment.Count >0)
            {
                MessageBox.Show("Este ciudadano ya ha sido vacunado!", "MSPAS",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Ingresando a " + VerifyCitizen[0].Cname, "MSPAS",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 1;
            }
        }

        private Random r = new Random();
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var ListAppointment = appointments.GetAll();
            List<Appointment> CitizenAppointment = ListAppointment.Where(a => a.IdCitizen == txtDUI.Text).ToList();

            var vaccination = new Vaccination
            {
                Vaccinator = txtVaccinator.Text,
                EffectTime = Convert.ToInt32(nudMinutes.Value),
                VaccinationDate = CitizenAppointment[0].ReservationDate
            };
            vaccinations.Create(vaccination);

            var ListVaccination = vaccinations.GetAll();
            List<Vaccination> CitizenVaccination = ListVaccination
                .Where(v => v.VaccinationDate == CitizenAppointment[0].ReservationDate).ToList();
            if (Convert.ToInt32(nudMinutes.Value) <= 30)
            {
                if (chkDolor.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkDolor.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkEnrojecimiento.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkEnrojecimiento.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkFatiga.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkFatiga.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkDolorCabeza.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkDolorCabeza.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkFiebre.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkFiebre.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkMialgia.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkMialgia.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkArtralgia.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkArtralgia.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if (chkAnafilaxia.Checked)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = chkAnafilaxia.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                if(txtOther.TextLength > 0)
                {
                    var sideEffect = new SideEffect
                    {
                        SideEffects = txtOther.Text,
                        VaccinationId = CitizenVaccination[0].Id
                    };
                    sideEffects.Create(sideEffect);
                }
                var citizenXvaccination = new CitizenxVaccination
                {
                    CitizenId = txtDUI.Text,
                    VaccinationId = CitizenVaccination[0].Id
                };
                citizenxvaccinations.Create(citizenXvaccination);

                MessageBox.Show("Paciente vacunado, segunda cita reservada", "MSPAS",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                DateTime f = RandomDay();
                int v = r.Next(1, 5);
                var ListCabins = cabins.GetAll();
                List<Cabin> Place = ListCabins.Where(c => c.Id == v).ToList();

                var appointment = new Appointment
                {
                    Place = Place[0].Adress,
                    IdTypeAppointment = 2,
                    IdCitizen = txtDUI.Text,
                    ReservationDate = f,
                    IdManager = manager.Id,
                    ProcessDate = CitizenAppointment[0].ReservationDate
                };
                appointments.Create(appointment);
                var ListCitizens = citizens.GetAll();
                List<Citizen> VerifyCitizen = ListCitizens.Where(c => c.Dui == txtDUI.Text).ToList();
                lblName.Text = VerifyCitizen[0].Cname;
                lblPlace.Text = CitizenAppointment[0].Place;
                lbl2ndVaccination.Text = Convert.ToString(f);
                tabControl1.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("*no sé que mensaje poner", "MSPAS",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(2021, 10, 12);
            DateTime end = new DateTime(2021, 10, 26);
            int range = (end - start).Days;
            DateTime f = start.AddDays(gen.Next(range));
            return f;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
