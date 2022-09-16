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
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string coiNCYRole { get; set; }
        public string SecuredFilesRole { get; set; }

        public DateTime AccountExpires { get; set; }

        public bool IsEnabled { get; set; }
        public string EmployeeId { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }

    public class FidoStoredCredential
    {
        //private Guid _id;
        //[Key]
        //public Guid Id
        //{
        //    get { return _id; }
        //}

        public string Username { get; set; }
        public byte[] UserId { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] UserHandle { get; set; }
        public uint SignatureCounter { get; set; }
        public string CredType { get; set; }
        public DateTime RegDate { get; set; }
        public Guid AaGuid { get; set; }

        [NotMapped]
        public PublicKeyCredentialDescriptor Descriptor
        {
            get { return string.IsNullOrWhiteSpace(DescriptorJson) ? null : JsonConvert.DeserializeObject<PublicKeyCredentialDescriptor>(DescriptorJson); }
            set { DescriptorJson = JsonConvert.SerializeObject(value); }
        }
        public string DescriptorJson { get; set; }
    }


}
