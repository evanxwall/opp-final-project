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
/// <author> Evan Wall, John Tran         </author>
/// <date> March 26th, 2026               </date>
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


            for (int i = 1; i <= 25; i++)
            {
                availableBooks.Add(new Books($"Title: {i}", $"Author: {i}"));
            }

            dgAvailable.DataSource = null;
            dgAvailable.DataSource = availableBooks.Where(b => b.IsAvailable).ToList();
        }

        #region ComboBox SelectedIndexChanged() Method
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddBook.Enabled = cmbUsers.SelectedItem is Librarian;
            txtBookTitle.Enabled = cmbUsers.SelectedItem is Librarian;
            txtBookAuthor.Enabled = cmbUsers.SelectedItem is Librarian;

            User selectedUser = cmbUsers.SelectedItem as User;

            dgBorrowed.DataSource = null;
            dgBorrowed.DataSource = selectedUser.MyBooks.ToList();

        }
        #endregion

        #region btnBorrowBook_Click Method
        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            try
            {
                Books selectedBook = dgAvailable.CurrentRow?.DataBoundItem as Books;
                User selectedUser = cmbUsers.SelectedItem as User;

                if (selectedBook == null)
                {
                    MessageBox.Show(
                        "Plese select a book to borrow",
                        "Select a Book",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    return;
                }

                if (!selectedBook.IsAvailable)
                {
                    MessageBox.Show(
                        "This book is currently out, please select another book",
                        "Select a Book",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    return;
                }

                if (selectedUser is Student student && student.BooksBorrowed >= student.BorrowLimit)
                {
                    MessageBox.Show(
                        $"{selectedUser.Name} Has reached their borrow limit ({student.BorrowLimit})",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    return;
                }
                else if (selectedUser is Teacher teacher && teacher.BooksBorrowed >= teacher.BorrowLimit)
                {
                    MessageBox.Show(
                        $"{selectedUser.Name} Has reached their borrow limit ({teacher.BorrowLimit})",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    return ;
                }
                
                selectedBook.Borrow(selectedUser);

                dgAvailable.DataSource = null;
                dgAvailable.DataSource = availableBooks.Where(b => b.IsAvailable).ToList();

                dgBorrowed.DataSource = null;
                dgBorrowed.DataSource = selectedUser.MyBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region btnReturnBook_Click Method
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            Books selectedBook = dgBorrowed.CurrentRow?.DataBoundItem as Books;
            User selectedUser = cmbUsers.SelectedItem as User;

            if (selectedBook == null) 
            {
                MessageBox.Show(
                        "Plese select a book to return",
                        "Select a Book",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                return;
            }

            if (!selectedUser.MyBooks.Contains(selectedBook))
            {
                MessageBox.Show(
                    $"{selectedUser.Name} Did not borrow this book",
                    "Can't Return Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedBook.Return(selectedUser);

                dgAvailable.DataSource = null;
                dgAvailable.DataSource = availableBooks.Where(b => b.IsAvailable).ToList();

                dgBorrowed.DataSource = null;
                dgBorrowed.DataSource = selectedUser.MyBooks;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        #endregion
        
        #region btnAddBook_Click Method
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            User selectedUser = cmbUsers.SelectedItem as User;

            if (!(selectedUser is Librarian))
            {
                MessageBox.Show(
                    $"{selectedUser.Name} must be a Librarian to add a book",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            string bookTitle = txtBookTitle.Text;
            string bookAuthor = txtBookAuthor.Text;

            if (string.IsNullOrEmpty(bookTitle) || string.IsNullOrEmpty(bookAuthor))
            {
                MessageBox.Show(
                        "Book title and author needed",
                        "Book Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                return;
            }

            Books newBook = new Books(bookTitle, bookAuthor);

            if (availableBooks.Any(b => b == newBook))
            { 
                MessageBox.Show(
                    $"Book \"{newBook.Title}\" already exists",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            try
            {
                availableBooks.Add(newBook);

                dgAvailable.DataSource = null;
                dgAvailable.DataSource = availableBooks.Where(b => b.IsAvailable).ToList();

                dgBorrowed.DataSource = null;
                dgBorrowed.DataSource = selectedUser.MyBooks;

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        #endregion
    }
}
