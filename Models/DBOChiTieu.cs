//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIQLChiTieu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DBOChiTieu
    {
        public int maChiTieu { get; set; }
        public int maLoaiChiTieu { get; set; }
        public string tenChiTieu { get; set; }
        public string thoiGian { get; set; }
        public string ngayThang { get; set; }
        public Nullable<int> tien { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> isChiTieu { get; set; }
        public int idicon { get; set; }
    }
}
