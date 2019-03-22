using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenoBookings
{
    public partial class Form1 : Form
    {
        private Bookings bookings;
        private Guests guests;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            if (bookings == null||bookings.IsDisposed)
            {
                bookings = new Bookings(this);
                tabControl1.TabPages.Add(bookings);
            }

        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            if (guests == null|| guests.IsDisposed)
            {
                guests = new Guests(this);
                tabControl1.TabPages.Add(guests);
            }

        }
    }
}
