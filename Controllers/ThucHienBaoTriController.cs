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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThucHienBaoTriController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public ThucHienBaoTriController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }
        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "ThietBiSuaChua", "TieuChuanBaoTri" };
            var data = uow.thucHienBaoTris.GetAll(t => !t.IsDeleted && (t.MaThucHienBaoTri.ToLower().Contains(keyword.ToLower())), null, include).Select(x => new
            {
                x.Id,
                x.MaThucHienBaoTri,
                x.TieuChuanBaoTri_Id,
                x.ThietBiSuaChua.ThongTinThietBi_Id,
                ThoiGianBatDauBaoTri = string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.ThoiGianBatDauBaoTri),
                ThoiGianKetThuc = string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.ThoiGianKetThuc),
                x.HinhAnh,
                x.GhiChu,
                x.DanhGiaNguoiDung
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaThucHienBaoTri));
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            ThucHienBaoTri duLieu = uow.thucHienBaoTris.GetById(id);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }
        [HttpPost("UploadFile")]
        public ActionResult UploadFile(IFormFile file)
        {
            lock (Commons.LockObjectState)
            {
                var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
                DateTime dt = DateTime.Now;
                // Rename file
                string fileName = (long)timeSpan.TotalSeconds + "_" + Commons.TiengVietKhongDau(file.FileName);
                string fileExt = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                string path = "Uploads/Image";
                string webRootPath = environment.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), path);
                }
                if (!Directory.Exists(webRootPath))
                {
                    Directory.CreateDirectory(webRootPath);
                }
                string fullPath = Path.Combine(webRootPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new FileModel { Path = path + "/" + fileName, FileName = file.FileName });
            }
        }
        [HttpPost]
        public ActionResult Post(ThucHienBaoTri data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.thucHienBaoTris.Exists(x => x.MaThucHienBaoTri == data.MaThucHienBaoTri && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaThucHienBaoTri + " đã tồn tại trong hệ thống");
                else if (uow.thucHienBaoTris.Exists(x => x.MaThucHienBaoTri == data.MaThucHienBaoTri && !x.IsDeleted))
                {
                    var thuchienbaotri = uow.thucHienBaoTris.GetAll(x => x.MaThucHienBaoTri == data.MaThucHienBaoTri).ToArray();
                  
                    thuchienbaotri[0].IsDeleted = false;
                    thuchienbaotri[0].DeletedBy = null;
                    thuchienbaotri[0].DeletedDate = null;
                    thuchienbaotri[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    thuchienbaotri[0].UpdatedDate = DateTime.Now;
                    thuchienbaotri[0].MaThucHienBaoTri = data.MaThucHienBaoTri;
                    thuchienbaotri[0].TieuChuanBaoTri_Id = data.TieuChuanBaoTri_Id;
                    thuchienbaotri[0].ThietBiSuaChua_Id = data.ThietBiSuaChua_Id;
                    thuchienbaotri[0].HinhAnh = data.HinhAnh;
                    thuchienbaotri[0].GhiChu = data.GhiChu;
                    thuchienbaotri[0].DanhGiaNguoiDung = data.DanhGiaNguoiDung;
                    thuchienbaotri[0].ThoiGianBatDauBaoTri = data.ThoiGianBatDauBaoTri;
                    thuchienbaotri[0].ThoiGianKetThuc = data.ThoiGianKetThuc;
                    uow.thucHienBaoTris.Update(thuchienbaotri[0]);
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.thucHienBaoTris.Add(data);
                }
                uow.Complete();
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, ThucHienBaoTri data)
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
                uow.thucHienBaoTris.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                ThucHienBaoTri duLieu = uow.thucHienBaoTris.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.thucHienBaoTris.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }
        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.thucHienBaoTris.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }

}
