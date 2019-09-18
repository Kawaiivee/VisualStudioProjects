using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookLister
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public NewBookPage()
        {
            InitializeComponent();
        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {
            //Check if there is a non-empty stringg for title and author
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(authorEntry.Text)) {
                DisplayAlert("Error", "Must have A Non-Null TITLE and AUTHOR", "Oh, Okay...");
                return;
            }

            DateTime today = new DateTime();

            //Create book if there is valid values
            Book book = new Book() {
                Name = nameEntry.Text,
                Author = authorEntry.Text,
                //TimeStamp = today.ToString()
            };

            //Add it to local database with the "amazing" implementation of SQLITE :3
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();               //Thaank god that the CreateTable method for the SQLITE connection checks if the table exists already; i don't haave to write that query
                conn.Insert(book);   //Insert returns the primary key -- int ID -- of the inserted item
                int currNumBooks = conn.Table<Book>().Count();
                if (currNumBooks > 0) {
                    DisplayAlert("Success!", book.Name + " by " + book.Author + " Added to List\nCurrently there are " + currNumBooks.ToString() + " books in the list.", "Hooray! >w<");
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Failure...", book.Name + " by " + book.Author + " NOT Added to List", "Nuuuuu! >n<");
                }
            }
            //we don't havve to use conn.Dispose() or conn.Close() if we put the SQLite hazardous code into the 'using statement' (not to be confused with using as import) but using here is for disposablee variables that get garbage collected
        }
    }
}