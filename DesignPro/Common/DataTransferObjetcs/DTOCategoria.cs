//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using Common.DataTransferObjects;
    
    public partial class DTOCategoria
    {
        public DTOCategoria()
        {
            this.Proyecto_categorias = new HashSet<DTOProyecto_categorias>();
        }
    
        public string Nombre { get; set; }
        public  ICollection<DTOProyecto_categorias> Proyecto_categorias { get; set; }
    }
}
