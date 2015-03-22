using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public class StudentTable
    {
        public string Id { get; set; }

        //// TODO: Add the following serialization attribute.
        [JsonProperty(PropertyName = "sname")]
        public string sname { get; set; }

        //// TODO: Add the following serialization attribute.
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

        [JsonProperty(PropertyName = "dob")]
        public string dob { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string gender { get; set; }

        [JsonProperty(PropertyName = "mobile")]
        public string mobile { get; set; }

        [JsonProperty(PropertyName = "dept")]
        public string dept { get; set; }

        [JsonProperty(PropertyName = "about")]
        public string about { get; set; }

        [JsonProperty(PropertyName = "batch")]
        public int batch { get; set; }

        [JsonProperty(PropertyName = "tag")]
        public string tag { get; set; }
        [JsonProperty(PropertyName = "Roll")]
        public string Roll { get; set; }

    }
    public sealed partial class reg : Page
    {
        private MobileServiceCollection<StudentTable, StudentTable> items;
        private IMobileServiceTable<StudentTable> todoTable = App.MobileService.GetTable<StudentTable>();
        public reg()
        {
            this.InitializeComponent();
        }

        public string s1, s2, s3, s4, s5;
        private async void InsertTodoItem(StudentTable todoItem)
        {
            await todoTable.InsertAsync(todoItem);

            items.Add(todoItem);
        
            // TODO: Delete or comment the following statement; Mobile Services auto-generates the ID.
            // todoItem.Id = Guid.NewGuid().ToString();

            //// This code inserts a new TodoItem into the database. When the operation completes
            //// and Mobile Services has assigned an Id, the item is added to the CollectionView
            //// TODO: Mark this method as "async" and uncomment the following statement.
         

        }

        private async void RefreshTodoItems()
        {
            //// TODO #1: Mark this method as "async" and uncomment the following statment
            //// that defines a simple query for all items. 
            items = await todoTable.ToCollectionAsync();

            //// TODO #2: More advanced query that filters out completed items. 
            //items = await todoTable
            //   .Where(todoItem => todoItem.Complete == false)
            //   .ToCollectionAsync();
            string temp = "";
            foreach (var element1 in items)
            {
                if (element1.email.ToString().Equals("bbaarrnnoo"))
                {
                    element1.sname = "yo";
                    await todoTable.UpdateAsync(element1);
                }
            }

            //MessageBox.Show("yo");
            //ListItems.ItemsSource = items;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            s1 = email.Text;
        }

        private void email_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            s2 = email_Copy.Text;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            s3 = password.Password;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                s4 = combobox1.SelectedItem.ToString();
                s5 = combobox2.SelectedItem.ToString();
                StudentTable StudentTable1 = new StudentTable { sname = s1, email = s2, password = s3, tag = s4, gender = s5 };
                //InsertTodoItem(StudentTable);
                await App.MobileService.GetTable<StudentTable>().InsertAsync(StudentTable1);
                this.Frame.Navigate(typeof(HubPage));
            }
            catch(Exception ex)
            {
                var m1 = new MessageDialog("exce" + ex).ShowAsync();
            }
            this.Frame.Navigate(typeof(HubPage));
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(log));
        }
    }
}
