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
    /// The logic for the Delete page
    /// This page gets information regarding the person that is to be deleted from the ToBeDeleted person
    /// Afterwards the user is displayed with information regarding the person that they chose to delete
    /// If the user clicks the "Delete" button, the program deletes the person from the database and goes back to Main Menu.
    /// </summary>
    public partial class Delete : Window
    {
        /// <summary>
        /// Retrieves the ToBeDeleted person from the constructor, thus allowing it to be used by the Btn_Delete_Click
        /// </summary>
        private Person ToBeDeleted
        {
            get; set;
        }

        /// <summary>
        /// Constructor for the Delete page
        /// Constructor requires the Person object
        /// this.ToBeDeleted = ToBeDeleted is responsible for passing this person object to the entire program (so that it can be used by Btn_Delete_Click, otherwise it won't work)
        /// The constructor gets the information about the person and passes it onto text boxes.
        /// The textboxes are read-only and cannot be edited. The user is shown the information just to confirm that they want to delete this.
        /// Theoretically, even if these textboxes were edited, it wouldn't make a difference as they are just used to show information.
        /// </summary>
        /// <param name="ToBeDeleted">The person whose information is to be erased</param>
        public Delete(Person ToBeDeleted)
        {
            InitializeComponent();
            txtbox_Id_ReadOnly.Text = ToBeDeleted.Id.ToString();
            txtbox_FirstName_ReadOnly.Text = ToBeDeleted.FirstName;
            txtbox_LastName_ReadOnly.Text = ToBeDeleted.LastName;
            txtbox_Height_ReadOnly.Text = ToBeDeleted.Height.ToString();
            txtbox_Weight_ReadOnly.Text = ToBeDeleted.Weight.ToString();
            this.ToBeDeleted = ToBeDeleted;
        }

        /// <summary>
        /// Deletes the person(from the database) that was passed into the constructor when the page was loaded
        /// As per specifications, "try catch" was added to catch any potential errors.
        /// After the person has been successfully deleted, the NavigateToMainMenu() is executed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Repository database = new Repository();
                database.DeletePerson(ToBeDeleted);
                NavigateToMainMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This button calls the NavigateToMainMenu() method
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
