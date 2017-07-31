using Bionet.Data;
using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
using Bionet.Service.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.UnitTest.Test
{
    [TestClass]
    public class ChauLucTest
    {
        IDbFactory dbFactory;
        DanhMucDichVuRepository objRepository;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new DanhMucDichVuRepository(dbFactory);
        }

        [TestMethod]
        public void ChauLuc_Repository_GetAll()
        {
            IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");
            DateTime Dt = DateTime.Parse("03/28/2017", mFomatter);
            DateTime Dt2 = DateTime.Parse("2017/03/28", mFomatter);
        }

        [TestMethod]
        public void CreateUser()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BionetDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BionetDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "admin",
            //    Email = "admin@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "PowerSoft JSC"

            //};
            //manager.Create(user, "123456$");


            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("admin@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            //string a = "";
            var user = manager.FindByName("admin");
            manager.ChangePassword(user.Id, "123123$", "123456$");

        }
    }
}
