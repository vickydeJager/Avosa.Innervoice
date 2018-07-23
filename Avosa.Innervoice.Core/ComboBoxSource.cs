using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avosa.Innervoice.Core
{
    public class ComboBoxSource<TKey, TValue> : List<KeyValuePair<TKey,TValue>>
    {
        public void AddMember(TKey key, TValue value)
        {
            this.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }
}
