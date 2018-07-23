using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avosa.Innervoice.Core
{
    public class ManageProfile : IManageProfile
    {
        private readonly IStorage _context;
        private readonly IQuotes _quotes;
        private Profile _profile;
        private Client _activeClient;
        private Product _activeProduct;
        private Quote _activeQuote;

        public ManageProfile(IStorage context, IQuotes quotes)
        {
            _context = context;
            _profile = GetProfile();
            _quotes = quotes;
        }

        public Confirmer Create(Profile profile)
        {
            var result = new Confirmer();

            try
            {
                _context.Profiles.Add(profile);
                _context.Save();

                _profile = profile;
            }
            catch (Exception exc)
            {
                result.SetError(exc.ToString());
            }

            return result;
        }

        public bool HasProfile()
        {
            return _profile != null;
        }

        private Profile GetProfile()
        {
            return _context.Profiles.FirstOrDefault(a => !a.IsDeleted);
        }

        public string GetName()
        {
            return _profile != null ? _profile.Name : "No Profile";
        }


        public Confirmer AddClient(Client client)
        {
            var result = new Confirmer();

            try
            {
                _profile.Clients.Add(client);

                _context.Save();
            }
            catch (Exception exc)
            {
                result.SetError(exc.ToString());
            }

            return result;
        }

        public Client GetActiveClient()
        {
            return _activeClient;
        }

        public List<Client> GetClients()
        {
            return _profile.Clients;
        }

        public void SetActiveClient(Guid id)
        {
            _activeClient = _profile.Clients.FirstOrDefault(a => a.ID == id);
        }


        public Confirmer AddProduct(Product product)
        {
            var result = new Confirmer();

            try
            {
                _profile.Products.Add(product);

                _context.Save();
            }
            catch (Exception exc)
            {
                result.SetError(exc.ToString());
            }

            return result;
        }

        public Product GetActiveProduct()
        {
            return _activeProduct;
        }

        public List<Product> GetProducts()
        {
            return _profile.Products.Where(a => a.IsActive).ToList();
        }

        public void SetActiveProduct(Guid id)
        {
            _activeProduct = _profile.Products.FirstOrDefault(a => a.ID == id);
        }

        public Product GetProductByID(Guid id)
        {
            return _profile.Products.FirstOrDefault(a => a.ID == id);
        }


        public Quote GetActiveQuote()
        {
            return _activeQuote;
        }

        public void SetActiveQuote(Guid id)
        {
            _activeQuote = _activeClient.Quotes.FirstOrDefault(a => a.ID == id);
        }

        public void SetActiveQuote(Quote quote)
        {
            _activeClient.Quotes.Add(quote);
            _activeQuote = quote;
        }

        public void AddClientQuote(DateTime dueDate, List<LineItem> lineItems)
        {
            _activeQuote.DateCreated = DateTime.Now;
            _activeQuote.DueDate = dueDate;
            _activeQuote.LineItems = lineItems;

            var confirm = _quotes.Create(_activeQuote);
        }
    }
}
