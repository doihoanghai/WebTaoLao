using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Service.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();

        string getLvCodeByUserName(string userName);
    }
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        private IUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeRepository _employeeRepository, IUnitOfWork _unitOfWork)
        {
            this.employeeRepository = _employeeRepository;
            this.unitOfWork = _unitOfWork;
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public string getLvCodeByUserName(string userName)
        {
             return employeeRepository.GetSingleByCondition(p => p.Username == userName).EmployeeCode;
        }
    }
}
