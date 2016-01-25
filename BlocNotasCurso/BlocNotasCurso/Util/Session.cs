using System;
using System.Collections.Generic;

namespace BlocNotasCurso.Util
{
    public class Session
    {
        private  Dictionary<string, object> _session = new Dictionary<string, object>();

        public Object this[String index]
        {
            get { return _session[index]; }

            set { _session[index] = value; }
        }

    }
}