using GatewayTether.Entities;
using GatewayTether.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Repositories
{
    public class WalletRepository
    {
        private readonly DataContext dataContext;
        public WalletRepository()
        {
            dataContext = new DataContext();
        }

        public List<TblWallet> GetAll()
        {
            return dataContext.TblWallets.ToList();
        }

        public bool Update(TblWallet wallet)
        {
            dataContext.Entry(wallet).State = EntityState.Modified;
            return dataContext.SaveChanges() > 0;
        }

        public bool Add(TblWallet wallet)
        {
            dataContext.TblWallets.Add(wallet);
            return dataContext.SaveChanges() > 0;
        }

        public MessageModel ChangeEnabled(int id)
        {
            try
            {
                var wallet = dataContext.TblWallets.Where(a => a.Id == id).FirstOrDefault();
                if (wallet != null)
                {
                    wallet.Enabled = !wallet.Enabled;
                    if (Update(wallet))
                    {
                        return new MessageModel
                        {
                            Result = true,
                            Message= "mission accomplished"
                        };
                    }
                    else
                    {
                        return new MessageModel
                        {
                            Result = false,
                            Message = "An error occurred in the operation"
                        };
                    }
                }
                else
                {
                    return new MessageModel
                    {
                        Result = false,
                        Message = "notfound this wallet in database"
                    };
                }
            }
            catch
            {
                return new MessageModel
                {
                    Result = false,
                    Message = "An error occurred in the operation"
                };
            }
        }
    }
}
