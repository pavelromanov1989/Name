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
using Name.Models;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;



namespace Name
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Person>_names;
        string path="simple.json";
        public void SaveData(object todo)//Метод для сохранения данных в json
        {
                    
            using (StreamWriter writer = File.CreateText(path))
            {
                
                string output = JsonConvert.SerializeObject(todo);//Конвертация данных в JSON
                writer.Write(output);
            }

        }



        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _names = new BindingList<Person>();//Создание списка при загрузке формы
            MetaData.ItemsSource = _names;//Привязка данных к DataGrid в XAML
            _names.AddNew();//Добавление нового элемента в списке
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((_names[0].lastname != null) & (_names[0].firstname != null) & _names[0].otchestvo != null)// проверка на null при попытке сохранить данные
                
            {
                if (Verification(_names[0].lastname) & Verification(_names[0].firstname) & Verification(_names[0].otchestvo))//проверка того что пользователь вводит текст
                {
                    path = _names[0].lastname + " " + _names[0].firstname + ".json";
                    if (_names[0].age == 0)//проверка того что пользователь ввел возраст
                    {
                        MessageBox.Show("Введите возраст");
                    }
                    else
                    {
                        SaveData(_names);//сохраненние данных
                        MessageBox.Show("Данные успешно сохранены");
                    }
                }
                else
                {
                    MessageBox.Show("Введены неправильные данные");
                }
                    
            }
            else
            {
                MessageBox.Show("Сначала заполните данные");
            }
        }
       
        private bool Verification(string forcheck)//Метод для проверки данных пользователя
        {
            
                foreach (char c in forcheck)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;


        }


    }
}
