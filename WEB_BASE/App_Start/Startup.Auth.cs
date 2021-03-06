﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using WEB_BASE.DataContexts;
using WEB_BASE.Models;

namespace WEB_BASE
{
    public partial class Startup
    {
        // Para obter mais informações sobre autenticação de configuração, visite http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configurar o contexto de bd e o gerenciador de usuários para usar uma única instância por solicitação
            app.CreatePerOwinContext(IdentityDb.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Habilitar o aplicativo a usar um cookie para armazenar informações do usuário logado
            // e para usar um cookie para armazenar temporariamente informações sobre um usuário fazendo logon com um provedor de logon de terceiros
            // Configurar o cookie de logon
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Remover comentário das seguintes linhas para habilitar o logon com provedores de logon de terceiros
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "898184317544-i5bi5g4fge5gr1vrtelpmt8p9krtutfh.apps.googleusercontent.com",
                ClientSecret = "vscrR1NOE78CshhuOjxYrPou"
            });
        }
    }
}