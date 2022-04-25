using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIQLChiTieu.Models
{
    public class Ngay
    {
        private string ngayt;
        private List<DBOChiTieu> list;
        public Ngay()
        {
            list = new List<DBOChiTieu>();
        }
        public Ngay(string ngayt, List<DBOChiTieu> list)
        {
            this.ngayt = ngayt;
            this.list = list;
        }

        public string Ngayt { get => ngayt; set => ngayt = value; }
        public List<DBOChiTieu> List { get => list; set => list = value; }
    }
}