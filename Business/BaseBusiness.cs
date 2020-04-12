using Business.Interface;
using Common;
using Common.Model;
using Model.Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business
{
    public abstract class BaseBusiness<T> //: IBaseBusiness<T>
    {
        public BaseBusiness()
        {
            baseDbContext = new BaseDbContext();
        }
        public abstract T GetById(string id);
        public abstract string InsertOrUpdate(string id);
        public abstract bool Delete(string id);
        public void WriteLog(string tableName, string objectId, string value, string createBy, string ipAddress, string browserName, bool isSaveChange = false)
        {
            try
            {
                var log = new Log
                {
                    Id = Guid.NewGuid().ToString(),
                    TableName = tableName,
                    ObjectId = objectId,
                    Value = Encoding.UTF8.GetBytes(value),
                    CreateBy = createBy,
                    IpAdress = ipAddress,
                    Browser = browserName
                };
                baseDbContext.Logs.Add(log);
                if (isSaveChange)
                {
                    baseDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected BaseDbContext baseDbContext;
    }
}
