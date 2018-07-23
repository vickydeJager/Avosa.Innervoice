using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;

namespace Avosa.Innervoice.Core
{
    public interface IManageProfile
    {
        Confirmer Create(Profile profile);

        bool HasProfile();

        string GetName();


        Confirmer AddClient(Client client);

        List<Client> GetClients();

        Client GetActiveClient();

        void SetActiveClient(Guid id);

        Confirmer AddProduct(Product product);

        List<Product> GetProducts();

        Product GetActiveProduct();

        void SetActiveProduct(Guid id);

        Product GetProductByID(Guid id);


        Quote GetActiveQuote();

        void SetActiveQuote(Guid id);

        void SetActiveQuote(Quote quote);

        void AddClientQuote(DateTime dueDate, List<LineItem> lineItems);
    }
}
