using Domain;
using NumbersContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SP_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string AllNumbers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GoButtonClick(object sender, RoutedEventArgs e)
        {
            progressbar.IsIndeterminate = true;
            string result = await Task<string>.Run(() => SaveAllNumbers());
            Task.WaitAll();
            Task.Run(() => WriteToDBandFileAsync());
            MessageBox.Show(result);
            progressbar.IsIndeterminate = false;
            
        }

        public string SaveAllNumbers()
        {
            string numbers = string.Empty;
            for (int i = 0; i < 1000; i++)
            {
                numbers += i.ToString() + " ";
            }
            Thread.Sleep(1000);
            return numbers;
        }
       
        public async Task WriteToDBandFileAsync()
        {
            using (var context = await Task.Run(() => new Context()))
            {
                await context.Reports.AddAsync(new Report {});
                await context.SaveChangesAsync();
            }
            string date = DateTime.Now.ToString();
            using (StreamWriter writer = new StreamWriter("report.txt", false))
            {
                await writer.WriteLineAsync(date);
            }
        }
        
        public void AddNumber(string row, int number)
        {
            row += number.ToString();
        }
    }
}
