using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoadEdit.xaml
    /// </summary>
    public partial class FormTeacherLoadEdit : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public TeacherLoad TeacherLoad { get; set; }
        private List<TeacherLoad> _listTeacherLoads;

        public FormTeacherLoadEdit()
        {
            if (_app != null) _uow = _app.Uow;
            _listTeacherLoads = new List<TeacherLoad>();
            InitializeComponent();
        }

        public FormTeacherLoadEdit(TeacherLoad teacherLoad) : this()
        {
            TeacherLoad = teacherLoad;
        }

        private void FormTeacherLoadEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSubject.ItemsSource = _uow.Subject.All.ToList();
            ComboBoxSubject.DisplayMemberPath = "Name";
            DataGridTeacherLoad.ItemsSource = 
        }

        private void ComboBoxSubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
