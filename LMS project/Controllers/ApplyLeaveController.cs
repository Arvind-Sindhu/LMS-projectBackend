using DomainLayer.Data;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;

namespace LMS_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyLeaveController : ControllerBase
    {
        private readonly IApplyLeaveService<ApplyLeave> _Service;
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplyLeaveController(IApplyLeaveService<ApplyLeave> Service, ApplicationDbContext applicationDbContext)
        {
            _Service = Service;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetEmployeeById))]
        public IActionResult GetEmployeeById(int Id)
        {
            var obj = _Service.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllEmployee))]
        public IActionResult GetAllEmployee()
        {
            var obj = _Service.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateApplyLeave))]
        public IActionResult CreateApplyLeave(ApplyLeave ApplyLeave)
        {
            if (ApplyLeave != null)
            {
                _Service.Insert(ApplyLeave);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPut(nameof(UpdateApplyLeave))]
        public IActionResult UpdateApplyLeave(ApplyLeave ApplyLeave)
        {
            if (ApplyLeave != null)
            {
                _Service.Update(ApplyLeave);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteApplyLeave))]
        public IActionResult DeleteApplyLeave(ApplyLeave ApplyLeave)
        {
            if (ApplyLeave != null)
            {
                _Service.Delete(ApplyLeave);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}

