using Newtonsoft.Json;
using RestSharp;
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

namespace Calling_A_Rest_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowTodo();
        }
        private void ShowTodo()
        {
            var Client = new RestClient("https://jsonplaceholder.typicode.com/todos/3");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);

            var content = response.Content;

            var data = JsonConvert.DeserializeObject<Todo>(content);

            lblUserId.Content = "UserId :" + data.UserId;
            lblId.Content = "Id :" + data.Id;
            lblTitle.Content = "Title :" + data.Title;
            lblCompleted.Content = "Completed :" + data.Completed;
        }
      

        private void btnTodo_Click(object sender, RoutedEventArgs e)
        {
            ShowTodo();
        }
    }
}
