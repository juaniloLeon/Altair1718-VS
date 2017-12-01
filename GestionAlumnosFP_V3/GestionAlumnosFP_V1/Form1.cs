﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionAlumnosFP_V1.DataSet1TableAdapters;

namespace GestionAlumnosFP_V1
{
    public partial class Form1 : Form
    {
        // Construimos los adaptadores y tablas que necesitamos
        GruposTableAdapter gruposAdapter = new GruposTableAdapter();
        DataSet1.GruposDataTable gruposTabla = new DataSet1.GruposDataTable();

        AlumnosTableAdapter alumnosAdapter = new AlumnosTableAdapter();
        DataSet1.AlumnosDataTable alumnosTabla = new DataSet1.AlumnosDataTable();

        // Construyo el formulario detalle que voy a usar en toda la aplicación
        FormDetalleAlumno fDetalle = new FormDetalleAlumno();

        bool comboCargado = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter.Fill(this.dataSet1.Alumnos);
            // Cargamos los combos
            CargaCombos();

            // Cargamos la tabla de alumnos
            CargaAlumnosGrupo();

            //Vamos a añadir el botón de borrar

            DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();

            btnBorrar.Width = 40;
            btnBorrar.Text = "X";
            btnBorrar.HeaderText = "Del";
            btnBorrar.ToolTipText = "Eliminar Registro";
            btnBorrar.UseColumnTextForButtonValue = true;
            //La coloco detrás del botón edit...//
            dgv.Columns.Insert(1, btnBorrar);
            //...pero la muestro al final de dgv
            dgv.Columns[1].DisplayIndex = dgv.Columns.Count - 1;
        }

