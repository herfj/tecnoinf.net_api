//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BussinesLogic.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Mensajes
    {
        private int ID { get; set; }
        private System.DateTime Fecha { get; set; }
        private string Cuerpo { get; set; }
        private short Visto { get; set; }
        private string Emisor { get; set; }
        private string Remitente { get; set; }
    
        private Usuarios Usuarios { get; set; }
        private Usuarios Usuarios1 { get; set; }
    }
}
