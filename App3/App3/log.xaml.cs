using System;
using System.Windows;
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
//using System.Windows

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   /* public class StudentTable
    {
        public string Id { get; set; }

        //// TODO: Add the following serialization attribute.
        [JsonProperty(PropertyName = "sname")]
        public string sname { get; set; }

        //// TODO: Add the following serialization attribute.
        [JsonProperty(PropertyName = "email")]
        public string email1 { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string password1 { get; set; }

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



    }*/
    public sealed partial class log : Page
    {
        private MobileServiceCollection<StudentTable, StudentTable> items;
        private IMobileServiceTable<StudentTable> todoTable = App.MobileService.GetTable<StudentTable>();
        public int flag = 0;
        public log()
        {
            this.InitializeComponent();
        }
         //TextB.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        public string s1, s2;
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
            foreach (var element in items)
            {
                if (element.email.ToString().Equals(s1) && element.password.ToString().Equals(s2))
                {
                    //element.sname = "yo";
                    this.Frame.Navigate(typeof(HubPage));
                    flag++;
                    break;
                    //await todoTable.UpdateAsync(element);
                }
                
            }
            if(flag==0)
                {
                    MessageDialog msgbox = new MessageDialog("Wrong username or password!");
                    await msgbox.ShowAsync();
                    flag = 0;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(reg));
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            s1 = email.Text;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            s2 = password.Password;
            //TextB.Text = s2;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }

         void showPassword_Checked(object sender, RoutedEventArgs e)
        {
            //password.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //TextB.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        /*private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
            //password.Password = TextB.Text;
            
        }*/
    }
}
