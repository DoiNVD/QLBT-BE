﻿using System.Collections.Generic;
using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using NETCORE3.Repositories;

namespace NETCORE3.UOW
{
    public class UnitofWork : IUnitofWork
    {
        public IMenuRepository Menus { get; private set; }
        public INhomRepository Nhoms { get; private set; }
        public IDonViRepository DonVis { get; private set; }
        public INhaCungCapRepository NhaCungCaps { get; private set; }
        public IDonViTinhRepository DonViTinhs { get; private set; }
        public IPhanHoiRepository PhanHois { get; private set; }
        public IPhuongThucDangNhapRepository PhuongThucDangNhaps { get; private set; }
        public IMenu_RoleRepository Menu_Roles { get; private set; }
        public ILogRepository Logs { get; private set; }
        public IBoPhanRepository BoPhans { get; private set; }
        public ITapDoanRepository tapDoans { get; private set; }
        public IPhongBanRepository phongbans { get; private set; }
        public IChucVuRepository chucVus { get; private set; }
        public IDonViTraLuongRepository donViTraLuongs { get; private set; }
        public IDomainRepository domains { get; private set; }
        public ILoaiThietBiRepository loaiThietBis { get; private set; }
        public IHeThongRepository heThongs { get; private set; }
        public IHangThietBiRepository hangThietBis { get; private set; }
        public ILoaiHangThietBiRepository loaiHangThietBis { get; private set; }
        public ILoaiThongTinThietBiRepository loaiThongTinThietBis { get; private set; }
        public IThongTinHangThietBiRepository thongTinHangThietBis { get; private set; }
        public IThongTinThietBiRepository thongTinThietBis { get; private set; }
        public IChiTietLoaiThongTinThietBiRepository chiTietLoaiThongTinThietBis { get; private set; }
        public IDanhMucKhoRepository danhMucKhos { get; private set; }
        public IKhoRepository khos { get; private set; }
        public IKhoThongTinThietBiRepository khoThongTinThietBis { get; private set; }
        public IKhoLoaiThietBiRepository khoLoaiThietBis { get; private set; }
        public IHuyBaoTriRepository huyBaoTris { get; private set; }
        public ILoiRepository   lois { get; private set; }


        private MyDbContext db;
        public UnitofWork(MyDbContext _db)
        {
            db = _db;
            Menus = new MenuRepository(db);
            Nhoms = new NhomRepository(db);
            PhanHois = new PhanHoiRepository(db);
            DonViTinhs = new DonViTinhRepository(db);
            DonVis = new DonViRepository(db);
            NhaCungCaps = new NhaCungCapRepository(db);
            PhuongThucDangNhaps = new PhuongThucDangNhapRepository(db);
            Menu_Roles = new Menu_RoleRepository(db);
            Logs = new LogRepository(db);
            BoPhans = new BoPhanRepository(db);
            tapDoans = new TapDoanRepository(db);
            phongbans = new PhongBanRepository(db);
            chucVus = new ChucVuRepository(db);
            donViTraLuongs = new DonViTraLuongRepository(db);
            huyBaoTris = new HuyBaoTriRepository(db);
            domains = new DomainRepository(db);
            loaiThietBis = new LoaiThietBiRepository(db);
            heThongs = new HeThongRepository(db);
            hangThietBis = new HangThietBiRepository(db);
            loaiHangThietBis = new LoaiHangThietBiRepository(db);
            loaiThongTinThietBis = new LoaiThongTinThietBiRepository(db);
            thongTinThietBis = new ThongTinThietBiRepository(db);
            thongTinHangThietBis = new ThongTinHangThietBiRepository(db);
            chiTietLoaiThongTinThietBis = new ChiTietLoaiThongTinThietBiRepository(db);
            danhMucKhos = new DanhMucKhoRepository(db);
            khos = new KhoRepository(db);
            khoThongTinThietBis = new KhoThongTinThietBiRepository(db);
            khoLoaiThietBis = new KhoLoaiThietBiRepository(db);
            lois = new LoiRepository(db);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public int Complete()
        {
            return db.SaveChanges();
        }
    }
}