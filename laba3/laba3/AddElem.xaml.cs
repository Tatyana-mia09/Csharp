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
using System.Windows.Shapes;

namespace laba3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddElem : Window
    {
        public AddElem()
        {
            InitializeComponent();
        }
        private void BtnAccept_Click(object sender, EventArgs args)
        {
            if (departmentBox.Text == string.Empty
                || yearBox.Text == string.Empty
                || nameBox.Text == string.Empty
                || resultBox.Text == string.Empty
                || nameBox.Text == string.Empty
                || surnameBox.Text == string.Empty
                || patronymicBox.Text == string.Empty
                || mestoBox.Text == string.Empty)
            {
                notice.Visibility = Visibility.Visible;
            }
            else
            {
                notice.Visibility = Visibility.Hidden;
                DialogResult = true;
            }
        }
    }
}
