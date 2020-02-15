

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfTaskSheet.Model;
using WpfTaskSheet.Servicies;

namespace WpfTaskSheet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH =$"{Environment.CurrentDirectory }\\ToDoData.json";
        /// <summary>
        /// Список данных
        /// </summary>
        private BindingList<TodoModel> _todoDataList;
        private FileIOService _fileIOService; 

        public MainWindow()
        {
            InitializeComponent();
        }
        
         /// <summary>
         /// Загрузка главного окна
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
            _todoDataList = _fileIOService.LoadData();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dgToDoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += TodoDataList_ListChanged;
        }

        /// <summary>
        /// Изменение листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try
                {
                    _fileIOService.SaveData((BindingList<TodoModel>)sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
                
            
        }

        private void DataGreedToDoList_Loaded(object sender, RoutedEventArgs e)
        {
                  
        }
    }
}
