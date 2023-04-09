using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Entities
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<TblTransfer> TblTransfers { get; set; }
        public virtual DbSet<TblWallet> TblWallets { get; set; }
        public virtual DbSet<TblError> TblErrors { get; set; }
        public virtual DbSet<TblWebhookRequest> TblWebhookRequests { get; set; }
    }
}
