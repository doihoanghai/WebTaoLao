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
    public interface IApplicationUserRoleService
    {
        void Add(ApplicationUserRole userRole);

        void Delete(string userId);

        void Save();
    }

    public class ApplicationUserRoleService: IApplicationUserRoleService
    {
        private IApplicationUserRoleRepository applicationUserRoleRepository;
        private IUnitOfWork unitOfWork;

        public ApplicationUserRoleService(IApplicationUserRoleRepository _applicationUserRoleRepository, IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.applicationUserRoleRepository = _applicationUserRoleRepository;
        }

        public void Delete(string userId)
        {
            this.applicationUserRoleRepository.DeleteMulti(x => x.UserId == userId);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }

        public void Add(ApplicationUserRole userRole)
        {
            this.applicationUserRoleRepository.Add(userRole);
        }
    }
}
