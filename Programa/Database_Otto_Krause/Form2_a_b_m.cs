using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Otto_Krause
{
    public partial class Form2_a_b_m : Form
    {
        MySqlConnection conexionBaseDatos = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=escuela_otto_krause;");
        public Form2_a_b_m()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("Select dni, nombre, apellido, codigo_materia, codigo_curso, primer_trimestre, segundo_trimestre, tercer_trimestre, promedio from alumnos INNER JOIN calificacion ON alumnos.dni = calificacion.dni_alumno", conexionBaseDatos);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAlumnos.DataSource = tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox_alumno_existente.Checked == false)
            {
                conexionBaseDatos.Open();
                string insert = "INSERT INTO alumnos (dni, nombre, apellido) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');";
                MySqlCommand comando = new MySqlCommand(insert, conexionBaseDatos);
                comando.ExecuteNonQuery();
                conexionBaseDatos.Close();
                MessageBox.Show("Se añadio al alumno " + textBox2.Text + " " + textBox3.Text);
            }
            else
            {
                conexionBaseDatos.Open();
                int trimestre_uno = Int32.Parse(textBox4.Text);
                int trimestre_dos = Int32.Parse(textBox5.Text);
                int trimestre_tres = Int32.Parse(textBox6.Text);

                int promedio_temp = (trimestre_uno+trimestre_dos+trimestre_tres) / 3;
                label16.Text = promedio_temp.ToString();
                string insert = "INSERT INTO calificacion (codigo_materia, dni_alumno, codigo_curso, primer_trimestre, segundo_trimestre, tercer_trimestre, promedio) values ('" + textBox8.Text + "','" + textBox1.Text + "','" + textBox9.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + promedio_temp +"');";
                MySqlCommand comando = new MySqlCommand(insert, conexionBaseDatos);
                comando.ExecuteNonQuery();
                conexionBaseDatos.Close();
                MessageBox.Show("Se añadio al alumno " + textBox2.Text + " " + textBox3.Text);
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            alumno_existente();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * from alumnos", conexionBaseDatos);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAlumnos.DataSource = tabla;
        }

        private void alumno_existente()
        {
            if (checkBox_alumno_existente.Checked == false)
            {
                label2.Location = new Point(161, 254);
                label3.Location = new Point(161, 354);
                label4.Location = new Point(161, 305);

                textBox1.Location = new Point(216, 251);
                textBox2.Location = new Point(216, 302);
                textBox3.Location = new Point(216, 351);

                button1.Location = new Point(160, 444);

                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label15.Visible = false;

                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
            }
            else
            {
                label2.Location = new Point(40, 254);
                label3.Location = new Point(40, 305);
                label4.Location = new Point(40, 354);

                textBox1.Location = new Point(85, 251);
                textBox2.Location = new Point(85, 302);
                textBox3.Location = new Point(85, 351);

                button1.Location = new Point(160, 444);

                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label14.Visible = true;
                label15.Visible = true;

                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
            }
        }
    }
}
