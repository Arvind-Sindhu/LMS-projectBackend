using DomainLayer.Data;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IService;
using ServiceLayer.Service;

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

        [HttpGet("employee/{userId}")]
        public IActionResult GetEmployeeLeavesByUserId(int userId)
        {
            var leaves = _Service.GetEmployeeByUserId(userId); // Change _applyLeaveService to _Service
            return Ok(leaves);
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
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut(nameof(UpdateApplyLeave))]
        public IActionResult UpdateApplyLeave( ApplyLeave applyLeave)
        {
            if (applyLeave != null)
            {
                // Assuming your service has a method to update by userId
                _Service.Update( applyLeave);

                return Ok("Updated Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet(nameof(GetManagerNames))]
        public IActionResult GetManagerNames()
        {
            var managerNames = _Service.GetManagerNames();
            return Ok(managerNames);
        }

        [HttpGet("GetLeaveStatusForManagedUsers/{managerName}")]
        public IActionResult GetLeaveStatusForManagedUsers(string managerName)
        {
            try
            {
                // Implement the logic to retrieve leave status data for users managed by the specified managerName
                var leaveStatusList = _Service.GetLeaveStatusForManagedUsers(managerName);
                return Ok(leaveStatusList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateLeaveStatus/{userId}/{startDate}/{endDate}/{status}")]
        public async Task<IActionResult> UpdateLeaveStatus(int userId, DateTime startDate, DateTime endDate, string status)
        {
            try
            {
                // Retrieve the leave request from the database based on userId, startDate, and endDate
                var leave = await _applicationDbContext.ApplyLeaves
                    .FirstOrDefaultAsync(x =>
                        x.UserId == userId &&
                        x.StartDate == startDate &&
                        x.EndDate == endDate);

                if (leave == null)
                {
                    return NotFound();
                }

                // Update the leave status
                leave.status = status;

                // Save changes to the database
                await _applicationDbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("DeleteApplyLeave/{id}")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var screenshot = _Service.Delete(id);
            return Ok(screenshot);
        }

    }
}
