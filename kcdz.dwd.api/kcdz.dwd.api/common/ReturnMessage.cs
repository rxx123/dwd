using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.common
{
    public class ReturnMessage
    {
        bool result;
        string msg;
        object data;

        public ReturnMessage(bool result, string msg, object data)
        {
            this.result = result;
            this.msg = msg;
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

        public object Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
