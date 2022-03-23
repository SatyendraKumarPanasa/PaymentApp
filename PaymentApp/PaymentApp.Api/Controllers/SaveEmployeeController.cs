using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Api.Controllers
{
    [ApiController]
    public class SaveEmployeeController : ControllerBase
    {
        
        private readonly ICommandQueryService _router;
        private readonly IMapper _mapper;

        public SaveEmployeeController(ICommandQueryService router, IMapper mapper)
        {
            _router = router;
            _mapper = mapper;
        }

        /// <summary>
        /// Save the Regisstered Employee Data
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        [Route("SaveEmployeeDetails", Name = "SaveEmployeeDetails")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Response<Employees>>> GetMemberDetailsByGroupAndExtMemberIdAsync(Employees employees)
        {

            var empData = await _router.ExecuteCommandAsync<Employees, Response<Employees>>(employees);

            return empData;
        }

        /// <summary>
        /// Save the Locations Data
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost("SaveLocations", Name = "SaveLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response<Location>>> SaveLocations(Location location)
        {
            var locData = await _router.ExecuteCommandAsync<Location, Response<Location>>(location);

            //return ReturnResult(empData);
            return locData;

        }

        /// <summary>
        /// Save Project Details
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        [HttpPost("SaveProjectDetails", Name = "SaveProjectDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response<Projects>>> SaveProjects(Projects projects)
        {
            var projectData = await _router.ExecuteCommandAsync<Projects, Response<Projects>>(projects);

            //return ReturnResult(empData);
            return projectData;

        }


        /// <summary>
        /// Validating the Users and Login the PaymenytAPP UI
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpPost("Login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<LoginViewModel>> Login(LoginViewModel loginViewModel)
        {
            var loginData = await _router.ExecuteCommandAsync<LoginViewModel, LoginViewModel>(loginViewModel);

          
            return loginData;

        }

        /// <summary>
        /// Save the Employee Project Payemnt Details
        /// </summary>
        /// <param name="employeeProjectPayDetails"></param>
        /// <returns></returns>
        [HttpPost("Employeeprojectpaymentdetails", Name = "Employeeprojectpaymentdetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response<EmployeeProjectPayDetails>>> projectpaymentdetailsAsync(EmployeeProjectPayDetails employeeProjectPayDetails)
        {
            var projectHistoryData = await _router.ExecuteCommandAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>>(employeeProjectPayDetails);

           
            return projectHistoryData;

        }

        /// <summary>
        /// Save the Employee Project Details Related to the Employee
        /// </summary>
        /// <param name="employeeProjects"></param>
        /// <returns></returns>
        [HttpPost("EmployeeProject", Name = "EmployeeProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response<EmployeeProject>>> Employeeprojectdetails(EmployeeProject employeeProjects)
        {
            var EmpprojectData = await _router.ExecuteCommandAsync<EmployeeProject, Response<EmployeeProject>>(employeeProjects);
            return EmpprojectData;
        }

        /// <summary>
        /// Save the User Details
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("SaveUserdetails", Name = "SaveUserdetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response<Users>>> SaveUserdetails(Users users)
        {
            var userData = await _router.ExecuteCommandAsync<Users, Response<Users>>(users);

      
            return userData;

        }

        /// <summary>
        /// Save the Employee Notes for Employee
        /// </summary>
        /// <param name="employeeNotes"></param>
        /// <returns></returns>
        [HttpPost("EmployeeNotesData", Name = "EmployeeNotesData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Response<EmployeeNotes>>> EmployeeNotesDataAsync(EmployeeNotes employeeNotes)
        {
            var empNotes = await _router.ExecuteCommandAsync<EmployeeNotes, Response<EmployeeNotes>>(employeeNotes);
            return empNotes;
        }


        /// <summary>
        /// Updating the Employees
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        [Route("Updateemployeedetails", Name = "Updateemployeedetails")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Response<Employees>>> UpdateEmployeeDetailsAsync(Employees employees)
        {

            var empData = await _router.ExecuteCommandAsync<Employees, Response<Employees>>(employees);

            return empData;
        }

        /// <summary>
        /// Updating the Employee Projects based on EmployeeID and EmployeeProjects Data
        /// </summary>
        /// <param name="employeeProject"></param>
        /// <returns></returns>
        [Route("UpdateEmployeeProject", Name = "UpdateEmployeeProject")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Response<EmployeeProject>>> UpdateEmployeeProjectDetailsAsync(EmployeeProject employeeProject)
        {

            var empprojectData = await _router.ExecuteCommandAsync<EmployeeProject, Response<EmployeeProject>>(employeeProject);

            return empprojectData;
        }

        /// <summary>
        /// Updating the ProjectDetails
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        [Route("UpdateProjectDetails", Name = "UpdateProjectDetails")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Response<Projects>>> UpdateProjectDetailsAsync(Projects projects)
        {

            var prjData = await _router.ExecuteCommandAsync<Projects, Response<Projects>>(projects);

            return prjData;
        }

        /// <summary>
        /// Updating the Employee Notes
        /// </summary>
        /// <param name="employeeNotes"></param>
        /// <returns></returns>
        [Route("UpdateemployeeNotes", Name = "UpdateemployeeNotes")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Response<EmployeeNotes>>> UpdateEmployeeNotesAsync(EmployeeNotes employeeNotes)
        {

            var empnotesData = await _router.ExecuteCommandAsync<EmployeeNotes, Response<EmployeeNotes>>(employeeNotes);

            return empnotesData;
        }

    }
}
