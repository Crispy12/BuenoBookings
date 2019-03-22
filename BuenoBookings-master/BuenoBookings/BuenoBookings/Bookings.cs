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
    public partial class Bookings : Form
    {
        private Form1 myParent;
        int GuestCurrentRecord = 0;
        DataTable dtGuests;

        public Bookings(Form1 p)
        {
            myParent = p;
            InitializeComponent();
        }

        private void Bookings_Load(object sender, EventArgs e)
        {
            FillHotelDropdown();
            LoadGuests();
            PopulateGuests();
        }
        #region Startup
        private void FillHotelDropdown()
        {
            DataTable dtHotels = GetData("SELECT Name, HotelID FROM Hotel");
            DataRow row = dtHotels.NewRow();
            row["HotelID"] = DBNull.Value;
            row["Name"] = "-Select a Hotel-";
            dtHotels.Rows.InsertAt(row, 0);

            cboHotels.DisplayMember = "Name";
            cboHotels.ValueMember = "HotelID";
            cboHotels.DataSource = dtHotels;
        }

        private void LoadGuests()
        {
            dtGuests = GetData("SELECT FirstName, LastName FROM Guest");
        }
        private void PopulateGuests()
        {
            txtFirstName.Text = dtGuests.Rows[GuestCurrentRecord]["FirstName"].ToString();
            txtLastName.Text = dtGuests.Rows[GuestCurrentRecord]["LastName"].ToString();
        }
        //private void DisplayCurrentPosition()
        //{
        //    myParent.tssThree.Text = "Position: " + (GuestcurrentRecord + 1).ToString() + " of " + dtGuests.Rows.Count;
        //}

        //private void Join()
        //{
        //    string sql = GetData("SELECT GuestID");
        //}
        #endregion

        #region Navigation
        #region Guests
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (GuestCurrentRecord != dtGuests.Rows.Count - 1)
            {
                GuestCurrentRecord++;
            }
            PopulateGuests();
            //DisplayCurrentPosition();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (GuestCurrentRecord > 0)
            {
                GuestCurrentRecord--;
            }
            PopulateGuests();
            //DisplayCurrentPosition();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            GuestCurrentRecord = dtGuests.Rows.Count - 1;
            PopulateGuests();
            //DisplayCurrentPosition();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            GuestCurrentRecord = 0;
            PopulateGuests();
            //DisplayCurrentPosition();
        }
        #endregion
        #region Bookings
        private void btnPreviousBook_Click(object sender, EventArgs e)
        {

        }

        private void btnNextBook_Click(object sender, EventArgs e)
        {

        }

        private void btnFirstBook_Click(object sender, EventArgs e)
        {

        }

        private void btnLastBook_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region DataAccess
        private DataTable GetData(string sqlstmt)
        {
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

        #region Add/Edit/Delete

        #endregion

        #region Rooms
        private void SearchRooms()
        {
            string sql = string.Format("SELECT RoomType, Rate FROM Room WHERE RoomType = '{0}' AND Rate = {1}",
                txtRoomType.Text,
                Convert.ToInt32(txtRate.Text));
        }
        #endregion
    }
}
