using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookLister
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            ToolbarItem tbi = sender as ToolbarItem;
            switch (tbi.Text)
            {
                case "+":
                    Navigation.PushAsync(new NewBookPage());
                    break;
                case "CLEAR":
                    using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                    {
                        conn.DropTable<Book>();
                        conn.CreateTable<Book>();

                        var books = conn.Table<Book>().ToList();
                        bookListView.ItemsSource = books;
                    }
                    break;
            }
        }

        //This is like going between activities in anddroid
        //On start-resume-sleep
        //paageappearing and disappearing
        //modalpopping-popped-pushing-pushed
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();

                var books = conn.Table<Book>().ToList();    //books is a list type. HOLY F*** SH*T this is the most convenient SQLITE database Implementation I have used. i don't have to go through and configure every entry to add the data to a list
                bookListView.ItemsSource = books;
            }
        }
    }
}
