using Hospital.Common.Utilities;
using HospitalManagement.Areas.Admin.Models;
using HospitalManagement.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HospitalManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HospitalController> _logger;
        private readonly IEmailSender _emailSender;
        public HospitalController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<HospitalController> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Register(string returnUrl = null)
        {
            var model = new RegisterModel();
            model.ReturnUrl = returnUrl;
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();



            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.ActionLink(
                        "/Account/ConfirmEmail",
                        values: new { userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToAction("Index", "Hospital", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [TempData]
        public string ErrorMessage { get; set; }


        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            var model = new LoginModel();
            model.ReturnUrl = returnUrl;

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("ManageDoctor");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Hospital");
            }
        }









        public IActionResult ManageDoctor()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new DoctorListModel();
            return View(model);
        }

        public JsonResult GetDoctorData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new DoctorListModel();
            var data = model.GetDoctors(dataTablesModel);
            return Json(data);
        }
        public IActionResult AddDoctor()
        {
            var model = new AddDoctorModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddDoctor(AddDoctorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddDoctor();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Doctor");
                    _logger.LogError(ex, "Add doctor Failed");
                }

            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new EditDoctorModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditDoctorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            var model = new DoctorListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));

        }



        
        
        
        public IActionResult ManageTest()
        {
            ViewBag.SomeData = "Hello From Manage Test";
            var model = new TestListModel();
            return View(model);
        }

        public JsonResult GetTestData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new TestListModel();
            var data = model.GetTests(dataTablesModel);
            return Json(data);
        }


        public IActionResult AddTest()
        {
            var model = new AddTestModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddTest(AddTestModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddTest();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Test");
                    _logger.LogError(ex, "Add test Failed");
                }

            }
            return View(model);
        }

       
        public IActionResult EditTest(int id)
        {
            var model = new EditTestModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditTest(EditTestModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteTest(int id)
        {
            var model = new TestListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageTest));

        }






        public IActionResult ManageEmployee()
        {
            ViewBag.SomeData = "Hello From Employee";
            var model = new EmployeeListModel();
            return View(model);
        }

        public JsonResult GetEmployeeData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeListModel();
            var data = model.GetEmployees(dataTablesModel);
            return Json(data);
        }

        public IActionResult AddEmployee()
        {
            var model = new AddEmployeeModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddEmployee(AddEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddEmployee();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Employee");
                    _logger.LogError(ex, "Add employee Failed");
                }

            }
            return View(model);
        }

        public IActionResult EditEmployee(int id)
        {
            var model = new EditEmployeeModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditEmployee(EditEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteEmployee(int id)
        {
            var model = new EmployeeListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageEmployee));

        }









        public IActionResult ManagePatient()
        {
            ViewBag.SomeData = "Hello From Patient";
            var model = new PatientListModel();
            return View(model);
        }

        public JsonResult GetPatientData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new PatientListModel();
            var data = model.GetPatients(dataTablesModel);
            return Json(data);
        }
        public IActionResult AddPatient()
        {
            var model = new AddPatientModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddPatient(AddPatientModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddPatient();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to schedule Appointment");
                    _logger.LogError(ex, "Add Patient Failed");
                }

            }
            return View(model);
        }
        public IActionResult EditPatient(int id)
        {
            var model = new EditEmployeeModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditPatient(EditEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeletePatient(int id)
        {
            var model = new EmployeeListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageEmployee));

        }





        public IActionResult DoctorList()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new DoctorListModel();
            return View(model);
        }

        public JsonResult GetDoctorList()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new DoctorListModel();
            var data = model.GetDoctors(dataTablesModel);
            return Json(data);
        }



        public IActionResult TestList()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new TestListModel();
            return View(model);
        }

        public JsonResult GetTestList()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new TestListModel();
            var data = model.GetTests(dataTablesModel);
            return Json(data);
        }

        public IActionResult ScheduleList()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new ScheduleListModel();
            return View(model);
        }

        public JsonResult GetScheduleList()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ScheduleListModel();
            var data = model.GetSchedules(dataTablesModel);
            return Json(data);
        }








        public IActionResult ManageSchedule()
        {
            ViewBag.SomeData = "Hello From Patient";
            var model = new ScheduleListModel();
            return View(model);
        }

        public JsonResult GetScheduleData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ScheduleListModel();
            var data = model.GetSchedules(dataTablesModel);
            return Json(data);
        }
        public IActionResult AddSchedule()
        {
            var model = new AddScheduleModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddSchedule(AddScheduleModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddSchedule();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Appointment");
                    _logger.LogError(ex, "Add Schedule Failed");
                }

            }
            return View(model);
        }
        public IActionResult EditSchedule(int id)
        {
            var model = new EditScheduleModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditSchedule(EditScheduleModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteSchedule(int id)
        {
            var model = new ScheduleListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageSchedule));

        }



    }
}
