using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.common
{
    public class ReturnMessageTable
    {
        bool result;
        string msg;
        object data;
        int total;
        int currentPage;

        public ReturnMessageTable(bool result, string msg, int total, int currentPage, object data)
        {

            this.result = result;
            this.msg = msg;
            this.total = total;
            this.currentPage = currentPage;
            this.data = data;
        }

        public bool Result
        {
            get { return result; }
            set { result = value; }
        }

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        public object Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
