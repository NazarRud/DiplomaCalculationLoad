using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoad.xaml
    /// </summary>
    public partial class FormTeacherLoad : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormTeacherLoad()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormTeacherLoad_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSubject.ItemsSource = _uow.Subject.All.ToList();
            ComboBoxSubject.DisplayMemberPath = "Name";
            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormTeacherLoadEdit formTeacherLoadEdit = new FormTeacherLoadEdit();
            if (formTeacherLoadEdit.ShowDialog() == true)
            {
                foreach (var item in formTeacherLoadEdit.ListTeacherLoads)
                {
                    _uow.TeacherLoad.InsertOrUpdate(item);
                    _uow.Save();
                }             
            }
            else
            {
                formTeacherLoadEdit.Close();
            }

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var listTeacherLoads = DataGridTeacherLoad.ItemsSource as List<TeacherLoad>;
            if (ComboBoxSubject.SelectedItem == null)
            {
                MessageBox.Show("Виберіть предмет для редагування !");
                return;
            }

            FormTeacherLoadEdit formTeacherLoadEdit = new FormTeacherLoadEdit(listTeacherLoads);
            if (formTeacherLoadEdit.ShowDialog() == true)
            {
                foreach (var item in formTeacherLoadEdit.ListTeacherLoads)
                {
                    _uow.TeacherLoad.InsertOrUpdate(item);
                    _uow.Save();
                }
            }
            else
            {
                formTeacherLoadEdit.Close();
            }

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSubject.SelectedItem == null)
            {
                MessageBox.Show("Виберіть дисципліну для видалення !");
                return;
            }

            var selectedSubject = DataGridTeacherLoad.ItemsSource as List<TeacherLoad>;
            if (selectedSubject == null)
            {
                MessageBox.Show("Виберіть дисципліну для видалення !");
                return;
            }
            foreach (var teacherLoad in selectedSubject)
            {
                _uow.TeacherLoad.Delete(teacherLoad.Id);
                _uow.Save();
            }          

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void ComboBoxsubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxSubject.SelectedItem as Subject;
            if(selected == null) return;
            var findSubject = _uow.Subject.Find(selected.Id);
            DataGridTeacherLoad.ItemsSource = findSubject.TeacherLoad.ToList();
        }
    }
}
