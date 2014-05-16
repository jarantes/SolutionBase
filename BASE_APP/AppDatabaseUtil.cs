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
        readonly ApplicationDBEntities _db = new ApplicationDBEntities();
        readonly AppFunctionsUtil _fn = new AppFunctionsUtil();

        public struct Menu
        {
            public int ModuleId;
            public string ModuleDescription;
            public string Checked;
            public int ImageIndex;
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

        public List<APP_USERS> GetAllUsers()
        {
            return _db.APP_USERS.ToList();
        }

        public APP_USERS GetUserByName(string userName)
        {
            var user = _db.APP_USERS.FirstOrDefault(a => a.UserName == userName);
            return user;
        }

        public APP_USERS GetUserById(int userId)
        {
            var user = _db.APP_USERS.FirstOrDefault(a => a.UserID == userId);
            return user;
        }

        public void InsertUser(APP_USERS user)
        {
            var passwordCrypted = _fn.GetMd5Hash(user.Password);
            user.Password = passwordCrypted;
            _db.APP_USERS.Add(user);
            Commit();
        }

        public void DeleteUser(int userId)
        {
            var userDeleted = _db.APP_USERS.First(a => a.UserID == userId);
            _db.APP_USERS.Remove(userDeleted);
            Commit();
        }

        public void UpdateUser(APP_USERS user)
        {
            var passwordCrypted = _fn.GetMd5Hash(user.Password);
            user.Password = passwordCrypted;
            _db.APP_USERS.AddOrUpdate(user);
            Commit();
        }

        public bool Signon(string userName, string password)
        {
            var user = GetUserByName(userName);
            var passwordCrypted = _fn.GetMd5Hash(password);
            return ((user != null) && (user.Password == passwordCrypted));
        }

        public List<APP_PROFILES> GetAllProfiles()
        {
            return _db.APP_PROFILES.ToList();
        }

        public APP_PROFILES GetProfileById(int profileId)
        {
            return _db.APP_PROFILES.FirstOrDefault(a => a.ProfileID == profileId);;
        }

        public void InsertProfile(APP_PROFILES profile)
        {
            _db.APP_PROFILES.Add(profile);
            Commit();
        }

        public void DeleteProfile(int profileId)
        {
            var profileDeleted = _db.APP_PROFILES.FirstOrDefault(a => a.ProfileID == profileId);
            _db.APP_PROFILES.Remove(profileDeleted);
            Commit();
        }

        public void UpdateProfile(APP_PROFILES profile)
        {
            _db.APP_PROFILES.AddOrUpdate(profile);
            Commit();
        }

        public List<Menu> GetModuleClassPai(int profileId)
        {
            var query = from am in _db.APP_MODULES
                        join apc in _db.APP_PROFILE_CLASS on am.ModuleID equals apc.ModuleID into a
                        from amapc in a.DefaultIfEmpty()
                        join apc in _db.APP_PROFILE_CLASS on profileId equals apc.ProfileID into c
                        from apcp in c.DefaultIfEmpty()
                        where am.ParentModuleID == null &&
                              am.Activated == "Y"
                              && (apcp.ClassID == amapc.ClassID || apcp == null || amapc == null)
                        orderby am.Ordem
                        select new { am.ModuleID, am.ModuleDescription, am.ImageIndex, Checked = (apcp.ClassID == null ? "N" : "Y") };

            var lista = new List<Menu>();

            foreach (var i in query)
            {
                var item = new Menu
                {
                    ModuleId = i.ModuleID,
                    ModuleDescription = i.ModuleDescription,
                    Checked = i.Checked,
                    ImageIndex = i.ImageIndex
                };
                lista.Add(item);
            }
            return lista;
        }

        public List<Menu> GetModuleClassFilho(int profileId, int moduleId, int parentModuleId)
        {
            var query = from am in _db.APP_MODULES
                        join apc in _db.APP_PROFILE_CLASS on am.ModuleID equals apc.ModuleID into a
                        from amapc in a.DefaultIfEmpty()
                        join apc in _db.APP_PROFILE_CLASS on profileId equals apc.ProfileID into c
                        from apcp in c.DefaultIfEmpty()
                        where (am.ParentModuleID == parentModuleId || parentModuleId == 0) &&
                              am.Activated == "Y" &&
                              (am.ModuleID == moduleId || moduleId == 0)
                              && (apcp.ClassID == amapc.ClassID || apcp == null || amapc == null)
                        orderby am.Ordem
                        select new { am.ModuleID, am.ModuleDescription, Checked = (apcp.ClassID == null ? "N" : "Y") };

            var lista = new List<Menu>();

            foreach (var i in query)
            {
                var item = new Menu
                {
                    ModuleId = i.ModuleID,
                    ModuleDescription = i.ModuleDescription,
                    Checked = i.Checked
                };
                lista.Add(item);
            }
            return lista;
        }

        public void DeleteAllProfileClass(int profileId)
        {
            var classes = _db.APP_PROFILE_CLASS.Where(a => a.ProfileID == profileId);
            _db.APP_PROFILE_CLASS.RemoveRange(classes);
            Commit();
        }

        public void InsertProfileClass(APP_PROFILE_CLASS profileClass)
        {
            _db.APP_PROFILE_CLASS.Add(profileClass);
            Commit();
        }

        public APP_MODULES GetModuleById(int moduleId)
        {
            return _db.APP_MODULES.FirstOrDefault(a => a.ModuleID == moduleId);
        }
    }
}
