using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace laba3
{
    using System.Collections.ObjectModel;


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int sort= 1;
        List<Protokol> listProtokol = new List<Protokol>();
        private ObservableCollection<Protokol> observableCollection = new ObservableCollection<Protokol>();

        public MainWindow()
        {
            InitializeComponent();
            SaveReaderFile.ReadFileToList("Protokol.txt", listProtokol, observableCollection);
            DataGrid.ItemsSource = observableCollection;
            DataGrid.Visibility = Visibility.Visible;
        }

        public void Open_Click(object sender, RoutedEventArgs e)
        {
            listProtokol = new List<Protokol>();
            observableCollection = new ObservableCollection<Protokol>(listProtokol);
            SaveReaderFile.ReadFileToList("Protokol.txt", listProtokol, observableCollection);
            DataGrid.ItemsSource = observableCollection;
            DataGrid.Visibility = Visibility.Visible;
        }
        public void NewFile_Click(object sender, RoutedEventArgs e)
        {
                listProtokol = new List<Protokol>();
                observableCollection = new ObservableCollection<Protokol>(listProtokol);
                DataGrid.ItemsSource = observableCollection;
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        public void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Группа: ИП-22\n Cтудент: Бондаренко Татьяна Сергеевна");
        }
        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Del_Click(object sender, RoutedEventArgs e)
        {
            if (observableCollection.Count == 0)
            {
                InfoBlock.Text = "Откройте Файл для удаление элемента!";
            }
            else
            {
                try
                {
                    observableCollection.Remove(observableCollection[DataGrid.SelectedIndex]);

                }
                catch (ArgumentOutOfRangeException)
                {
                    InfoBlock.Text = "Выберете элемент для удаления!";

                }
            }
            
        }
        public void Search_Click(object sender, RoutedEventArgs e)
        {

            List<Protokol> list = listProtokol.Where(t => t.Organization.ToUpper().Contains(Search.Text.ToUpper())).ToList();
            observableCollection.Clear();
            list.ForEach(t => observableCollection.Add(t));
            // listProtokol.ForEach(t => observableCollection.Add(t));
            DataGrid.Items.Refresh();


        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (listProtokol.Count == 0)
            {
                InfoBlock.Text = "Откройте файл для сохранения!";
            }
            else
            {
           
                SaveReaderFile.SaveToFile("Protokol.txt",listProtokol);
            }

        }
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            if (observableCollection.Count!=0)
            {
                AddElem addElementWindow = new AddElem();
                if (addElementWindow.ShowDialog() == true)
                {
                    string[] addedEquipment = new string[]{addElementWindow.departmentBox.Text,
                        addElementWindow.nameBox.Text,
                        addElementWindow.surnameBox.Text,
                        addElementWindow.patronymicBox.Text,
                        addElementWindow.yearBox.Text,
                        addElementWindow.resultBox.Text,
                        addElementWindow.mestoBox.Text};
                    try
                    {
                        listProtokol.Add(new Protokol(addedEquipment));
                        observableCollection.Add(new Protokol(addedEquipment));
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Некорректно введены данные!");
                    }
                }
            }
            else
            {
                InfoBlock.Text="Откройте файл";
            }
        }
        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            int _indElem;
            if (observableCollection != null&& DataGrid.SelectedIndex!=-1)
            {
                EditElem editWindow = new EditElem();
                _indElem = DataGrid.SelectedIndex;
                editWindow.yearBox.Text = (listProtokol[_indElem].Data).ToString();
                editWindow.departmentBox.Text = (listProtokol[_indElem].Organization);
                editWindow.mestoBox.Text = (listProtokol[_indElem].Mesto).ToString();
                editWindow.nameBox.Text = (listProtokol[_indElem].Name);
                editWindow.surnameBox.Text = (listProtokol[_indElem].Surname);
                editWindow.patronymicBox.Text = (listProtokol[_indElem].Patronymic);
                editWindow.resultBox.Text = (listProtokol[_indElem].Result).ToString();
                editWindow.surnameBox.Text = (listProtokol[_indElem].Surname);
                if (editWindow.ShowDialog() == true)
                {
                    //string[] inf = new string[] { editWindow.TextBlock.Text };
                    try
                    {
                        listProtokol = editWindow.toList(observableCollection, _indElem).ToList();
                        observableCollection = editWindow.toList(observableCollection, _indElem);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Некорректно введены данные!");
                    }
                }

            }
            else
            {

                InfoBlock.Text = "Откройте файл или выберете элемент";
            }
            DataGrid.Items.Refresh();
        }
        public void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (observableCollection.Count == 0)
            {
                InfoBlock.Text = "Откройте файл!";

            }
            else
            {
                if (sort == 1)
                {
                    observableCollection = new ObservableCollection<Protokol>(from i in observableCollection orderby i.Mesto select i);
                    DataGrid.ItemsSource = observableCollection;
                }
                else
                {
                    observableCollection = new ObservableCollection<Protokol>(observableCollection.Reverse());
                    DataGrid.ItemsSource = observableCollection;

                }

                DataGrid.SelectedIndex = -1;
                sort = -sort;
            }


        }
    }
   
}
