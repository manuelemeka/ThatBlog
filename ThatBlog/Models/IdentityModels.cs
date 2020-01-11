using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;


namespace ThatBlog.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string UserRole { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties().Where(x =>
                    x.PropertyType.FullName != null &&
                    (x.PropertyType.FullName.Equals("System.String") &&
                    !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(q => q.TypeName != null &&
                    q.TypeName.Equals("varchar(max)", StringComparison.InvariantCultureIgnoreCase)))).Configure(c =>
                    c.HasColumnType("varchar(65000)"));

            modelBuilder.Properties().Where(x =>
                    x.PropertyType.FullName != null &&
                    (x.PropertyType.FullName.Equals("System.String") &&
                    !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(q => q.TypeName != null &&
                    q.TypeName.Equals("nvarchar", StringComparison.InvariantCultureIgnoreCase)))).Configure(c =>
                    c.HasColumnType("varchar"));
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<CommentModel> Comment { get; set; }
    }
}