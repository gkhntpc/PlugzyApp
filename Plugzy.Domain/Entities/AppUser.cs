using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Plugzy.Domain.Abstract;
using Plugzy.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Domain.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        [MaxLength(100)]
        public override string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(100)]
        public override string? Email { get; set; }
        public Type Type { get; set; }
        public Status Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Int64 CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Int64? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public Int64? DeletedAt { get; set; }
        public AppUser()
        {
            Id= Guid.NewGuid();
            CreatedBy = Id;
        }
    }
    public enum Status
    {
        Active=1,
        Banned
    }
    public enum Type
    {
        Register=1,
        Login
    }
}
