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
    public partial class Form1 : Form
    {
        MySqlConnection conexionBaseDatos = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=escuela_otto_krause;");
 
        
public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("Select * from alumnos", conexionBaseDatos);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAlumnos.DataSource = tabla;
            
         }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("Select dni, nombre, apellido, codigo_materia, codigo_curso, primer_trimestre, segundo_trimestre, tercer_trimestre, promedio from alumnos INNER JOIN calificacion ON alumnos.dni = calificacion.dni_alumno WHERE dni =('" + textBox1.Text + "');", conexionBaseDatos);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAlumnos.DataSource = tabla;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2_a_b_m administrador = new Form2_a_b_m();
            administrador.ShowDialog();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("Select dni, nombre, apellido, codigo_materia, codigo_curso, primer_trimestre, segundo_trimestre, tercer_trimestre, promedio from alumnos INNER JOIN calificacion ON alumnos.dni = calificacion.dni_alumno WHERE codigo_curso =('" + textBox2.Text + "');", conexionBaseDatos);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAlumnos.DataSource = tabla;
        }
    }
}
