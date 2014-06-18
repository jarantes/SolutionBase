using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WEB_BASE.Models
{
    // Você pode adicionar dados de perfil para o usuário adicionando mais propriedades à sua classe ApplicationUser, acesse http://go.microsoft.com/fwlink/?LinkID=317594 para saber mais.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FavoriteColor { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }
}