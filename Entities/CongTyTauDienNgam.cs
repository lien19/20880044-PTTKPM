using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CongTyTauDienNgam
    {
        public int Id { get; set; }
        public string MaSoCongTyTDN { get; set; }
        public string TenCongTyTDN { get; set; }
        public string DiaChiCongTyTDN { get; set; }
        public string Website { get; set; }
        public string SoDienThoai { get; set; }
        public CongTyTauDienNgam()
        {

        }
        public CongTyTauDienNgam(int id, string maSoCongTyTDN, string tenCongTyTDN, string diaChiCongTyTDN, string website, string soDienThoai) //lấy ds
        {
            this.Id = id;
            this.MaSoCongTyTDN = maSoCongTyTDN;
            this.TenCongTyTDN = tenCongTyTDN;
            this.DiaChiCongTyTDN = diaChiCongTyTDN;
            this.Website = website;
            this.SoDienThoai = soDienThoai;
        }
        public CongTyTauDienNgam(string maSoCongTyTDN, string tenCongTyTDN, string diaChiCongTyTDN, string website, string soDienThoai) //thêm
        {
            this.MaSoCongTyTDN = maSoCongTyTDN;
            this.TenCongTyTDN = tenCongTyTDN;
            this.DiaChiCongTyTDN = diaChiCongTyTDN;
            this.Website = website;
            this.SoDienThoai = soDienThoai;
        }


    }
}
