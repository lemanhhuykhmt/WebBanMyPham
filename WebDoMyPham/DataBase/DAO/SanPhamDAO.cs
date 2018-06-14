using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebBanMyPham.DataBase.DAO
{
    public static class SanPhamDAO
    {
        private static MyPhamContext db = new MyPhamContext();
    //    public static List<SanPham> GetList()
    //    {
    //        return (from p in db.SanPhams where p.TrangThai == true select p).ToList();
    //    }
    //    public static int Insert (SanPham entity)
    //    {
    //        db.SanPhams.Add(entity);
    //        db.SaveChanges();
    //        return entity.MaSP;
    //    }
    //    public static bool Update (SanPham entity)
    //    {
    //        try
    //        {
    //            SanPham sp = db.SanPhams.Find(entity.MaSP);
    //            sp.TenSP = entity.TenSP;
    //            sp.MaLoaiSP = entity.MaLoaiSP;
    //            sp.AnhDaiDien = entity.AnhDaiDien;
    //            sp.DonGia = entity.DonGia;
    //            sp.DonViDo = entity.DonViDo;
    //            sp.SoLuong = entity.SoLuong;
    //            sp.TrangThai = entity.TrangThai;
    //            db.SaveChanges();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            return false;
    //        }
    //    }
    //    public static bool Delete (int id)
    //    {
    //        try
    //        {
    //            var sp = db.SanPhams.Find(id);
    //            db.SanPhams.Remove(sp);
    //            db.SaveChanges();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            return false;
    //        }
    //    }
    //    public static SanPham GetByID(int? id)
    //    {
    //        return db.SanPhams.Find(id);
    //    }
    }
}