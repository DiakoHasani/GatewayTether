using GatewayTether.Entities;
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
    public class WebhookRequestRepository
    {
        private readonly DataContext dataContext;
        private DateTime date;
        public WebhookRequestRepository()
        {
            dataContext = new DataContext();
        }

        public bool Add(TblWebhookRequest model)
        {
            try
            {
                dataContext.TblWebhookRequests.Add(model);
                return dataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return false;
            }
        }

        public List<TblWebhookRequest> GetWaitingForSend()
        {
            try
            {
                date = DateTime.Now.AddHours(-2);
                return dataContext.TblWebhookRequests.Where(a => a.Sended == false && a.SendCount < 9 && a.CreateDate > date).ToList();
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return null;
            }
        }

        public TblWebhookRequest GetById(long id)
        {
            try
            {
                return dataContext.TblWebhookRequests.Where(a => a.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return null;
            }
        }

        public bool Update(TblWebhookRequest model)
        {
            try
            {
                dataContext.Entry(model).State = EntityState.Modified;
                return dataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
                return false;
            }
        }
    }
}
