using BooksModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question3
{
    public partial class MainForm : Form
    {
        private BooksEntities books = new BooksEntities();
        public MainForm()
        {
            InitializeComponent();
        }

        private void queryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryTextBox.Clear();

            switch (queryComboBox.SelectedIndex)
            {
                case 0:

                    queryTextBox.AppendText("\r\r\rAll Book Titles with Authors, Sorted Alphabetically by Title Name\n");

                    var titleAndAuthorQuery = from book in books.Titles
                                               from author in book.Authors
                                               orderby book.Title1
                                               select new { book.Title1, author.FirstName, author.LastName };

                    foreach (var element in titleAndAuthorQuery)
                    {
                        queryTextBox.AppendText(string.Format("\r\n\t{0,-20} by {1} {2}",
                            element.Title1,element.FirstName,element.LastName));
                    }

                    break;

                case 1:

                    queryTextBox.AppendText("\r\r\rAll Book Titles with Authors, Alphabetically Sorted by Title Name with Authors Sorted by Last Name then First Name\n");

                    var sortedTitleAndAuthorQuery = from book in books.Titles
                                                     from author in book.Authors
                                                     orderby book.Title1, author.LastName, author.FirstName
                                                     select new { book.Title1, author.FirstName, author.LastName };

                    foreach (var element in sortedTitleAndAuthorQuery)
                    {
                        queryTextBox.AppendText(string.Format("\r\n\t{0,-20} by {1} {2}",
                            element.Title1, element.FirstName, element.LastName));
                    }

                    break;
                case 2:

                    queryTextBox.AppendText("\r\r\rAll Authors, Grouped and Alphabetically Sorted by Book Title, with Authors Sorted by Last Name then First Name\n");

                    var groupedAuthorQuery = from book in books.Titles
                                                     orderby book.Title1
                                                     select new
                                                     {
                                                         book.Title1,
                                                         Authors = from author in book.Authors
                                                                   orderby author.LastName, author.FirstName
                                                                   select author.FirstName + " " + author.LastName
                                                     };

                    foreach (var element in groupedAuthorQuery)
                    {
                        queryTextBox.AppendText(string.Format("\r\n\t{0,-10}",
                            element.Title1));

                        foreach (var author in element.Authors)
                        {
                            queryTextBox.AppendText(string.Format("\r\n\t\t\t{0,-10}",
                            author));
                        }
                    }

                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            queryComboBox.SelectedIndex = 0;
     
        }
    }
}
