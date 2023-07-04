using GatewayTether.Entities;
using GatewayTether.Models;
using GatewayTether.XmlDocument;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
            try
            {
                return dataContext.TblWallets.ToList();
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return null;
            }
        }

        public bool Update(TblWallet wallet)
        {
            try
            {
                dataContext.Entry(wallet).State = EntityState.Modified;
                return dataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return false;
            }
        }

        public bool Add(TblWallet wallet)
        {
            try
            {
                dataContext.TblWallets.Add(wallet);
                return dataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return false;
            }
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
                            Message = "mission accomplished"
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
            catch(Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return new MessageModel
                {
                    Result = false,
                    Message = "An error occurred in the operation"
                };
            }
        }
    }
}
