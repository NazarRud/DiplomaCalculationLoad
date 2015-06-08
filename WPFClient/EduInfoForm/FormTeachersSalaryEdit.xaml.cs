using System;
using System.Collections.Generic;
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
        private readonly List<PaymentForYears> _paymentForYearses = new List<PaymentForYears>();
        public FormTeachersSalaryEdit()
        {
            InitializeComponent();
        }

        public FormTeachersSalaryEdit(Payment payment)
            : this()
        {
            Payment = payment;
        }

        private void FormTeachersSalaryEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxAppointment.ItemsSource = Enum.GetValues(typeof(Appointment)).Cast<Appointment>();
            ComboBoxYearsCount.ItemsSource = Enum.GetValues(typeof(YearsCount)).Cast<YearsCount>();

            if (Payment != null)
            {
                ComboBoxAppointment.Text = Payment.Appointment.ToString();
                TextBoxAppointmentSub.Text = Payment.AppointmentSub;
                TextBoxSalary.Text = Convert.ToString(Payment.Salary);
                DataGridPaymentForYears.ItemsSource = Payment.PaymentForYearses;
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Payment == null)
                Payment = new Payment();

            Payment.Appointment = ComboBoxAppointment.SelectedItem is Appointment ? (Appointment)ComboBoxAppointment.SelectedItem : (Appointment)0;
            Payment.AppointmentSub = TextBoxAppointmentSub.Text;
            Payment.Salary = Convert.ToInt32(TextBoxSalary.Text);
            Payment.PaymentForYearses = DataGridPaymentForYears.ItemsSource as List<PaymentForYears>;

            if (Payment.AppointmentSub == String.Empty || Payment.Salary == 0 || DataGridPaymentForYears.ItemsSource == null)
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

        private void AddYearsCountToDataGrid_OnClick(object sender, RoutedEventArgs e)
        {
            var temp = new PaymentForYears
             {
                 YearsCount = ComboBoxYearsCount.SelectedItem is YearsCount ? (YearsCount)ComboBoxYearsCount.SelectedItem : (YearsCount)0,
                 Allowance = Convert.ToInt32(TextBoxAllowance.Text),
                 Percentage = Convert.ToInt32(TextBoxPercentage.Text)
             };

            _paymentForYearses.Add(temp);

            DataGridPaymentForYears.ItemsSource = null;
            DataGridPaymentForYears.ItemsSource = _paymentForYearses;

        }
    }
}
