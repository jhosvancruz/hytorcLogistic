//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HytorcLogistic
{
    using System;
    using System.Collections.Generic;
    
    public partial class demoYassistance
    {
        public int Id { get; set; }
        public bool demo { get; set; }
        public bool assistance { get; set; }
        public string workCenter { get; set; }
        public System.DateTime dateStart { get; set; }
        public System.DateTime dateEnd { get; set; }
        public string aplication { get; set; }
        public string toolsUsed { get; set; }
    
        public virtual Clients Clients { get; set; }
    }
}
