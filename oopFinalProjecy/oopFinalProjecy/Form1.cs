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

        List<Books> availableBooks = new List<Books>();
        List<User> users = new List<User>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            users.Add(new Student("Chad", "Student"));
            users.Add(new Teacher("Brad", "Teacher"));
            users.Add(new Librarian("Thad", "Librarian"));

            cmbUsers.DataSource = users;
            cmbUsers.DisplayMember = "Name";


            for (int i = 0; i <= 25; i++)
            {
                availableBooks.Add(new Books($"Title: {i}", $"Author: {i}"));
            }

            dgAvailable.DataSource = null;
            dgAvailable.DataSource = availableBooks;
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            try
            {
                Books selectedBook = dgAvailable.CurrentRow?.DataBoundItem as Books;
                User selectedUser = cmbUsers.SelectedItem as User;

                if (selectedUser is Student student && student.BooksBorrowed >= student.BorrowLimit)
                {
                    MessageBox.Show($"{selectedUser.Name} Has reached their borrow limit ({student.BorrowLimit})");
                    return;
                }
                else if (selectedUser is Teacher teacher && teacher.BooksBorrowed >= teacher.BorrowLimit)
                {
                    MessageBox.Show($"{selectedUser.Name} Has reached their borrow limit ({teacher.BorrowLimit})");
                    return ;
                }
                
                selectedBook.Borrow(selectedUser);

                dgAvailable.DataSource = null;
                dgAvailable.DataSource = availableBooks;

                dgBorrowed.DataSource = null;
                dgBorrowed.DataSource = selectedUser.MyBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region btnReturnBook_Click Method
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            Books selectedBook = dgBorrowed.CurrentRow?.DataBoundItem as Books;
            User selectedUser = cmbUsers.SelectedItem as User;

            if (selectedBook == null) 
            {
                MessageBox.Show("Plese selected a book to return");
                return;
            }
            selectedBook.Return(selectedUser);

            dgBorrowed.DataSource = null;
            dgBorrowed.DataSource = selectedUser.MyBooks;

        }
        #endregion
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddBook.Enabled = cmbUsers.SelectedItem is Librarian;
            txtBookTitle.Enabled = cmbUsers.SelectedItem is Librarian;
            txtBookAuthor.Enabled = cmbUsers.SelectedItem is Librarian;
        }


        #region btnAddBook_Click Method
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            User selectedUser = cmbUsers.SelectedItem as User;

            if (!(selectedUser is Librarian))
            {
                MessageBox.Show($"{selectedUser.Name} must be a Librarian to add a book");
                return;
            }

            string bookTitle = txtBookTitle.Text;
            string bookAuthor = txtBookAuthor.Text;

            if (string.IsNullOrEmpty(bookTitle) || string.IsNullOrEmpty(bookAuthor))
            {
                MessageBox.Show("Book title and Author Required");
                return;
            }

            Books newBook = new Books(bookTitle, bookAuthor);

            if (availableBooks.Any(b => b == newBook))
            {
                MessageBox.Show($"{newBook.Title} Already exists");
                return;
            }
            
            availableBooks.Add(newBook);

            dgAvailable.DataSource = null;
            dgAvailable.DataSource = availableBooks;

        }
        #endregion
    }
}
