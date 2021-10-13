using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSGatewayAPI.Models;

namespace SMSGatewayAPI.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<SmsTemplate> SmsTemplates { get; set; }
        public DbSet<TopUp> TopUps { get; set; }
    }
}
