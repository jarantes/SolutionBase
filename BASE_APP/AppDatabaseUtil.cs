using BASE_APP.Context;
using BASE_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BASE_APP
{
    public class AppDatabaseUtil
    {
        readonly AppContext _db;
        readonly AppFunctionsUtil _fn;

        public AppDatabaseUtil()
        {
            _db = new AppContext();
            _fn = new AppFunctionsUtil();
            InitializePropertys();
        }

        private void InitializePropertys()
        {
            User = new AppUsers();
            if (!_db.AppUsers.Any())
            {
                _db.Database.ExecuteSqlCommand("dbo.InitializeDatabase");
            }
        }

        public struct Menu
        {
            public int ModuleId;
            public string ModuleDescription;
            public string Checked;
            public int ImageIndex;
        }

        //Propridades
        public AppUsers User { get; set; }

        //Limpar as Propriedades
        public void ClearPropertys()
        {
            User = null;
            InitializePropertys();
        }

        //Commit das transações
        public void Commit()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (DbUpdateException d)
            {
                throw new Exception(d.Message);
            }
        }

        public List<AppUsers> GetAllUsers()
        {
            return _db.AppUsers.ToList();
        }

        public AppUsers GetUserByName(string userName)
        {
            var user = _db.AppUsers.FirstOrDefault(a => a.UserName == userName);
            return user;
        }

        public AppUsers GetUserById(int userId)
        {
            var user = _db.AppUsers.FirstOrDefault(a => a.UserID == userId);
            return user;
        }

        public void InsertUser(AppUsers user)
        {
            var passwordCrypted = _fn.GetMd5Hash(user.Password);
            user.Password = passwordCrypted;
            _db.AppUsers.Add(user);
            Commit();
        }

        public void DeleteUser(int userId)
        {
            var userDeleted = _db.AppUsers.First(a => a.UserID == userId);
            _db.AppUsers.Remove(userDeleted);
            Commit();
        }

        public void UpdateUser(AppUsers user)
        {
            var passwordCrypted = _fn.GetMd5Hash(user.Password);
            user.Password = passwordCrypted;
            _db.AppUsers.AddOrUpdate(user);
            Commit();
        }

        public bool Signon()
        {
            var user = GetUserByName(User.UserName);
            var passwordCrypted = _fn.GetMd5Hash(User.Password);
            return ((user != null) && (user.Password == passwordCrypted));
        }

        public List<AppProfiles> GetAllProfiles()
        {
            return _db.AppProfiles.ToList();
        }

        public AppProfiles GetProfileById(int profileId)
        {
            return _db.AppProfiles.FirstOrDefault(a => a.ProfileID == profileId); ;
        }

        public void InsertProfile(AppProfiles profile)
        {
            _db.AppProfiles.Add(profile);
            Commit();
        }

        public void DeleteProfile(int profileId)
        {
            var profileDeleted = _db.AppProfiles.FirstOrDefault(a => a.ProfileID == profileId);
            _db.AppProfiles.Remove(profileDeleted);
            Commit();
        }

        public void UpdateProfile(AppProfiles profile)
        {
            _db.AppProfiles.AddOrUpdate(profile);
            Commit();
        }

        public List<Menu> GetModuleClassPai(int profileId)
        {
            var query = from am in _db.AppModules
                        join apc in _db.AppProfileClass
                              on new { ProfileID = profileId, am.ModuleID }
                          equals new { apc.ProfileID, apc.ModuleID } into apc_join
                        from apc in apc_join.DefaultIfEmpty()
                        join ap in _db.AppProfiles on apc.ProfileID equals ap.ProfileID into ap_join
                        from ap in ap_join.DefaultIfEmpty()
                        where
                          1 == 1 &&
                          am.ParentModuleID == null &&
                          am.Activated == "Y"
                        orderby
                          am.Ordem
                        select new
                        {
                            ModuleID = am.ModuleID,
                            am.ModuleDescription,
                            am.ImageIndex,
                            Checked =
                            apc.ClassID == null ? "N" : "Y"
                        };
            var lstMenu = new List<Menu>();

            foreach (var i in query)
            {
                var item = new Menu
                {
                    ModuleId = i.ModuleID,
                    ModuleDescription = i.ModuleDescription,
                    Checked = i.Checked,
                    ImageIndex = i.ImageIndex
                };
                lstMenu.Add(item);
            }
            return lstMenu;
        }

        public List<Menu> GetModuleClassFilho(int profileId, int moduleId, int parentModuleId)
        {
            var query = from am in _db.AppModules
                        join apc in _db.AppProfileClass
                              on new { ProfileID = profileId, am.ModuleID }
                          equals new { apc.ProfileID, apc.ModuleID } into apc_join
                        from apc in apc_join.DefaultIfEmpty()
                        join ap in _db.AppProfiles on apc.ProfileID equals ap.ProfileID into ap_join
                        from ap in ap_join.DefaultIfEmpty()
                        where
                          1 == 1 &&
                          (am.ParentModuleID == parentModuleId || parentModuleId == 0) &&
                          (am.ModuleID == moduleId || moduleId == 0) &&
                          am.Activated == "Y"
                        orderby
                          am.Ordem
                        select new
                        {
                            ModuleID = am.ModuleID,
                            am.ModuleDescription,
                            am.ImageIndex,
                            Checked =
                            apc.ClassID == null ? "N" : "Y"
                        };
            var lstMenu = new List<Menu>();

            foreach (var i in query)
            {
                var item = new Menu
                {
                    ModuleId = i.ModuleID,
                    ModuleDescription = i.ModuleDescription,
                    Checked = i.Checked
                };
                lstMenu.Add(item);
            }
            return lstMenu;
        }

        public void DeleteAllProfileClass(int profileId)
        {
            var classes = _db.AppProfileClass.Where(a => a.ProfileID == profileId);
            _db.AppProfileClass.RemoveRange(classes);
            Commit();
        }

        public void InsertProfileClass(AppProfileClass profileClass)
        {
            _db.AppProfileClass.Add(profileClass);
            Commit();
        }

        public AppModules GetModuleById(int moduleId)
        {
            return _db.AppModules.FirstOrDefault(a => a.ModuleID == moduleId);
        }
    }
}
