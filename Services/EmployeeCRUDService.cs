using NajotTalim.HR.API.Modals;
using NajotTalim.HR.DataAccess;
using NajotTalim.HR.DataAccess.Entities;

namespace NajotTalim.HR.API.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;

        public EmployeeCRUDService(IEmployeeRepository employeeRepository, IAddressRepository addressRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
        }

        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var existingAddress = await _addressRepository.GetAddress(model.AddressId);
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Salary = model.Salary
            };
            if (existingAddress != null)
                employee.Address = existingAddress;
            var createdEmployee = await _employeeRepository.CreateEmployee(employee);
            var result = new EmployeeModel
            {
                FullName = createdEmployee.FullName,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Id = createdEmployee.Id,
                Salary = createdEmployee.Salary,
                AddressId = createdEmployee.Address.Id
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            var model = new EmployeeModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Department = employee.Department,
                Email = employee.Email,
                Salary = employee.Salary
            };
            return model;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var employees = await _employeeRepository.GetEmployees();
            foreach (var employee in employees)
            {
                var model = new EmployeeModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Department = employee.Department,
                    Email = employee.Email,
                    Salary = employee.Salary
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Id = id,
                Salary = model.Salary
            };
            var updateEmployee = await _employeeRepository.UpdateEmployee(id, employee);
            var result = new EmployeeModel
            {
                FullName = updateEmployee.FullName,
                Department = updateEmployee.Department,
                Email = updateEmployee.Email,
                Id = updateEmployee.Id,
                Salary = updateEmployee.Salary
            };
            return result;
        }
    }
}
