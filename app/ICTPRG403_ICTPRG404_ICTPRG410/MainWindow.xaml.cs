using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using ICTPRG403_ICTPRG404_ICTPRG410.Data;

namespace ICTPRG403_ICTPRG404_ICTPRG410
{
    /// <summary>
    /// Logic for the MainWindow page
    /// MainWindow retrieves information on all persons from the database and displays it onto the DataGrid.
    /// Also MainWindow contains buttons that redirect to other pages.
    /// Lastly, MainWindow retrieves the specific person chosen in the DataGrid and passes this information onto other classes.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// This variable is getting used by multiple functions within the MainWindow class.
        /// Contains information regarding all the persons in the database
        /// </summary>
        readonly private IEnumerable<Person> ListOfAllPersons;


        /// <summary>
        /// Constructor for the MainWindow page.
        /// This constructor retrieves the list of all people (ListOfAllPersons) from the database from the Repository class.
        /// Additionally, it updates the DataGrid with information from the database by using ListOfAllPersons.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Repository _repo = new Repository();
            ListOfAllPersons = _repo.GetPeople();
            dgPeople.ItemsSource = ListOfAllPersons;
        }


        /// <summary>
        /// Gets the index (which row did the user click the "Edit" button at)
        /// After getting the index, it selects the person inside ListOfAllPersons that corresponds to that index.
        /// So for instance, if the button was clicked in the second row, the second person inside ListOfAllPersons is selected.
        /// Afterwards, it redirects to the Edit page and passes the value of the Person who needs to be edited there.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            int selected_index = dgPeople.SelectedIndex;
            Person ToBeEdited = ListOfAllPersons.ElementAt(selected_index);

            Edit pageobj = new Edit(ToBeEdited);
            pageobj.Show();
            this.Close();
        }


        /// <summary>
        /// Gets the index (which row did the user click the "Delete" button at)
        /// After getting the index, it selects the person inside ListOfAllPersons that corresponds to that index.
        /// So for instance, if the button was clicked in the third row, the third person inside ListOfAllPersons is selected.
        /// Afterwards, it redirects to the Delete page and passes the value of the Person who needs to be deleted there.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selected_index = dgPeople.SelectedIndex;
            Person ToBeDeleted = ListOfAllPersons.ElementAt(selected_index);

            Delete pageobj = new Delete(ToBeDeleted);
            pageobj.Show();
            this.Close();
        }

        /// <summary>
        /// Navigates to the Add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add pageobj = new Add();
            pageobj.Show();
            this.Close();
        }
    }
}
