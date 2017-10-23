using MaxWebApp.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using MaxWebApp.DTOs;

namespace MaxWebApp.Controllers

{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        private AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            //private MembershipUser currentUser = Membership.GetUser();

            ;
            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.GigId == dto.gigId && a.AttendeeId == userId))
            {
                return BadRequest("You are already going");
            }
            var attendance = new Attendance
            {
                GigId = dto.gigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
