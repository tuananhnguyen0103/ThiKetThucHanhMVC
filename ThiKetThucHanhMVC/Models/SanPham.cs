using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThiKetThucHanhMVC.Models
{
    public class SanPham
    {
        private string maLoaiSanPham;
        private string maSanPham;
        private string tenSanPham;
        private string hinhAnh;
        private int giaBan;
        private int giaGiam;
        private int soLuong;
        private string moTa;

        public string MaLoaiSanPham
        {
            get { return maLoaiSanPham; }
            set { maLoaiSanPham = value; }
        }
        public string MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }
        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }
        public string HinhAnh
        {
            get { return hinhAnh; }
            set { hinhAnh = value; }
        }
        public int GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        public int GiaGiam
        {
            get { return giaGiam; }
            set { giaGiam = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }
        public SanPham()
        {

        }
        public SanPham(string MaLoaiSanPham, string MaSanPham,string TenSanPham,string HinhAnh, int GiaBan, int GiaGiam, int SoLuong, string MoTa)
        {
            this.MaLoaiSanPham = MaLoaiSanPham;
            this.MaSanPham = MaSanPham;
            this.TenSanPham = TenSanPham;
            this.HinhAnh = HinhAnh;
            this.GiaBan = GiaBan;
            this.GiaGiam = GiaGiam;
            this.SoLuong = SoLuong;
            this.MoTa = MoTa;
        }
        public IList<SanPham> GetAllSanPham(string maLoaiSanPham)
        { 
            DataTable dt = new DataTable();
            string cmdText;

                cmdText = string.Format(@"
                    Select * From dbo.SanPham
                           Where MaLoaiSanPham like '%{0}%' ",maLoaiSanPham);
            
            dt = DBConnect.log(cmdText);
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaLoaiSanPham = dr[0].ToString();
                sp.MaSanPham = dr[1].ToString();
                sp.TenSanPham = dr[2].ToString();
                sp.HinhAnh = dr[3].ToString();
                sp.GiaBan = int.Parse(dr[4].ToString());
                sp.GiaGiam = int.Parse(dr[5].ToString());
                sp.SoLuong = int.Parse(dr[6].ToString());
                sp.MoTa = dr[7].ToString();
                li.Add(sp);
            }
            return li;
        }
    }
}