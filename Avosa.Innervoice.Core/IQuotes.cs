using System;
using System.Collections.Generic;
using Avosa.Innervoice.Data;

namespace Avosa.Innervoice.Core
{
    public interface IQuotes
    {
        Confirmer Accept(Guid quoteID);
        Confirmer Cancel(Guid quoteID);
        Confirmer Create(Quote quote);
        IList<Quote> GetOverdue();
        Confirmer Reject(Guid quoteID);
    }
}