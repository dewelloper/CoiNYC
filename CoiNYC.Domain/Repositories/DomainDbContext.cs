namespace CoiNYC.Domain.Repositories
{
    using CoiNYC.Core.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;
    using Fido2NetLib.Objects;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    //using Microsoft.SqlServer.Management.Smo;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.SqlServer.Management.Smo;
    using CoiNYC.Domain.Currencies;
    using CoiNYC.Domain.Settings;
    using CoiNYC.Domain.Showcases;

    public class DomainDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public DomainDbContext(DbContextOptions<DomainDbContext> options)
            : base(options)
        {

        }

        public DbSet<FidoStoredCredential> FidoStoredCredential { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FidoStoredCredential>().HasKey(f => f.Username);
            base.OnModelCreating(builder);
            UsersSeed(builder);
        }

        private void UsersSeed(ModelBuilder builder)
        {
            var password = "My long 123$ password";

            var alice = new ApplicationUser
            {
                Id = "1",
                UserName = "alice",
                NormalizedUserName = "ALICE",
                Email = "AliceSmith@email.com",
                NormalizedEmail = "AliceSmith@email.com".ToUpper(),
                EmailConfirmed = true
            };
            alice.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(alice, password);

            var bob = new ApplicationUser
            {
                Id = "2",
                UserName = "bob",
                NormalizedUserName = "BOB",
                Email = "BobSmith@email.com",
                NormalizedEmail = "bobsmith@email.com".ToUpper(),
                EmailConfirmed = true
            };
            bob.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(bob, password);

            builder.Entity<ApplicationUser>()
                .HasData(alice, bob);


            builder.Entity<IdentityUserClaim<string>>()
                .HasData(
                    new IdentityUserClaim<string>
                    {
                        Id = 1,
                        UserId = "1",
                        ClaimType = "name",
                        ClaimValue = "Alice Smith"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 2,
                        UserId = "1",
                        ClaimType = "given_name",
                        ClaimValue = "Alice"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 3,
                        UserId = "1",
                        ClaimType = "family_name",
                        ClaimValue = "Smith"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 4,
                        UserId = "1",
                        ClaimType = "email",
                        ClaimValue = "AliceSmith@email.com"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 5,
                        UserId = "1",
                        ClaimType = "website",
                        ClaimValue = "http://alice.com"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 6,
                        UserId = "2",
                        ClaimType = "name",
                        ClaimValue = "Bob Smith"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 7,
                        UserId = "2",
                        ClaimType = "given_name",
                        ClaimValue = "Bob"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 8,
                        UserId = "2",
                        ClaimType = "family_name",
                        ClaimValue = "Smith"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 9,
                        UserId = "2",
                        ClaimType = "email",
                        ClaimValue = "BobSmith@email.com"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 10,
                        UserId = "2",
                        ClaimType = "website",
                        ClaimValue = "http://bob.com"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 11,
                        UserId = "1",
                        ClaimType = "email_verified",
                        ClaimValue = true.ToString()
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 12,
                        UserId = "2",
                        ClaimType = "email_verified",
                        ClaimValue = true.ToString()
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 13,
                        UserId = "1",
                        ClaimType = "address",
                        ClaimValue = @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 14,
                        UserId = "2",
                        ClaimType = "address",
                        ClaimValue = @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 15,
                        UserId = "1",
                        ClaimType = "location",
                        ClaimValue = "somewhere"
                    });
        }

        #region CMS
        public DbSet<Showcase> Showcases { get; set; }
        public DbSet<ShowcasePosition> ShowcasePositions { get; set; }

        #endregion

        #region General
        public DbSet<SettingContact> SettingContacts { get; set; }
        public DbSet<SettingEmail> SettingEmails { get; set; }
        public DbSet<SettingSocial> SettingSocials { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        

        #endregion

    }

}
