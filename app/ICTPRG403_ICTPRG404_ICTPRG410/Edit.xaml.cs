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
    /// The logic for the Edit page
    /// This page gets information regarding the person that is to be edited from the ToBeEdited person
    /// Afterwards a user can edit the person's information (everything except ID).
    /// The user clicks the "Save" button . Afterwards the program saves the edited person into the database and goes back to the main menu.
    /// </summary>
    public partial class Edit : Window
    {
        /// <summary>
        /// Constructor for the Edit page
        /// Constructor requires the Person object
        /// The constructor gets the information about the person and passes it onto text boxes.
        /// </summary>
        /// <param name="ToBeEdited">The person whose information is to be edited</param>
        public Edit(Person ToBeEdited)
        {
            InitializeComponent();
            txtbox_Id.Text = ToBeEdited.Id.ToString();
            txtbox_FirstName.Text = ToBeEdited.FirstName;
            txtbox_LastName.Text = ToBeEdited.LastName;
            txtbox_Height.Text = ToBeEdited.Height.ToString();
            txtbox_Weight.Text = ToBeEdited.Weight.ToString();
        }

        /// <summary>
        /// Btn_SaveInput_Click retrieves information from the text boxes
        /// Afterwards, a Person object is created whith the values retrieved from text boxes
        /// The program then attempts to update the information inside the database (with the Person object created)
        /// As per specifications, "try catch" was added to catch any potential errors.
        /// After the person has been successfully updated/edited, the NavigateToMainMenu() is executed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SaveInput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person output = new Person()
                {
                    Id = int.Parse(txtbox_Id.Text),
                    FirstName = txtbox_FirstName.Text,
                    LastName = txtbox_LastName.Text,
                    Weight = double.Parse(txtbox_Weight.Text),
                    Height = double.Parse(txtbox_Height.Text)
                };
                Repository database = new Repository();
                database.UpdatePerson(output);
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
