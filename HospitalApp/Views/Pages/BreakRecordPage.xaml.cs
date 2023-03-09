using HospitalApp.Models;
using HospitalAppLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для BreakRecordPage.xaml
    /// </summary>
    public partial class BreakRecordPage : Page
    {
        TimeFieldsClass TestDrive = new TimeFieldsClass();
        Core db = new Core();
        public BreakRecordPage()
        {
            InitializeComponent();

            List<Doctors> doctors = db.context.Doctors.ToList();
            EventDoctorComboBox.ItemsSource = doctors.Select(doctor => doctor.FirstName + " " + doctor.LastName).ToList();

            List<TypesEvent> typesEvents = db.context.TypesEvent.ToList();
            EventTypeComboBox.ItemsSource = typesEvents.Select(typesEvent => typesEvent.TypeTitle).ToList();
            EventTypeComboBox.SelectedIndex = 0;
        }


        private void CreateSheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                !timeFieldsObj.IsRightTime(EventStartTimeTextBox.Text) ||
                !timeFieldsObj.IsRightDuration(EventDurationTextBox.Text) ||
                EventDoctorComboBox.SelectedItem == null ||
                EventTypeComboBox.SelectedItem == null
            ) {
                MessageBox.Show("Ошибка, проверьте поля ввода");
                return;
            }

            if (EventTypeComboBox.SelectedItem.ToString() == "Перерыв") {
                
            }

            MessageBox.Show("Успешно");
        }
    }
}
