using System;
using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Entity.Enum;

namespace WPFClient.EduInfoForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeachersSalaryEdit.xaml
    /// </summary>
    public partial class FormTeachersSalaryEdit : Window
    {
        public Payment Payment { get; set; }

        public FormTeachersSalaryEdit()
        {
            InitializeComponent();
        }

        public FormTeachersSalaryEdit(Payment payment) : this()
        {
            Payment = payment;
        }

        private void FormTeachersSalaryEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxAppointment.ItemsSource = Enum.GetValues(typeof (Appointment)).Cast<Appointment>();

            if (Payment != null)
            {
                ComboBoxAppointment.Text = Payment.Appointment.ToString();
                TextBoxAppointmentSub.Text = Payment.AppointmentSub;
                TextBoxSalary.Text = Convert.ToString(Payment.Salary);
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(Payment == null)
                Payment = new Payment();

            Payment.Appointment = ComboBoxAppointment.SelectedItem is Appointment ? (Appointment) ComboBoxAppointment.SelectedItem : (Appointment) 0;
            Payment.AppointmentSub = TextBoxAppointmentSub.Text;
            Payment.Salary = Convert.ToInt32(TextBoxSalary.Text);

            if (Payment.AppointmentSub == String.Empty || Payment.Salary == 0)
            {
                MessageBox.Show("Одне або декілька полів не заповнені !");
                return;
            }

            DialogResult = true;
        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
