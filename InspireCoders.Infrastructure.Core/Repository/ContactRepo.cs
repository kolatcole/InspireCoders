
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class ContactRepo : IRepo<Contact>
    {

        private readonly TContext _context;

        public ContactRepo(TContext context)
        {
            _context = context;
        }


        public Task deleteAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task deleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> getAllAsync()
        {
            try
            {

                var contacts = await _context.Contacts.ToListAsync();
                return contacts;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Contact>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> getByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> getByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Contact data)
        {
            try
            {
                var contact = new Contact
                {
                    Email = data.Email,
                    Message=data.Message,
                    Subject=data.Subject
                };

                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                return contact.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Contact> data)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(Contact data)
        {
            throw new NotImplementedException();
        }
    }
}
