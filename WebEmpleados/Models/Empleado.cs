using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEmpleados.Models
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public decimal sueldo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool tiempoCompleto { get; set; }

        //Propiedades de Solo Lectura
        public string tiempoCompletoDescripcion
        {
            get
            {
                if (tiempoCompleto == true)
                    return "Si";
                else
                    return "No";
            }
        }

        public int Edad
        {
            get
            {
                DateTime fechaActual = DateTime.Now;
                int edad = fechaActual.Year - fechaNacimiento.Year;
                return edad;
            }
        }

        
    }
}