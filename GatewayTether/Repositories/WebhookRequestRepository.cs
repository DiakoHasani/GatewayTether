using GatewayTether.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            dataContext.TblWebhookRequests.Add(model);
            return dataContext.SaveChanges() > 0;
        }

        public List<TblWebhookRequest> GetWaitingForSend()
        {
            date = DateTime.Now.AddHours(-2);
            return dataContext.TblWebhookRequests.Where(a => a.Sended == false && a.SendCount < 9 && a.CreateDate > date).ToList();
        }

        public TblWebhookRequest GetById(long id)
        {
            return dataContext.TblWebhookRequests.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool Update(TblWebhookRequest model)
        {
            dataContext.Entry(model).State = EntityState.Modified;
            return dataContext.SaveChanges() > 0;
        }
    }
}
