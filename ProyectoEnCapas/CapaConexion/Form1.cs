﻿using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaConexion
{
    public partial class Form1 : Form
    {
        CustomerRepository customerRepository = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {

            var cagarDatos = customerRepository.obtenerTodos();
            dataGrid.DataSource = cagarDatos;
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            //var filtro = customer.FindAll(x => x.CompanyName.StartsWith(Search.Text));
            //dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           /* DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnetionTimeout = 30;

            string cadenaConexion = DatosLayer.DataBase.ConecctionString;
            MessageBox.Show(cadenaConexion);

            var CadenaBD = DatosLayer.DataBase.GetSqlConnection();*/
        }
    }
}
