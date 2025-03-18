using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace lab8q
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void connect()
        {
            string constring = "DATA SOURCE=172.16.54.24:1521/ictorcl;USER ID=CCE230953374;Password=student";
            conn = new OracleConnection(constring);
            conn.Open();
            MessageBox.Show("connected");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            comm = new OracleCommand();
            comm.CommandText = "select name from PERSON";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "PERSON");
            dt = ds.Tables["PERSON"];
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString());
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "name";
            conn.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from PERSON";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText,conn);
            da.Fill(ds, "PERSON");
            dt = ds.Tables["PERSON"];
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString());
            dr = dt.Rows[i];
            textBox1.Text = dr["driverid"].ToString();
            textBox2.Text = dr["name"].ToString();
            textBox3.Text = dr["address"].ToString();
            textBox4.Text = dr["gender"].ToString();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            if (i >= dt.Rows.Count)
                i = 0;
            dr = dt.Rows[i];
            textBox1.Text = dr["driverid"].ToString();
            textBox2.Text = dr["name"].ToString();
            textBox3.Text = dr["address"].ToString();
            textBox4.Text = dr["gender"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
                i = dt.Rows.Count-1;
            dr = dt.Rows[i];
            textBox1.Text = dr["driverid"].ToString();
            textBox2.Text = dr["name"].ToString();
            textBox3.Text = dr["address"].ToString();
            textBox4.Text = dr["gender"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect();
            OracleCommand cm = new OracleCommand(); 
            cm.Connection = conn;
            cm.CommandText = "insert into instructor values(’" + textBox1.Text + "’, ’" + textBox2.Text + "’,’" + textBox3.Text + "’,’" + textBox4.Text + "’)";
            cm.CommandType = CommandType.Text; 
            cm.ExecuteNonQuery(); 
            MessageBox.Show("Inserted!"); 
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from PERSON";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "PERSON");
            dt = ds.Tables["PERSON"];
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString());
            dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "PERSON";
            conn.Close(); 
        }

        

      /*  private void button5_Click(object sender, EventArgs e)
        {
            connect();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "update PERSON set gender=:pb where name =:pdn";
            cm.CommandType = CommandType.Text;
            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "pb";
            pa1.DbType = DbType.Int32;
            pa1.Value = v;
            OracleParameter pa2 = new OracleParameter();
            pa2.ParameterName = "pdn";
            pa2.DbType = DbType.String;
            pa2.Value = textBox1.Text;
            cm.Parameters.Add(pa1);
            cm.Parameters.Add(pa2);
            cm.ExecuteNonQuery();
            MessageBox.Show("updated");
            conn.Close();
        }*/

    }

}