        private void CargaCombos()
        {
            List<Grupo> listaTodosMasGrupos, listaGrupos = new List<Grupo>();
            // cargamos la tabla de Grupos
            // gruposAdapt.Fill(gruposTabla);
            gruposTabla = gruposAdapter.GetData();

            foreach (DataSet1.GruposRow regGrupo in gruposTabla)
                listaGrupos.Add(new Grupo(regGrupo));

            // construyo la segunda lista con los grupos de la primera
            listaTodosMasGrupos = new List<Grupo>(listaGrupos);
            // Inserto en primer lugar el "grupo Todos"
            listaTodosMasGrupos.Insert(0, new Grupo(0, "Todos", "Todos los grupos")); // <-- Cargo este grupo ficticio para que salga en primer lugar


            // Pongo la lista "listaTodosMasGrupos" como origen de datos del combo del principal
            cbGrupos.DataSource = listaTodosMasGrupos;
            cbGrupos.DisplayMember = "Nombre"; // <-- Indicamos qué propiedad se va a mostrar
            cbGrupos.ValueMember = "IdGrupo";// <-- Indicamos qué propiedad se va a guardar en Value
            comboCargado = true;
            // Y la lista básica del combo del formDetalle
            fDetalle.cbGruposDetalle.DataSource = listaGrupos;
            fDetalle.cbGruposDetalle.DisplayMember = "Nombre"; // <-- Indicamos qué propiedad se va a mostrar
            fDetalle.cbGruposDetalle.ValueMember = "IdGrupo";// <-- Indicamos qué propiedad se va a guardar en Value

        }

        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCargado)
                CargaAlumnosGrupo();
        }

        void CargaAlumnosGrupo()
        {
            int idGrupo = Convert.ToInt32(cbGrupos.SelectedValue);
            if (idGrupo == 0) //<-- Significa que hemos elegido "Todos los Grupos"
                alumnosTabla = alumnosAdapter.GetDataAlumnosConAliasGrupo();
            else
           
                // Hemos elegido un grupo de los existentes
                // Previamente añado al adaptador de alumnos el Select según grupo
                // ahora la uso
                alumnosTabla = alumnosAdapter.GetDataByIdGrupo(idGrupo);
            
            // Asociamos esa tabla al DataGridView
            dgv.DataSource = alumnosTabla;

            // ocultábamos las columnas de id's
            dgv.Columns["idAlumno"].Visible = false;
            dgv.Columns["idGrupo"].Visible = false;
            // si es un grupo concreto oculto la columna grupo porque ya no me sirve

            dgv.Columns["Grupo"].Visible = (idGrupo == 0);

            lbCabecera.Text = String.Format("Alumnos de {0} ({1} alumnos)", cbGrupos.Text, dgv.RowCount);
        }
        

        //private void btnBorrar_Click(object sender, EventArgs e)
        //{
        //    if (dgv.SelectedRows.Count < 1)
        //    {
        //        MessageBox.Show("Debe seleccionar el registro a eliminar", "Seleccione un registro", MessageBoxButtons.OK,MessageBoxIcon.Information);
        //        return;
        //    }
        //    // obtengo el id del alumno que quiero eliminar
        //    int idAlumno = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

        //    // Obtengo el registro correspondiente a dicho alumno
        //    DataSet1.AlumnosRow regAlumno = alumnosTabla.FindByidAlumno(idAlumno);

        //    // elimino el registro
        //    regAlumno.Delete();

        //    // actualizo la BD
        //    alumnosAdapter.Update(regAlumno);

        //    //** Otra forma: borramos el registro en la BD y recargamos la tabla
        //    //alumnosAdapter.DeleteByIdAlumno(idAlumno);
        //    //// cargar de nuevo la tabla del dgv
        //    //CargaAlumnosGrupo();
        //}

        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    if (dgv.SelectedRows.Count < 1)
        //    {
        //        MessageBox.Show("Debe seleccionar el registro a editar", "Seleccione un registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    // obtengo el id del alumno que quiero eliminar
        //    int idAlumno = Convert.ToInt32(dgv.SelectedRows[0].Cells[1].Value);

        //    // Obtengo el registro correspondiente a dicho alumno
        //    DataSet1.AlumnosRow regAlumno = alumnosTabla.FindByidAlumno(idAlumno);

        //    // Construimos el alumnos a editar
        //    Alumno alum = new Alumno(regAlumno);

            
        //    fDetalle.Alum = alum;
        //    if (fDetalle.ShowDialog() == DialogResult.OK)
        //    {
        //        // actualizo el registro
        //        regAlumno.apellidosNombre = alum.ApellidosNombre;
        //        regAlumno.dni = alum.Dni;
        //        regAlumno.movil = alum.Movil;
        //        regAlumno.telefono = alum.Telefono;
        //        regAlumno.email = alum.Email;
        //        regAlumno.idGrupo = alum.IdGrupo;

        //        // actualizo la bd
        //        alumnosAdapter.Update(regAlumno);
        //    }

        //}

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            // Construimos un alumno nuevo
            Alumno alum = new Alumno();

            // Construimos un registro nuevo
            DataSet1.AlumnosRow regAlumno = alumnosTabla.NewAlumnosRow();

            fDetalle.Alum = alum;
            if (fDetalle.ShowDialog() == DialogResult.OK)
            {
                // actualizo el registro
                regAlumno.apellidosNombre = alum.ApellidosNombre;
                regAlumno.dni = alum.Dni;
                regAlumno.movil = alum.Movil;
                regAlumno.telefono = alum.Telefono;
                regAlumno.email = alum.Email;
                regAlumno.idGrupo = alum.IdGrupo;

                alumnosTabla.AddAlumnosRow(regAlumno);
                // actualizo la bd
                alumnosAdapter.Update(regAlumno);

                lbCabecera.Text = String.Format("Alumnos de {0} ({1} alumnos)", cbGrupos.Text, dgv.RowCount);

                // Para que aparezca el idAlumno real de la BD volvemos a cargar la tabla
                CargaAlumnosGrupo();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int colum = e.ColumnIndex;
            int Fila = e.RowIndex;
            if (colum == 0) // <-- He pulsado el botón Editar
                EditarRegistro(Fila);
            else if (dgv.Columns[colum].HeaderText == "Del") // <-- He pulsado el botón borrar
                BorrarRegistro(Fila);
            else
                return; // <-- No he pulsado ninguno de los botones que me interesa
        }

        private void BorrarRegistro(int fila)
        {
            if (DialogResult.No == MessageBox.Show("¿Estás seguro de querer eliminar a:\n" + dgv.Rows[fila].Cells[5].Value.ToString() + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            return;
            // obtengo el id del alumno que quiero eliminar
            int idAlumno = Convert.ToInt32(dgv.Rows[fila].Cells[2].Value);

            // Obtengo el registro correspondiente a dicho alumno
            DataSet1.AlumnosRow regAlumno = alumnosTabla.FindByidAlumno(idAlumno);

            // elimino el registro
            regAlumno.Delete();

            // actualizo la BD
            alumnosAdapter.Update(regAlumno);

            lbCabecera.Text = String.Format("Alumnos de {0} ({1} alumnos)", cbGrupos.Text, dgv.RowCount);

            //** Otra forma: borramos el registro en la BD y recargamos la tabla
            //alumnosAdapter.DeleteByIdAlumno(idAlumno);
            //// cargar de nuevo la tabla del dgv
            //CargaAlumnosGrupo();
        }

        private void EditarRegistro(int fila)
        {
            // obtengo el id del alumno que quiero eliminar
            int idAlumno = Convert.ToInt32(dgv.Rows[fila].Cells[2].Value);


            // Obtengo el registro correspondiente a dicho alumno
            DataSet1.AlumnosRow regAlumno = alumnosTabla.FindByidAlumno(idAlumno);

            // Construimos el alumnos a editar
            Alumno alum = new Alumno(regAlumno);


            fDetalle.Alum = alum;
            if (fDetalle.ShowDialog() == DialogResult.OK)
            {
                // actualizo el registro
                regAlumno.apellidosNombre = alum.ApellidosNombre;
                regAlumno.dni = alum.Dni;
                regAlumno.movil = alum.Movil;
                regAlumno.telefono = alum.Telefono;
                regAlumno.email = alum.Email;
                regAlumno.idGrupo = alum.IdGrupo;

                // actualizo la bd
                alumnosAdapter.Update(regAlumno);
            }
        }
    }
}
