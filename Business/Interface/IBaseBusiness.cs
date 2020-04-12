using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IBaseBusiness<T>
    {
        T GetById(string id);
        string InsertOrUpdate(string id);
        bool Delete(string id);
        void WriteLog(string tableName, string objectId, string value, string createBy, bool isSaveChange = false);
    }
}
