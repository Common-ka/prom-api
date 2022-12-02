using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController
        : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmployeeShortResponse>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeesModelList = employees.Select(x => 
                new EmployeeShortResponse()
                    {
                        Id = x.Id,
                        Email = x.Email,
                        FullName = x.FullName,
                    }).ToList();

            return employeesModelList;
        }
        
        /// <summary>
        /// Получить данные сотрудника по id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                Role = new RoleItemResponse()
                {
                    Id = employee.Id,
                    Name = employee.Role.Name,
                    Description = employee.Role.Description
                },
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return employeeModel;
        }

        /// <summary>
        /// Внести данные нового сотрудника
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployeeAsync(
            CreateOrEditEmployeeRequest request)
        {
            // var newEmployee = EmployeeMapper.MapFromModel(request);

            var newEmployee = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                AppliedPromocodesCount = request.AppliedPromocodesCount,
                RoleId = request.RoleId
            };

            await _employeeRepository.AddAsync(newEmployee);

            return CreatedAtAction(nameof(GetEmployeesAsync), new {id = newEmployee.Id}, null);
        }

        /// <summary>
        /// Удалить данные сотрудника
        /// </summary>       
        [HttpDelete]
        public async Task<ActionResult<EmployeeResponse>> DeleteEmployeeAsync(Guid id)
        {
            var employee =  await _employeeRepository.GetByIdAsync(id);

            if(employee == null)
                return NotFound();

            await _employeeRepository.DeleteAsync(employee);

            return NoContent();

        }

        /// <summary>
        /// Отредактировать данные сотрудника
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResponse>> EditEmployeeAsync(
            CreateOrEditEmployeeRequest request, Guid id)
        {
            var oldEmployee =  await _employeeRepository.GetByIdAsync(id);

            if(oldEmployee == null)
                return NotFound();

            // var editEmployee = EmployeeMapper.MapFromModel(request, oldEmployee);

            var editEmployee = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                AppliedPromocodesCount = request.AppliedPromocodesCount,
                RoleId = request.RoleId
            };

            await _employeeRepository.UpdateAsync(editEmployee);

            return NoContent();
        }
    }
}