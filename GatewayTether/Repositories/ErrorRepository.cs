using GatewayTether.Entities;
using GatewayTether.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Repositories
{
    public class ErrorRepository
    {
        private readonly DataContext dataContext;
        public ErrorRepository()
        {
            dataContext = new DataContext();
        }

        public bool Add(TblError model)
        {
            dataContext.TblErrors.Add(model);
            return dataContext.SaveChanges() > 0;
        }

        public bool AddError(Exception ex, string currentMethod, string methodName)
        {
            return Add(new TblError
            {
                Line = ex.GetLineNumber(),
                Address = $"className: {currentMethod} -> methodName: {methodName}",
                CreateDate = DateTime.Now,
                HelpLink = ex.HelpLink ?? "",
                HResult = ex.HResult,
                Message = ex.Message ?? "",
                Source = ex.Source ?? "",
                StackTrace = ex.StackTrace ?? ""
            });
        }

        public bool AddError(string message, string currentMethod, string methodName)
        {
            return Add(new TblError
            {
                Line = 0,
                CreateDate = DateTime.Now,
                Message = message,
                HelpLink = "",
                HResult = 0,
                Source = "",
                StackTrace = "",
                Address = $"className: {currentMethod} -> methodName: {methodName}"
            });
        }
    }
}
