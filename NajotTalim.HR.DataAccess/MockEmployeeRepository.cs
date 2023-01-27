
using NajotTalim.HR.DataAccess.Entities;
using System.Collections.Concurrent;

namespace NajotTalim.HR.DataAccess
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private static object locker = new();


        public MockEmployeeRepository()
        {
            Init();
        }


        private void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, FullName = "Erkinov Burxoniddin", Department = "FullStack Developer", Email = "erkinovb@gmail.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "Ro'zmatov Begzodbek", Department = "Businessman", Email = "rozmatovb@gmail.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "Toxirov Xumoyun", Department = "Grafik Dizayner", Email = "toxirovx@gmail.com" });
            _employees.TryAdd(4, new Employee { Id = 4, FullName = "Mo'ydinov Mo'minjon", Department = "Flutter Developer", Email = "moydinovm@gmail.com" });

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Task.FromResult(_employees.Values);
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            int newid = 0;
            lock (locker)
            {
                newid = _employees.Keys.Max() + 1;
            }
            employee.Id = newid;
            _employees.TryAdd(newid, employee);
            return await Task.FromResult(employee);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            await Task.FromResult(_employees[id] = employee);
            return employee;
        }

        public Task<bool> DeleteEmployee(int id)
        {
           if(_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);    
                return Task.FromResult(true);
            }
           else
            {
                return Task.FromResult(false);

            }
        }
    }
}
