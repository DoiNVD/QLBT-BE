using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThietBiSuaChuaController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public ThietBiSuaChuaController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }


        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "DonViTinh", "ThongTinThietBi", "loiThietBiSuaChuas.Loi" };
            var data = uow.thietBiSuaChuas.GetAll(t => !t.IsDeleted && (t.MaThietBiSuaChua.ToLower().Contains(keyword.ToLower()) || t.ThongTinThietBi.TenThietBi.ToLower().Contains(keyword.ToLower())), null, include).Select(x => new
            {
                x.Id,
                x.MaThietBiSuaChua,
                x.SoLuong,
                x.GhiChu,
                x.DonViTinh.TenDonViTinh,
                x.ThongTinThietBi.TenThietBi,
                lstLois = x.loiThietBiSuaChuas.Select(y => new
                {
                    y.Loi.TenLoi,
                })
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenThietBi));
        }


        public class ClassListThietBiSuaChua
        {
            public Guid Id { get; set; }
            public string MaThietBiSuaChua { get; set; }
            public string TenThietBiSuaChua { get; set; }
            public int SoLuong { get; set; }
            public string GhiChu { get; set; }
            public string TenDonVi { get; set; }
            public string TenLoi { get; set; }

        }

        [HttpGet("GetDataPagnigation")]
        public ActionResult GetDataPagnigation(int page = 1, int pageSize = 2, string keyword = null)
        {
            if (keyword == null) keyword = "";
            string[] include = { "DonViTinh", "ThongTinThietBi", "loiThietBiSuaChuas.Loi" };
            var query = uow.thietBiSuaChuas.GetAll(t => !t.IsDeleted && (t.MaThietBiSuaChua.ToLower().Contains(keyword.ToLower()) || t.ThongTinThietBi.TenThietBi.ToLower().Contains(keyword.ToLower())), null, include)
            .Select(x => new
            {
                x.ThongTinThietBi,
                x.ThongTinThietBi_Id,
                x.Id,
                x.MaThietBiSuaChua,
                x.DonViTinh_Id,
                x.SoLuong,
                x.GhiChu,
                lstLois = x.loiThietBiSuaChuas.Select(y => new
                {
                    y.Loi.TenLoi,
                })
            }).OrderBy(x => x.ThongTinThietBi_Id);

            List<ClassListThietBiSuaChua> list = new List<ClassListThietBiSuaChua>();

            foreach (var item in query)
            {
                var thietbisuachua = uow.thietBiSuaChuas.GetAll(x => !x.IsDeleted && x.Id == item.ThongTinThietBi_Id, null, null).Select(x => new { x.ThongTinThietBi.TenThietBi }).ToList();
                var donViTinh = uow.DonViTinhs.GetAll(x => !x.IsDeleted && x.Id == item.DonViTinh_Id, null, null).Select(x => new { x.TenDonViTinh }).ToList();

                var infor = new ClassListThietBiSuaChua();
                infor.Id = item.Id;
                infor.GhiChu = item.GhiChu;
                infor.SoLuong = item.SoLuong;
                infor.MaThietBiSuaChua = item.MaThietBiSuaChua;
                infor.TenThietBiSuaChua = item.ThongTinThietBi.TenThietBi;
                infor.TenDonVi = donViTinh[0].TenDonViTinh;
                list.Add(infor);
            }
            int totalRow = list.Count();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(new { data, totalPage, totalRow });
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "loiThietBiSuaChuas.Loi" };
            var duLieu = uow.thietBiSuaChuas.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }


        [HttpPost]
        public ActionResult Post(ThietBiSuaChua data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.thietBiSuaChuas.Exists(x => x.MaThietBiSuaChua == data.MaThietBiSuaChua && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaThietBiSuaChua + " đã tồn tại trong hệ thống");
                else if (uow.thietBiSuaChuas.Exists(x => x.MaThietBiSuaChua == data.MaThietBiSuaChua && !x.IsDeleted))
                {
                    var thietbisuachua = uow.thietBiSuaChuas.GetAll(x => x.MaThietBiSuaChua == data.MaThietBiSuaChua).ToArray();
                    thietbisuachua[0].IsDeleted = false;
                    thietbisuachua[0].DeletedBy = null;
                    thietbisuachua[0].DeletedDate = null;
                    thietbisuachua[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    thietbisuachua[0].UpdatedDate = DateTime.Now;
                    thietbisuachua[0].MaThietBiSuaChua = data.MaThietBiSuaChua;
                    thietbisuachua[0].ThongTinThietBi.TenThietBi = data.ThongTinThietBi.TenThietBi;
                    thietbisuachua[0].DonViTinh_Id = data.DonViTinh_Id;
                    thietbisuachua[0].SoLuong = data.SoLuong;
                    thietbisuachua[0].ThongTinThietBi_Id = data.ThongTinThietBi_Id;
                    thietbisuachua[0].SoLuong = data.SoLuong;
                    thietbisuachua[0].GhiChu = data.GhiChu;
                    uow.thietBiSuaChuas.Update(thietbisuachua[0]);
                    foreach (var item in data.lstLois)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.ThietBiSuaChua_Id = thietbisuachua[0].Id;
                        uow.loiThietBiSuaChuas.Add(item);
                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.thietBiSuaChuas.Add(data);
                    foreach (var item in data.lstLois)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.ThietBiSuaChua_Id = id;
                        // item.Loi_Id = id;
                        uow.loiThietBiSuaChuas.Add(item);
                    }
                }
                uow.Complete();
                return Ok();
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(Guid id, ThietBiSuaChua data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != data.Id)
                {
                    return BadRequest();
                }
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;

                uow.thietBiSuaChuas.Update(data);
                var lstLois = data.lstLois;
                var dataCheck = uow.loiThietBiSuaChuas.GetAll(x => !x.IsDeleted && x.ThietBiSuaChua_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!lstLois.Exists(x => x.Loi_Id == item.Loi_Id))
                        {
                            uow.loiThietBiSuaChuas.Delete(item.Id);
                        }
                    }
                    foreach (var item in lstLois)
                    {
                        if (!dataCheck.Exists(x => x.Loi_Id == item.Loi_Id))
                        {
                            item.ThietBiSuaChua_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.loiThietBiSuaChuas.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in lstLois)
                    {
                        item.ThietBiSuaChua_Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        uow.loiThietBiSuaChuas.Add(item);
                    }
                }
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                ThietBiSuaChua duLieu = uow.thietBiSuaChuas.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataCheck = uow.loiThietBiSuaChuas.GetAll(x => !x.IsDeleted && x.ThietBiSuaChua_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.loiThietBiSuaChuas.Delete(item.Id);
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.thietBiSuaChuas.Update(duLieu);
                    uow.Complete();
                    return Ok(duLieu);
                }
                return StatusCode(StatusCodes.Status409Conflict, "Bạn chỉ có thể chỉnh sửa thông tin thiết bị này");
            }
        }

        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.thietBiSuaChuas.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }

}
