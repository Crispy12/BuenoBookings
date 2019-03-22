using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BuenoBookings
{
    public partial class Guests : Form
    {
        private Form1 myParent;
        private DataTable dtGuests;
        int currentRecord = 0;
        bool action = false;
        public bool Update = false;
        public string GuestID = string.Empty;
        bool addInProgress = false;
        bool deleteInProgress = false;
        bool editInProgress = false;
        public Guests(Form1 p)
        {
            myParent = p;
            InitializeComponent();
        }
        #region Misc
        private void ResetForm()
        {
            //Resets the form and removes texts from textboxes
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtPhone.Text = string.Empty;
            chkPreferred.Checked = false;
        }

        //private bool GetPreferred()
        //{
        //    if (chkPreferred.Checked == true)
        //    {
        //        return chkPreferred.Checked = true;
        //    }
        //    return chkPreferred.Checked = false;
        //}

        private string SqlFix(string str)
        {
            return str.Replace("'", "''");
        }

        private void DisplayCurrentPosition()
        {
            myParent.tssThree.Text = "Position: " + (currentRecord + 1).ToString() + " of " + dtGuests.Rows.Count;
        }

        private string GetCurrentGuestId()
        {
            return dtGuests.Rows[currentRecord]["GuestID"].ToString();
        }

        private void SetButtons(bool state)
        {
            btnAddGuest.Enabled = state;
            btnDeleteGuest.Enabled = state;
            btnEditGuest.Enabled = state;
            btnUpdate.Enabled = !state;
            btnCancelGuest.Enabled = !state;

            btnNext.Enabled = state;
            btnPrevious.Enabled = state;
            btnLast.Enabled = state;
            btnFirst.Enabled = state;

            btnShowGuests.Enabled = state;
        }
        #endregion
        #region GenerateGuestId
        public string GenerateGuestID()
        {
            //generate random 4 numbers then make it a string
            Random randomNum = new Random();
            int num = randomNum.Next(1000, 9999);
            string number = num.ToString();

            //generate a random 3 letter string
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[3];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string stringId = new String(stringChars);
            //combines the string and number to create random ID
            GuestID = stringId + number;
            return GuestID;
        }
        #endregion
        #region Startup
        private void loadGuests()
        {
            dtGuests = GetData("SELECT * FROM Guest ORDER BY FirstName");
        }

        private void FillHotelDropdown()
        {

        }

        private void PopulateFormFields()
        {
            //populates the textboxes with data from database
            txtFirstName.Text = dtGuests.Rows[currentRecord]["FirstName"].ToString();
            txtLastName.Text = dtGuests.Rows[currentRecord]["LastName"].ToString();
            txtAddress.Text = dtGuests.Rows[currentRecord]["StreetAddress"].ToString();
            txtPostalCode.Text = dtGuests.Rows[currentRecord]["PostalCode"].ToString();
            txtProvince.Text = dtGuests.Rows[currentRecord]["Province"].ToString();
            txtCity.Text = dtGuests.Rows[currentRecord]["City"].ToString();
            txtPhone.Text = dtGuests.Rows[currentRecord]["Phone"].ToString();
            txtEmail.Text = dtGuests.Rows[currentRecord]["Email"].ToString();
            chkPreferred.Checked = (bool)dtGuests.Rows[currentRecord]["Preferred"];
            DisplayCurrentPosition();
        }

        private void Guests_Load(object sender, EventArgs e)
        {
            //when form loads run these methods
            loadGuests();
            PopulateFormFields();
            FillRoomType();
            SetButtons(true);
            GenerateGuestID();
        }

        private void FillRoomType()
        {
            //fills the room dropdown box
            cboRoomType.Items.Add("Penthouse Suite");
            cboRoomType.Items.Add("King");
            cboRoomType.Items.Add("2 Queen");
            cboRoomType.Items.Add("2 Double");
            cboRoomType.Items.Add("Queen");
            cboRoomType.Items.Add("Double");
        }
        #endregion
        #region DataAccess
        private DataTable GetData(string sqlstmt)
        {
            //gets the data from the database
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            DataTable dtFull = new DataTable();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sqlstmt, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dtFull);
            }
            return dtFull;
        }
        private int SendData(string sqlstmt)
        {
            //sends data to database
            int numRecordsAffected = 0;
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sqlstmt, conn);
                conn.Open();
                numRecordsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return numRecordsAffected;
        }
        #endregion
        #region Navigation
        private void btnNext_Click(object sender, EventArgs e)
        {
            //when next button is clicked, move to next guest in database
            if (currentRecord != dtGuests.Rows.Count - 1)
            {
                currentRecord++;
            }
            PopulateFormFields();
            DisplayCurrentPosition();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            //when next button is clicked, move to last guest in database
            currentRecord = dtGuests.Rows.Count - 1;
            PopulateFormFields();
            DisplayCurrentPosition();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //when next button is clicked, move to previous guest in database
            if (currentRecord > 0)
            {
                currentRecord--;
            }
            PopulateFormFields();
            DisplayCurrentPosition();
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            //when next button is clicked, move to first guest in database
            currentRecord = 0;
            PopulateFormFields();
            DisplayCurrentPosition();
        }
        #endregion
        #region Add/Edit/Delete
        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            //when add button is clicked, sets up the add guest function
            SetButtons(false);
            ResetForm();
            myParent.tssFour.Text = "Add Record in Progress...";
            //myParent.tssThree.Text = "Position: " + (dtGuests.Rows.Count + 1).ToString() + " of " + (dtGuests.Rows.Count + 1).ToString();
            addInProgress = true;
            //action = true;
        }

        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            //when edit button is clicked, sets up the edit guest function
            SetButtons(false);
            myParent.tssFour.Text = "Edit Record in Progress...";
            //myParent.tssThree.Text = "Position: " + (dtGuests.Rows.Count + 1).ToString() + " of " + (dtGuests.Rows.Count + 1).ToString();
            editInProgress = true;
            //action = true;
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            //when delete button is clicked, sets up the delete guest function
            SetButtons(false);
            ResetForm();
            myParent.tssFour.Text = "Delete Record in Progress...";
            //myParent.tssThree.Text = "Position: " + (dtGuests.Rows.Count + 1).ToString() + " of " + (dtGuests.Rows.Count + 1).ToString();
            deleteInProgress = true;
            //action = true;
        }

        private void btnCancelGuest_Click(object sender, EventArgs e)
        {
            //when cancel button is clicked, resets the form and cancels add/delete/edit function
            SetButtons(true);
            PopulateFormFields();
            myParent.tssFour.Text = "OK";
            addInProgress = false;
            editInProgress = false;
            deleteInProgress = false;
            action = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //when the save button is clicked, either add/edit/delete guest
            if (SendData(BuildSqlStatement()) == 0)
            {
                myParent.tssFour.Text = "Record not found - has been deleted";
            }

            if (action)
            {
                currentRecord = 0;
            }
            loadGuests();
            PopulateFormFields();

            SetButtons(true);
            PopulateFormFields();
            myParent.tssFour.Text = "OK";

            //addInProgress = false;
            //editInProgress = false;
            //deleteInProgress = false;
            //action = false;
        }

        private string BuildSqlStatement()
        {
            if (addInProgress == true)
            {
                //add guest
                return string.Format("INSERT INTO Guest (GuestID, FirstName, LastName," +
                    "StreetAddress, City, Province, PostalCode, Phone, Email, Preferred) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9})",
                    GuestID,
                    txtLastName.Text,
                    txtFirstName.Text,
                    txtAddress.Text,
                    txtCity.Text,
                    txtProvince.Text,
                    txtPostalCode.Text,
                    txtPhone.Text,
                    txtEmail.Text,
                    chkPreferred.Checked ? "1" : "0"
                    );
            }
            else if(editInProgress == true)
            {
                //edit guest info
                return string.Format("UPDATE Guest SET FirstName  = '{0}'," +
                    "LastName = '{1}', StreetAddress = '{2}', City = '{3}', " +
                    "Province = '{4}', PostalCode = '{5}', Phone = '{6}', " +
                    "Email = '{7}', Preferred = {8} WHERE GuestID = '{9}'",
                    SqlFix(txtFirstName.Text),
                    SqlFix(txtLastName.Text),
                    SqlFix(txtAddress.Text),
                    SqlFix(txtCity.Text),
                    SqlFix(txtProvince.Text),
                    SqlFix(txtPostalCode.Text),
                    SqlFix(txtPhone.Text),
                    SqlFix(txtEmail.Text),
                    chkPreferred.Checked ? "1" : "0",
                    GetCurrentGuestId()
                    );
            }
            else if (deleteInProgress == true)
            {
                //delete guest
                return string.Format("DELETE * FROM Guest WHERE GuestID = '{0}'",
                    GetCurrentGuestId());
            }
            else
            {
                //temporary. It had to return something
                string ah = "ahhhh";
                return ah;
            }
        }

        #endregion

        #region Editing
        private void SetUpEdit()
        {
            if (!action)
            {
                SetButtons(false);
                myParent.tssFour.Text = "Edit in Progress...";
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtProvince_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }

        private void chkPreferred_CheckedChanged(object sender, EventArgs e)
        {
            SetUpEdit();
        }
        #endregion


    }
}
