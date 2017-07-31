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
    public interface IPatientService
    {
        Patient GetByMaBN(string idBN);
        void Add(Patient patient);

        Patient GetByMaKH(string maKH);

        void Update(Patient patient);
        void Save();
    }
    public class PatientService : IPatientService
    {
        private IPatientRepository patientRepository;
        private IUnitOfWork unitOfWork;

        public PatientService(IPatientRepository _patientRepository, IUnitOfWork _unitOfWork)
        {
            this.patientRepository = _patientRepository;
            this.unitOfWork = _unitOfWork;
        }
        public void Add(Patient patient)
        {
            patientRepository.Add(patient);
        }

        public Patient GetByMaBN(string idBN)
        {
            return patientRepository.GetSingleByCondition(x => x.MaBenhNhan == idBN);
        }

        public Patient GetByMaKH(string maKH)
        {
            return patientRepository.GetSingleByCondition(x => x.MaKhachHang == maKH);
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(Patient patient)
        {
            patientRepository.Update(patient);
        }
    }
}
