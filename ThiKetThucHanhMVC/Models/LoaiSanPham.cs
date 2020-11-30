using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThiKetThucHanhMVC.Models
{
    public class LoaiSanPham
    {
        private string maLoaiSanPham;
        private string tenLoaiSanPham;
        private string moTa;

        public string MaLoaiSanPham
        {
            get { return maLoaiSanPham; }
            set { maLoaiSanPham = value; } 
        }
        public string TenLoaiSanPham
        {
            get { return tenLoaiSanPham; }
            set { tenLoaiSanPham = value; }
        }
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }
        public LoaiSanPham()
        {

        }
        public LoaiSanPham(string maLoaiSanPham,string tenLoaiSanPham,string moTa)
        {
            this.maLoaiSanPham = maLoaiSanPham;
            this.tenLoaiSanPham = tenLoaiSanPham;
            this.moTa = moTa;
        }
        public IList<LoaiSanPham> GetAllLoaiSanPham()
        {
            DataTable dt = new DataTable();
            string cmdText = string.Format(@"
                Select * From dbo.LoaiSanPham
                                        Go  ");
            dt = DBConnect.log(cmdText);
            List<LoaiSanPham> li = new List<LoaiSanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.MaLoaiSanPham = dr[0].ToString();
                lsp.TenLoaiSanPham = dr[1].ToString();
                lsp.MoTa = dr[2].ToString();
                li.Add(lsp);
            }
            return li;
        }
    }
}