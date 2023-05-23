using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Linq;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HuyBaoTriController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public HuyBaoTriController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            var data = uow.huyBaoTris.GetAll(t => !t.IsDeleted && (t.MaHuy.ToLower().Contains(keyword.ToLower()) || t.LyDoHuy.ToLower().Contains(keyword.ToLower()))).Select(x => new
            {
                x.Id,
                x.MaHuy,
                x.LyDoHuy,
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            HuyBaoTri duLieu = uow.huyBaoTris.GetById(id);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(HuyBaoTri data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.huyBaoTris.Exists(x => x.MaHuy == data.MaHuy && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaHuy + " đã tồn tại trong hệ thống");
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.huyBaoTris.Add(data);
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, HuyBaoTri data)
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
                uow.huyBaoTris.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                HuyBaoTri duLieu = uow.huyBaoTris.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.huyBaoTris.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.huyBaoTris.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}