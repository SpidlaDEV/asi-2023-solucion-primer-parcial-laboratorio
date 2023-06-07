
using System;

namespace resolucion_parcial
{
	public class Libro
	{	
		private Lugar lugar = new Lugar();
		
		public string Titulo { get; set; }
    	public int Edicion { get; set; }
    	public Persona Autor { get; set; }
    	public string ISBN { get; set; }
    	public int Paginas { get; set; }
    	public string Editorial { get; set; }
    	public string Lugar { get; set; }
    	public Fecha FechaEdicion { get; set; }

    	public Libro(string titulo, int edicion, Persona autor, string isbn, int paginas, string editorial, string ciudad, string pais, Fecha fechaEdicion)
    	{
	        this.Titulo = titulo;
        	this.Edicion = edicion;
        	this.Autor = autor;
        	this.ISBN = isbn;
        	this.Paginas = paginas;
        	this.Editorial = editorial;
        	this.Lugar = this.ObtenerCodigoISO(ciudad, pais);
        	this.FechaEdicion = fechaEdicion;
    	}
    	
    	public Libro(string titulo, int edicion, Persona autor, int paginas, string editorial, string ciudad, string pais, Fecha fechaEdicion)
    	{
	        this.Titulo = titulo;
        	this.Edicion = edicion;
        	this.Autor = autor;
        	this.ISBN = this.GenerarISBN();
        	this.Paginas = paginas;
        	this.Editorial = editorial;
        	this.Lugar = this.ObtenerCodigoISO(ciudad, pais);
        	this.FechaEdicion = fechaEdicion;
    	}
    	
    	// Constructor adicional para inicializar los atributos con los datos proporcionados
    	// Esto es una mala práctica tener un constructor con variables predefinidas
    	public Libro()
    	{
	        this.Titulo = "Introduction to Java Programming";
    	    this.Edicion = 3;
        	this.Autor = new Persona("Y. Daniel", "Liang");
        	this.ISBN = GenerarISBN();
        	this.Paginas = 784;
        	this.Editorial = "Prentice-Hall";
        	this.Lugar = "New Jersey (USA)";
        	this.FechaEdicion = new Fecha(16, 11, 2001);
    	}

    	// Método para generar un ISBN aleatorio
    	private string GenerarISBN()
    	{
	        Random random = new Random();
        	int[] numeros = new int[9];
        
        	for (int i = 0; i < 9; i++)
        	{
	            numeros[i] = random.Next(0, 10);
        	}
        
        	char letra = (char)random.Next('A', 'Z' + 1);
        	
        	return numeros[0] + "-" + numeros[1] + numeros[2] + "-" + numeros[3] + numeros[4] + numeros[5] + numeros[6] + numeros[7] + numeros[8] + "-" + letra;
    	}
    	
    	private string ObtenerCodigoISO(string ciudad, string pais)
    	{
    		var aux = this.lugar.ObtenerCodigoISO(pais);
    		
    		if (aux is String)
        	{
	            return ciudad + "(" + aux + ")";
        	}
        	else
        	{
	            return ciudad;
        	}
    	}

    	public String MostrarInformacionAutor(Persona autor)
    	{
	        return "Autor: " + autor;
	    }

	    public String MostrarInformacionISBN(string isbn)
	    {
        	return "ISBN: " + isbn;
    	}

    	public override string ToString()
    	{
	        string info = "Título: " + this.Titulo + "\n";
        	info += this.Edicion + "a. edición\n";
        	info += "Autor: " + this.Autor + "\n";
        	info += "ISBN: " + this.ISBN + "\n";
        	info += this.Editorial + ", " +  this.Lugar + ", " + this.FechaEdicion.ToString() + "\n";
        	info += this.Paginas + " páginas";
        	return info;
    	}
	}
}
