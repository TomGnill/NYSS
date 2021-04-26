using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYSS__Lab2.Models
{
    public class MergedData
    {
        public Data OldData { get; }
        public Data NewData { get; }

        public MergedData(Data oldData, Data newData)
        {
            OldData = oldData;
            NewData = newData;
        }
    }
}
