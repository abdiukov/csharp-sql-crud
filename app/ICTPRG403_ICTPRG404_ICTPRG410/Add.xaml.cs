using ICTPRG403_ICTPRG404_ICTPRG410.Data;
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

namespace ICTPRG403_ICTPRG404_ICTPRG410
{
    /// <summary>
    /// The logic for the Add page
    /// The user can enter information inside the text boxes.
    /// If the user clicks the "Save" button, the information gets transferred into a Person object and then gets saved onto the database.
    /// </summary>
    public partial class Add : Window
    {
        /// <summary>
        /// Constructor for the Add page. It is completely empty besides the InitializeComponent() which is responsible for loading the page.
        /// </summary>
        public Add()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Btn_SaveInput_Click retrieves information from the text boxes
        /// Afterwards, a Person object is created whith the values retrieved from text boxes
        /// That person object gets passed onto repository class which uses it to create a new person.
        /// Afterwards, the NavigateToMainMenu() is executed.
        /// As per specifications, "try catch" was added to catch any potential errors.
        /// The Id is set to -1, because the Id is irrelevant. Id is not used when creating a person, as the SQL creates a unique ID for you.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SaveInput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person output = new Person()
                {
                    Id = -1,
                    FirstName = txtbox_FirstName.Text,
                    LastName = txtbox_LastName.Text,
                    Height = double.Parse(txtbox_Height.Text),
                    Weight = double.Parse(txtbox_Weight.Text)
                };
                Repository database = new Repository();

                database.InsertPerson(output);
                NavigateToMainMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This button calls the NavigateToMainMenu() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateToMainMenu();
        }

        /// <summary>
        /// NavigateToMainMenu closes the current page and opens the "Main Menu" page
        /// </summary>
        private void NavigateToMainMenu()
        {
            MainWindow pageobj = new MainWindow();
            pageobj.Show();
            this.Close();
        }
    }
}
