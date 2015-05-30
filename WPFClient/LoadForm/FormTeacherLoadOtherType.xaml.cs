using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoadOtherType.xaml
    /// </summary>
    public partial class FormTeacherLoadOtherType : Window
    {
        private IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormTeacherLoadOtherType()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormTeacherLoadOtherType_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTypeWork.ItemsSource = Enum.GetValues(typeof(TypeWork)).Cast<TypeWork>();
            ComboBoxSubTypeWork.ItemsSource = Enum.GetValues(typeof(SubTypeWork)).Cast<SubTypeWork>();
            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var formTeacherLoadOtherTypeEdit = new FormTeacherLoadOtherTypeEdit();
            if (formTeacherLoadOtherTypeEdit.ShowDialog() == true)
            {
                if (formTeacherLoadOtherTypeEdit.TeacherLoadOtherTypesList != null)
                {
                    var list = formTeacherLoadOtherTypeEdit.TeacherLoadOtherTypesList;
                    foreach (var item in list)
                    {
                        _uow.TeacherLoadOtherType.InsertOrUpdate(item);
                        _uow.Save();
                    }
                }
            }
            else
            {
                formTeacherLoadOtherTypeEdit.Close();
            }

            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridTeacherLoadOtherType.ItemsSource as List<TeacherLoadOtherType>;
            if (ComboBoxTypeWork.SelectedItem == null || ComboBoxSubTypeWork.SelectedItem == null)
            {
                MessageBox.Show("Виберіть Вид роботи і під вид для редагування !");
                return;
            }

            var formTeacherLoadOtherTypeEdit = new FormTeacherLoadOtherTypeEdit(selected);
            if (formTeacherLoadOtherTypeEdit.ShowDialog() == true)
            {
                if (formTeacherLoadOtherTypeEdit.TeacherLoadOtherTypesList != null)
                {
                    var list = formTeacherLoadOtherTypeEdit.TeacherLoadOtherTypesList;
                    foreach (var item in list)
                    {
                        _uow.TeacherLoadOtherType.InsertOrUpdate(item);
                        _uow.Save();
                    }
                }
            }
            else
            {
                formTeacherLoadOtherTypeEdit.Close();
            }
            ComboBoxTypeWork.SelectedItem = null;
            ComboBoxSubTypeWork.SelectedItem = null;

            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridTeacherLoadOtherType.ItemsSource as List<TeacherLoadOtherType>;
            if (selected == null || ComboBoxTypeWork.SelectedItem == null || ComboBoxSubTypeWork.SelectedItem == null )
            {
                MessageBox.Show("Виберіть Вид роботи і під вид для видалення !");
                return;
            }

                foreach (var type in selected)
                {
                    _uow.TeacherLoadOtherType.Delete(type.Id);
                    _uow.Save();

                }

            ComboBoxTypeWork.SelectedItem = null;
            ComboBoxSubTypeWork.SelectedItem = null;

            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void ComboBoxSubTypeWork_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxTypeWork.SelectedItem is TypeWork ? (TypeWork)ComboBoxTypeWork.SelectedItem : (TypeWork)0;
            var selectedSub = ComboBoxSubTypeWork.SelectedItem is SubTypeWork ? (SubTypeWork)ComboBoxSubTypeWork.SelectedItem : (SubTypeWork)0;
            var selectedOtherType = _uow.OtherType.All.Where(p => p.TypeWork == selected && p.SubTypeWork == selectedSub).ToList();
            var list = selectedOtherType.SelectMany(otherType => otherType.TeacherLoadOtherType).ToList();
            DataGridTeacherLoadOtherType.ItemsSource = list;
        }
    }
}
