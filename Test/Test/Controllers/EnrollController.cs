using System.Linq;
using System.Web.Mvc;
using Test.EF;

namespace Test.Controllers
{
    public class EnrollController : Controller
    {
        RecoveryTestEntities1 db = new RecoveryTestEntities1();

        // GET: List all students
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        // GET: Show the enrollment form
        public ActionResult Create(int? studentId)
        {
            if (studentId == null)
                return RedirectToAction("Index");

            var student = db.Students
                            .Where(s => s.student_id == studentId.Value)
                            .FirstOrDefault();

            if (student == null)
                return HttpNotFound("Student not found");

            var sports = db.Sports.ToList();
            var enrolledSportIds = db.Enrolls
                                     .Where(e => e.student_id == studentId.Value)
                                     .Select(e => e.sport_id)
                                     .ToList();

            ViewBag.Student = student;
            ViewBag.Sports = sports;
            ViewBag.EnrolledSportIds = enrolledSportIds;

            return View();
        }

        // POST: Save enrollments
        [HttpPost]
        public ActionResult Create(int studentId, int[] selectedSports)
        {
            var student = db.Students.Find(studentId);

            if (selectedSports != null && selectedSports.Length > 2)
            {
                ModelState.AddModelError("", "You can join a maximum of 2 teams only.");
                ViewBag.Student = student;
                ViewBag.Sports = db.Sports.ToList();
                ViewBag.EnrolledSportIds = selectedSports.ToList();
                return View();
            }

            // Remove old enrollments
            var existingEnrolls = db.Enrolls.Where(e => e.student_id == studentId).ToList();
            foreach (var e in existingEnrolls)
                db.Enrolls.Remove(e);

            // Add new enrollments
            if (selectedSports != null)
            {
                foreach (var sportId in selectedSports)
                {
                    Enroll enroll = new Enroll
                    {
                        student_id = studentId,
                        sport_id = sportId,
                        status = "Active"
                    };
                    db.Enrolls.Add(enroll);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
