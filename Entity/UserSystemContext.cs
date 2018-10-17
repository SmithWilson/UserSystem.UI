using Entity.Models;
using System.Data.Entity;

namespace Entity
{
    public class UserSystemContext : DbContext
    {
        public UserSystemContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
