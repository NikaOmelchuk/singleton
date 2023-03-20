using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SingleLib
{
    public class Singlet
    {
        private static Singlet inst;
        private string conStr;
        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();

        private Singlet()
        {
            conStr = @"Server = jwkrush.com.ua; Database = kkte_nau; Uid = kkte_nau; Pwd = KkTe#NaU";
            cmd.Connection = con;
            con.Close();
        }

        public static Singlet Instance()
        {
            if (inst == null)
            {
                inst = new Singlet();
                return inst;
            }
            else
                return inst;
        }

        public void Connect()
        {
            con.ConnectionString = conStr;
        }

        public void SelAll(String tn, DataGridView dg)
        {
            try
            {
                cmd.CommandText = "select * from " + tn;
                con.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                fillGr(dg, r);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        void fillGr(DataGridView dg, MySqlDataReader r)
        {
            dg.Columns.Clear();
            for (int i = 0; i < r.FieldCount; i++)
            {
                dg.Columns.Add("col" + i.ToString(), r.GetName(i));
            }
            while (r.Read())
            {
                String[] s = new string[r.FieldCount];
                for (int i = 0; i < r.FieldCount; i++)
                {
                    s[i] = r[i].ToString();
                }
                dg.Rows.Add(s);
            }
        }

        public bool execute(string command)
        {
            try
            {
                con.Open();
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                con.Close();
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
