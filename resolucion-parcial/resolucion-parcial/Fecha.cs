
using System;

namespace resolucion_parcial
{
	public class Fecha
	{
		public int Dia { get; set; }
 		public int Mes { get; set; }
    	public int Anio { get; set; }

    	public Fecha(int dia, int mes, int anio)
    	{
        	this.Dia = dia;
	        this.Mes = mes;
        	this.Anio = anio;
	    }

    	public override string ToString()
    	{
	        DateTime fecha = new DateTime(Anio, Mes, Dia);
    	    return fecha.ToString("dddd d 'de' MMMM 'de' yyyy");
    	}
	}
}
