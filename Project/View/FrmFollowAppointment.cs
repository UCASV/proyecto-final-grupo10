using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
    public partial class FrmFollowAppointment : Form
    {
        private CitizenServices citizens;
        private AppointmentServices appointments;
        private ManagerServices managers;
        public FrmFollowAppointment()
        {
            InitializeComponent();
            appointments = new AppointmentServices();
            citizens = new CitizenServices();
            managers = new ManagerServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ListCitizens = citizens.GetAll();
            List<Citizen> VerifyCitizen = ListCitizens.Where(c => c.Dui == txtDUI.Text).ToList();

            if(VerifyCitizen.Count == 0)
            {
                MessageBox.Show("Este DUI de ciudadano no esta registrado!", "MSPAS",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var ListAppointments = appointments.GetAll();
                List<Appointment> GetAppointment = ListAppointments.Where(a => a.IdCitizen == txtDUI.Text).ToList();
                CreatePDF(GetAppointment[0], VerifyCitizen[0]);
                MessageBox.Show("Su comprobante esta listo " + VerifyCitizen[0].Cname, "MSPAS",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }
        private void CreatePDF(Appointment appointment, Citizen citizen)
        {
            var ListManagers = managers.GetAll();
            List<Manager> GetManager = ListManagers.Where(m => m.Id == appointment.IdManager).ToList();

            PdfWriter pdfwriter = new PdfWriter("Informe.pdf");
            PdfDocument pdf = new PdfDocument(pdfwriter);
            Document document = new Document(pdf, PageSize.LETTER);

            document.SetMargins(60, 20, 55, 20);

            PdfFont fontColumns = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLDITALIC);
            PdfFont fontContent = PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC);

            string[] columns = { "DUI", "Ciudadano", "Fecha de la cita", "Lugar", "Cita", "Gestor Responsable" };
            float[] sizes = { 2, 4, 2, 4, 2, 4 };
            Table table = new Table(UnitValue.CreatePercentArray(sizes));
            table.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string column in columns)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(column).SetFont(fontColumns)));
            }

            table.AddCell(new Cell().Add(new Paragraph(appointment.IdCitizen).SetFont(fontContent)));
            table.AddCell(new Cell().Add(new Paragraph(citizen.Cname).SetFont(fontContent)));
            table.AddCell(new Cell().Add(new Paragraph(Convert.ToString(appointment.ReservationDate)).SetFont(fontContent)));
            table.AddCell(new Cell().Add(new Paragraph(appointment.Place).SetFont(fontContent)));
            table.AddCell(new Cell().Add(new Paragraph("Primera dosis").SetFont(fontContent)));
            table.AddCell(new Cell().Add(new Paragraph(GetManager[0].ManagerName).SetFont(fontContent)));

            document.Add(table);
            document.Close();

            var title = new Paragraph("MSPAS. Informe de Cita");
            title.SetTextAlignment(TextAlignment.CENTER);
            title.SetFontSize(14);

            PdfDocument pdfDoc = new PdfDocument(new PdfReader("Informe.pdf"), new PdfWriter
                ("Informe_" + citizen.Dui + ".pdf"));
            Document doc = new Document(pdfDoc);

            doc.ShowTextAligned(title,200, pdfDoc.GetPage(1).GetPageSize().GetTop() - 15, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            doc.Close();
        }
    }
}
