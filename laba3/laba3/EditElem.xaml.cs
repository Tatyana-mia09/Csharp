using System;
using System.Windows;


namespace laba3
{
    using System.Collections.ObjectModel;


    /// <summary>
    /// Логика взаимодействия для EditElem.xaml
    /// </summary>
    public partial class EditElem : Window
    {
       
        public EditElem()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, EventArgs args)
        {
            if (departmentBox.Text == string.Empty
                && yearBox.Text == string.Empty
                && nameBox.Text == string.Empty
                && resultBox.Text == string.Empty
                && nameBox.Text == string.Empty
                && surnameBox.Text == string.Empty
                && patronymicBox.Text == string.Empty
                && mestoBox.Text == string.Empty)
            {
                notice.Visibility = Visibility.Visible;
            }
            else
            {
                notice.Visibility = Visibility.Hidden;
                DialogResult = true;
            }
        }


        public ObservableCollection<Protokol> toList(ObservableCollection<Protokol> protokol, int i)
        {
            ObservableCollection<Protokol> a = protokol;
            if (departmentBox.Text.Length != 0)
            {
                protokol[i].Organization = departmentBox.Text;
            }
            if (nameBox.Text.Length != 0)
            {
                //if (Regex.IsMatch(nameBox.Text, @"[а-яА-Я]"))
                    protokol[i].Name = nameBox.Text;
                
            }
            if (surnameBox.Text.Length != 0)
            {
                protokol[i].Surname = surnameBox.Text;
            }
            if (yearBox.Text.Length != 0)
            {
                protokol[i].Data = Convert.ToInt32(yearBox.Text);
            }
            if (patronymicBox.Text.Length != 0)
            {
                protokol[i].Patronymic = patronymicBox.Text;
            }
            if (mestoBox.Text.Length!=0)
            {
                protokol[i].Mesto = Convert.ToInt32(mestoBox.Text);
            }
            if (resultBox.Text.Length != 0)
            {
                protokol[i].Result = Convert.ToDouble(resultBox.Text);
            }

            return a;
        }
    }
}
