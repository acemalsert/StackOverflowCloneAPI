//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StackOverflowCloneAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int id { get; set; }
        public string commentText { get; set; }
        public int FKquestionId { get; set; }
    
        public virtual Questions Questions { get; set; }
    }
}
