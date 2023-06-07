using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace resolucion_parcial
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		// Crear una lista de libros
        List<Libro> listaLibros = new List<Libro>();
        
        // Crear una lista de autores
        List<Persona> personas = new List<Persona>();
        
        Lugar lugar_diccionario = new Lugar();
        Libro libro1;
        Persona autor;
        Fecha fechaEdicion;
        
		public MainForm()
		{
			InitializeComponent();
			
			// Carga de Datos
			startData();
			
			// MessaBox de control - Solo habilitar para control de la precarga
			// MessageBoxShowLibros();
			
			// Carga DataGridView
			CargarDataGridView();
			
			// Limpieza ComboBox
			ClearCombobox();
		}
		
		private void startData() 
		{
			// Crear una instancia de Persona para el autor
        	autor = new Persona("Y. Daniel", "Liang");

        	// Crear una instancia de Fecha para la fecha de edición
        	fechaEdicion = new Fecha(16, 11, 2001);

        	// Crear una instancia de Libro
        	libro1 = new Libro("Introduction to C# Programming", 2, autor, 74, "Prentice-Hall", "New Jersey", "Estados Unidos", fechaEdicion);
        	
        	listaLibros.Add(libro1);
        	
        	// Crear el segundo libro y agregarlo a la lista
        	Libro libro2 = new Libro(
            	"El proceso mental en el aprendizaje",
            	7,
            	new Persona("Jerome Seymour", "Bruner"),
            	"1-13-111597-Y",
            	578,
            	"Editorial",
            	"Madrid",
            	"España",
            	new Fecha(11, 11, 2001)
        	);
        	
        	listaLibros.Add(libro2);
        	
        	// Crear el tercer libro y agregarlo a la lista
        	Libro libro3 = new Libro(
            	"Las TIC en la enseñanza",
            	3,
            	new Persona("Enriqu Aurelio", "Barrios Queipo"),
            	683,
            	"Editorial",
            	"Madrid",
            	"España",
            	new Fecha(15, 7, 2015)
        	);
        	
        	listaLibros.Add(libro3);
        	
        	// Cargar Comobox Autor
        	comboBox1.Items.Add(autor);

			// Agregar las personas a la lista
			personas.Add(new Persona("John", "Doe"));
			personas.Add(new Persona("Jane", "Smith"));
			personas.Add(new Persona("Juan", "Pérez"));
			personas.Add(new Persona("Maria", "González"));
			
			// Agregar las personas al ComboBox
			foreach (Persona persona in personas)
			{
			    comboBox1.Items.Add(persona);
			}
			
			// Cargar Combox Paises
			// Convertir el diccionario a una lista de elementos
			List<string> listPaises = new List<string>(lugar_diccionario.paisesISO.Keys);
			
			comboBox2.DataSource = listPaises;
		}
		
		private void MessageBoxShowLibros()
		{
			// Mostrar la información de los libros en la lista
        	foreach (Libro libro in listaLibros)
        	{
	            // Mostrar la información del libro
        		MessageBox.Show(libro.ToString());

	        	// Mostrar la información del autor del libro
        		MessageBox.Show(libro.MostrarInformacionAutor(libro.Autor));

	        	// Mostrar la información del libro mediante el ISBN
        		MessageBox.Show(libro.MostrarInformacionISBN(libro.ISBN));
        	}
		}
        
		private void CargarDataGridView()
		{
			// Limpieza
			dataGridView1.Rows.Clear();

			if (dataGridView1.ColumnCount <= 0) {
				// Configurar las columnas del DataGridView
        		dataGridView1.Columns.Add("Titulo", "Título");
        		dataGridView1.Columns.Add("Edicion", "Edición");
        		dataGridView1.Columns.Add("Autor", "Autor");
        		dataGridView1.Columns.Add("ISBN", "ISBN");
        		dataGridView1.Columns.Add("Paginas", "Páginas");
        		dataGridView1.Columns.Add("Editorial", "Editorial");
        		dataGridView1.Columns.Add("Lugar", "Lugar");
        		dataGridView1.Columns.Add("FechaEdicion", "Fecha de Edición");
			}
        	

        	// Agregar los libros a las filas del DataGridView
        	foreach (Libro libro in listaLibros)
        	{
	            dataGridView1.Rows.Add(
                	libro.Titulo,
                	libro.Edicion,
                	libro.Autor.ToString(),
                	libro.ISBN,
                	libro.Paginas,
                	libro.Editorial,
                	libro.Lugar,
                	libro.FechaEdicion.ToString()
            	);
        	}
		}
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			try {
				// Verificar si se ha seleccionado algún elemento
				if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
				{
				    // Obtener el elemento seleccionado
				    autor = (Persona)comboBox1.SelectedItem;

					// Obtener el elemento seleccionado
				    string lugarSeleccionado = comboBox2.SelectedItem.ToString();
				    
				    // Obtener la fecha seleccionada del control DateTimePicker
				    DateTime fecha_select = dateTimePicker1.Value;
				    
				    fechaEdicion = new Fecha(fecha_select.Day, fecha_select.Month, fecha_select.Year);
				    
				    libro1 = new Libro(
				    	textBox1.Text,
				    	int.Parse(textBox2.Text),
				    	autor,
				    	int.Parse(textBox6.Text),
				    	textBox4.Text,
				    	textBox8.Text,
				    	lugarSeleccionado,
				    	fechaEdicion
				    );
				    
				    listaLibros.Add(libro1);
                        	dataGridView1.Rows.Add(
	                            libro1.Titulo,
                            	libro1.Edicion,
                            	libro1.Autor.ToString(),
                            	libro1.ISBN,
                            	libro1.Paginas,
                            	libro1.Editorial,
                            	libro1.Lugar,
                            	libro1.FechaEdicion.ToString()
                        	);
				    ClearLibro();
				    
				    MessageBox.Show("Libro cargado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				    
				   
				} else {
					throw new ArgumentException("No se elegido un autor");
				}
			} catch (Exception error) {
				MessageBox.Show("Ups! Algo salio mal. Revise el formulario", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		
		
		void Button2Click(object sender, EventArgs e)
		{
			ClearAutor();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			try {
				// Verificar si se ha seleccionado algún elemento
				if (string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text)) {
					throw new ArgumentException("No se elegido un autor");
				}
				
				autor = new Persona(textBox9.Text, textBox10.Text);
				
				comboBox1.Items.Add(autor);
				comboBox1.Refresh();
				ClearAutor();
				    
			    MessageBox.Show("Autor cargado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				    
			} catch (Exception error) {
				MessageBox.Show("Ups! Algo salio mal. Revise el formulario", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			ClearAutor();
		}
		
		// Métodos limpieza
		
		private void ClearAutor()
		{
			textBox9.Clear();
			textBox10.Clear();
		}
		
		private void ClearLibro()
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox4.Clear();
			textBox6.Clear();
			textBox8.Clear();
			ClearCombobox();
		}
		
		private void ClearCombobox()
		{
			comboBox1.SelectedIndex = -1;
			comboBox2.SelectedIndex = -1;
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			try {
				if (textBox3.Text.Length > 0 || textBox7.Text.Length > 0) {
					List<Libro> encontrados = new List<Libro>();
				
					if (textBox3.Text.Length > 0) {
						encontrados = listaLibros.FindAll(item => item.ISBN == textBox3.Text);
					}
				
					if (textBox7.Text.Length > 0 && encontrados.Count > 0) {
						encontrados = encontrados.FindAll(item => item.Autor.Apellido == textBox7.Text);
					} else if (textBox7.Text.Length > 0) {
						encontrados = listaLibros.FindAll(item => item.Autor.Apellido == textBox7.Text);
					} 
				
					if (encontrados.Count > 0) {
						// Limpiar las filas existentes en el DataGridView
    	    			dataGridView1.Rows.Clear();
    	    
    	    			// Agregar las filas correspondientes a los libros en la lista
    	    			foreach (Libro libro in encontrados)
    	    			{
		            		dataGridView1.Rows.Add(
    	            			libro.Titulo,
    	            			libro.Edicion,
    	            			libro.Autor.ToString(),
    	            			libro.ISBN,
    	            			libro.Paginas,
    	            			libro.Editorial,
    	            			libro.Lugar,
    	            			libro.FechaEdicion.ToString()
		            		);
		        		}
					} else {
						MessageBox.Show("No se ha encontrado ningun libro con esa descripción", "Infoermación", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				} else {
					CargarDataGridView();
				}
				
				
			} catch (Exception) {
				MessageBox.Show("Ups! Algo salio mal", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				CargarDataGridView();
			}
		}
	}
}
