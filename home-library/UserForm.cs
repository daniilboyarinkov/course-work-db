﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home_library
{
    public partial class UserForm : Form
    {
        private readonly OleDbConnection _connection;
        public string name;
        public UserForm(string name, OleDbConnection connect)
        {
            InitializeComponent();

            this.name = name;
            _connection = connect;

            if (CheckGenre())
            {
                DataGridUser.Columns.Add("column4", "Жанр");
                label2.Visible = true;
                radioButton1.Visible = true;
                updateStudents("SELECT books.title, authors.fio, books.publication_year, books.genre " +
                                                "FROM books, authors, library " +
                                                "WHERE books.author = authors.author_id AND library.book = books.book_id " +
                                                "GROUP BY books.title, authors.fio, books.publication_year " +
                                                "HAVING SUM(library.taken = true) = 0");
            }
            else
            {
                label2.Visible = false;
                radioButton1.Visible = false;
                updateStudents();
            }            
        }

        private void updateStudents(string q = "SELECT books.title, authors.fio, books.publication_year " +
                                                "FROM books, authors, library " +
                                                "WHERE books.author = authors.author_id AND library.book = books.book_id " +
                                                "GROUP BY books.title, authors.fio, books.publication_year " +
                                                "HAVING SUM(library.taken = true) = 0")
        {
            string query = q;
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {
                string genre = "";
                if (reader.FieldCount == 4)
                {                    
                    genre = reader[3].ToString() ?? "";
                }
                var name = reader[0];
                var author = reader[1];
                var year = reader[2];
                if (CheckGenre()) DataGridUser.Rows.Add(name, author, year, genre);
                else DataGridUser.Rows.Add(name, author, year);
            }
            reader.Close();
        }

        private void UserBooks_Click(object sender, EventArgs e)
        {
            UserForm2 usform2 = new(name, _connection);
            usform2.ShowDialog();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CheckGenre()) DataGridUser.Columns.Remove("column4");
        }
        public bool CheckGenre()
        {
            try
            {
                string query = "SELECT * FROM genres";
                OleDbCommand command = new OleDbCommand(query, _connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ShowHistory_Click(object sender, EventArgs e)
        {
            UserForm3 usform3 = new(name, _connection);
            usform3.ShowDialog();
        }

        private void GetBook_Click(object sender, EventArgs e)
        {
            //возможное информировнаие через почту о бронировании книги
            if (DataGridUser.Rows.Count > 1) DataGridUser.Rows.RemoveAt(DataGridUser.SelectedRows[0].Index);
        }
    }
}
