using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PaymentApp.Core.DomainModels;
using PaymentApp.Core;
using PaymentApp.Service;
using dCaf.Core;

namespace PaymentApp.Api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICommandQueryService _router;
        private readonly IMapper _mapper;

        public EmployeeController(ICommandQueryService router, IMapper mapper)
        {
            _router = router;
            _mapper = mapper;
        }
        /// <summary>
        /// Get Employees location based on location Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Locaton/{id}", Name = "GetLocationsDatabyLocationId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Location>>> GetMemberDetailsByGroupAndExtMemberIdAsync(int id)
        {

            var locations = await _router.ExecuteQueryAsync<int, List<Location>>(id);

            return ReturnResult(locations);
        }
        /// <summary>
        /// Get All Locations
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLocations", Name = "GetAllLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Location>>> GetAllLocationsAsync()
        {

            var locData = await _router.ExecuteQueryAsync<List<Location>>();

            return ReturnResult(locData);
        }
        /// <summary>
        /// Get Employees Benfits based on Benfit Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Benifit/{id}", Name = "GetEmployeeBenifitDetailsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Benfits>> GetEmployeeBenifitDetailsByIdAsync(int id)
        {

            var benfits = await _router.ExecuteQueryAsync<int, Benfits>(id);

            return benfits;
        }

        /// <summary>
        /// Get Employees Clients based on Client Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Client/{id}", Name = "GetClientDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Clients>> GetClientDetailByIdAsync(int id)
        {

            var client = await _router.ExecuteQueryAsync<int, Clients>(id);

            return ReturnResult(client);
        }

        /// <summary>
        /// Get Employee projects based on Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/EmployeeProject/{id}", Name = "GetEmployeeProjectDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<EmployeeProject>> GetEmployeeProjectDetailByIdAsync(int id)
        {

            var employeeProject = await _router.ExecuteQueryAsync<int, EmployeeProject>(id);

            return ReturnResult(employeeProject);
        }
        /// <summary>
        /// Get Employee Details based on Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Employees/{id}", Name = "GetEmployeesDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Employees>> GetEmployeeDetailByIdAsync(int id)
        {

            var employee = await _router.ExecuteQueryAsync<int, Employees>(id);

            return ReturnResult(employee);
        }

        /// <summary>
        /// GetAllEmployees
        /// </summary>
        /// <returns></returns>
        [HttpGet("employees/Employees", Name = "GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Employees>>> GetAllEmployees()
        {

            var emp = await _router.ExecuteQueryAsync<List<Employees>>();

            return ReturnResult(emp);
        }

        /// <summary>
        /// Get EmployeeType Details based on Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/EmployeeType/{id}", Name = "GetEmployeesTypeDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<EmployeeType>> GetEmployeeTypeDetailByIdAsync(int id)
        {

            var employeeType = await _router.ExecuteQueryAsync<int, EmployeeType>(id);

            return ReturnResult(employeeType);
        }

        /// <summary>
        /// GetAllEmployeeTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEmployeeTypes", Name = "GetAllEmployeeTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<EmployeeType>>> GetAllEmployeeTypesAsync()
        {

            var empTypeData = await _router.ExecuteQueryAsync<List<EmployeeType>>();

            return ReturnResult(empTypeData);
        }
        /// <summary>
        /// Get Employee Notes based on Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/EmployeeNote/{id}", Name = "GetEmployeesNoteDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<EmployeeNotes>>> GetEmployeeNotesDetailByIdAsync(int id)
        {

            var employeeNotes = await _router.ExecuteQueryAsync<int, List<EmployeeNotes>>(id);

            return ReturnResult(employeeNotes);
        }
        /// <summary>
        /// Get Employee project Paye details based on Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/EmployeeProjectPayDetails/{id}", Name = "GetEmployeesProjectPayDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<EmployeeProjectPayDetails>>> GetEmployeesProjectPayDetailByIdAsync(int id)
        {

            var employeeProjectPayDetails = await _router.ExecuteQueryAsync<int, List<EmployeeProjectPayDetails>>(id);

            return ReturnResult(employeeProjectPayDetails);
        }
        /// <summary>
        /// Get Employee projects based on Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Projects/{id}", Name = "GetProjectsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Projects>>> GetProjectsByIdAsync(int id)
        {

            var project = await _router.ExecuteQueryAsync<int, List<Projects>>(id);

            return ReturnResult(project);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        [HttpPost("Projects/Search", Name = "GetProjectsByProjectName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Projects>>> GetProjectsByProjectNameAsync(ProjectSearch projectSearch)
        {

            var project = await _router.ExecuteQueryAsync<ProjectSearch, List<Projects>>(projectSearch);

            return ReturnResult(project);
        }

        /// <summary>
        /// GetAllProjects
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProjects", Name = "GetAllProjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]

        public async Task<ActionResult<List<Projects>>> GetAllProjects()
        {
            var projectData = await _router.ExecuteQueryAsync<List<Projects>>();
            return ReturnResult(projectData);
        }

        /// <summary>
        /// Get Project Status Details based on Project Status Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/ProjectStatus/{id}", Name = "GetProjectStatusById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<ProjectStatus>> GetProjectStatusByIdAsync(int id)
        {

            var projectStatus = await _router.ExecuteQueryAsync<int, ProjectStatus>(id);

            return ReturnResult(projectStatus);
        }

        ///
        [HttpGet("getAllProjectStatus", Name = "getAllProjectStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<ProjectStatus>>> GetAllProjectStatusAsync()
        {

            var projectAllStatus = await _router.ExecuteQueryAsync<List<ProjectStatus>>();

            return ReturnResult(projectAllStatus);
        }

        /// <summary>
        /// Get Employee Roles Details based on Role Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Roles/{id}", Name = "GetRolesById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Roles>> GetRolesByIdAsync(int id)
        {

            var role = await _router.ExecuteQueryAsync<int, Roles>(id);

            return ReturnResult(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllRoles", Name = "getAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Roles>>> GetRolesAsync()
        {

            var roles = await _router.ExecuteQueryAsync<List<Roles>>();

            return ReturnResult(roles);
        }

        /// <summary>
        /// Get Users Details based on User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("User/{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Users>> GetUserByIdAsync(int id)
        {

            var user = await _router.ExecuteQueryAsync<int, Users>(id);

            return ReturnResult(user);
        }

        /// <summary>
        /// Get Employee Vendor Details based on Vendor Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/Vendor/{id}", Name = "GeVendorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<Vendors>> GetVendorByIdAsync(int id)
        {

            var vendor = await _router.ExecuteQueryAsync<int, Vendors>(id);

            return ReturnResult(vendor);
        }

        /// <summary>
        /// GetAllVendors
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllVendors", Name = "GetAllVendors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Vendors>>> GetAllVendorsAsync()
        {

            var vendorData = await _router.ExecuteQueryAsync<List<Vendors>>();

            return ReturnResult(vendorData);
        }

        /// <summary>
        /// Get VisaStatus Based on Employee visastatus Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/VisaStatus/{id}", Name = "GeVisaStatusById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<VisaStatus>> GetVisaStatusByIdAsync(int id)
        {

            var visaStatus = await _router.ExecuteQueryAsync<int, VisaStatus>(id);

            return ReturnResult(visaStatus);
        }

        /// <summary>
        /// GetAllVisaStatus
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllVisaStatus", Name = "GetAllVisaStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<VisaStatus>>> GetAllVisaStatusAsync()
        {

            var visaStatusTypes = await _router.ExecuteQueryAsync<List<VisaStatus>>();

            return ReturnResult(visaStatusTypes);
        }

        /// <summary>
        /// GetAllSalaryTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet("employee/SalaryTypes", Name = "GetAllSalaryTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<SalaryType>>> GetAllSalaryTypesAsync()
        {

            var salarytypes = await _router.ExecuteQueryAsync<List<SalaryType>>();

            return ReturnResult(salarytypes);
        }

        /// <summary>
        /// Get Registered Employee Details Based on Firstname and Lastname
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        [HttpPost("employee/Search", Name = "GetEmployeeRegisterDetailsByFirstname and LastName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Employees>>> GetAllEmployeesRegisterDetails(EmployeeSearchRequest searchRequest)
        {

            var empRegData = await _router.ExecuteQueryAsync<EmployeeSearchRequest, List<Employees>>(searchRequest);

            return ReturnResult(empRegData);
        }


        /// <summary>
        /// Get UserData using Search Request based on Inputs
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        [HttpPost("user/Search", Name = "GetUserRegisterDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<Users>>> GetAllUsersRegisterDetails(UserSearchRequest searchRequest)
        {

            var userRegData = await _router.ExecuteQueryAsync<UserSearchRequest, List<Users>>(searchRequest);

            return ReturnResult(userRegData);
        }

        /// <summary>
        /// Get All Employee Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployeeProjects", Name = "GetEmployeeProjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<ListEmployeeProjects>>> GetEmployeeProjectsAsync()
        {

            var listemployeeProjects = await _router.ExecuteQueryAsync<List<ListEmployeeProjects>>();

            return ReturnResult(listemployeeProjects);
        }


        /// <summary>
        /// Get Employee Projects based on EmployeeID
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployeeProjectByEmployee/{id}", Name = "GetEmployeeProjectByEmployeeId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorBase))]
        public async Task<ActionResult<List<ListEmployeeProjects>>> GetEmployeeProjectsByEmployeeIdAsync(int id)
        {

            var listemployeeProjects = await _router.ExecuteQueryAsync<int, List<ListEmployeeProjects>>(id);

            return ReturnResult(listemployeeProjects);
        }

        private ActionResult ReturnResult(dCaf.Core.Response<bool?> response)
        {
            if (response.Result == null)
            {
                return NotFound();
            }
            else if (response.Errors.Any())
            {
                var problemDetails = CreateValidationProblemDetails(response.Errors);
                return UnprocessableEntity(problemDetails);
            }

            return Ok();
        }
        protected ValidationProblemDetails CreateValidationProblemDetails(IDictionary<string, string[]> errors)
        {
            return new ValidationProblemDetails(errors)
            {
                Type = "https://httpstatuses.com/422",
                Title = "One or more model validation errors occurred.",
                Status = StatusCodes.Status422UnprocessableEntity,
                Detail = "See the errors property for details.",
                Instance = HttpContext?.Request?.Path
            };
        }

        protected ActionResult<T> ReturnResult<T>(dCaf.Core.Response<T> response)
        {
            if (response.Errors != null && response.Errors.Any())
            {
                var problemDetails = CreateValidationProblemDetails(response.Errors);
                return UnprocessableEntity(problemDetails);
            }

            return ReturnResult(response.Result);
        }

        protected ActionResult<T> ReturnResult<T>(T value)
        {
            if (value == null)
                return NotFound();

            return Ok(value);
        }

    }
}
