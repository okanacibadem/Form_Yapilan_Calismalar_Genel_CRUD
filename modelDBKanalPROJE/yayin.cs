//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace modelDBKanalPROJE
{
    using System;
    using System.Collections.Generic;
    
    public partial class yayin
    {
        public yayin()
        {
            this.sorumlu = new HashSet<sorumlu>();
        }
    
        public int Id { get; set; }
        public string yayinadi { get; set; }
        public System.DateTime yayıntarih { get; set; }
        public int reyting { get; set; }
        public int kanalKanaIno { get; set; }
    
        public virtual ICollection<sorumlu> sorumlu { get; set; }
        public virtual kanal kanal { get; set; }
    }
}