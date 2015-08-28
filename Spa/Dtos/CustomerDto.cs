using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GenericServices.Core;
using Spa.Data.Entities;

namespace Spa.Data.Dtos
{
    public class CustomerDto: EfGenericDto<Customer, CustomerDto>
    {
        public int AccessFailedCount { get; set; }
        //public ICollection<TClaim> Claims { get; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Id { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        //public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        //public ICollection<TRole> Roles { get; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public virtual string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        public Enums.Gender? Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
        [Required]
        public CustomerGroup CustomerGroup { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ratio> Ratios { get; set; }

        protected override CrudFunctions SupportedFunctions
        {
            get { return CrudFunctions.AllCrud; }
        }
    }
}