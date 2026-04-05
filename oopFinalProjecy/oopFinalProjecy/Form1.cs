using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Object Orientated Programming - Final Project
/// </summary>
/// 
/// <author> Evan Wall, John Tran </author>
/// <date> March 26th, 2026 </date>
/// <class> Object Orientated Programming </class>

namespace oopFinalProjecy
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Books> availableBooks = new List<Books>();
            List<User> users = new List<User>();

            users.Add(new Student("Chad", "Student"));
            users.Add(new Teacher("Brad", "Teacher"));
            users.Add(new Librarian("Thad", "Librarian"));

            cmbUsers.DataSource = users;
            cmbUsers.DisplayMember = "Name";


            for (int i = 0; i <= 25; i++)
            {
                availableBooks.Add(new Books($"Title: {i}", $"Author: {i}"));
            }

            dgAvailable.DataSource = availableBooks;
        }
    }
}
