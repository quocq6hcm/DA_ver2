//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA_ShoesOnlineStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTHD
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public Nullable<int> Soluong { get; set; }
    
        public virtual Hoadon Hoadon { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}