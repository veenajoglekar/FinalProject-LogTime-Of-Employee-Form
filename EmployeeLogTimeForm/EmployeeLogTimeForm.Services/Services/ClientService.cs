using EmployeeLogTimeForm.DAL.Data;
using EmployeeLogTimeForm.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLogTimeForm.Services.Services
{
    public interface IClientService
    {
        public Task<List<Client>> GetAllClient();
        public Task<Client> GetClientById(int? id);

        public Task<bool> CreateClient(Client client);
        public Task UpdateClient(Client client);
        public Task DeleteClient(int id);
        public bool ClientExists(int id);
    }
    public class ClientService : IClientService
    {
        public async Task<List<Client>> GetAllClient()
        {
            using (var Context = new EmployeeLogDbContext())
            {

                return await Context.clients.ToListAsync();
            }
        }

        public async Task<Client> GetClientById(int? id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return await Context.clients.FirstOrDefaultAsync(m => m.ClientId == id);
            }
        }


        public async Task<bool> CreateClient(Client client)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                try
                {
                    Context.Add(client);
                    await Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateClient(Client client)
        {
            using (var Context = new EmployeeLogDbContext())
            {

                Context.Update(client);
                await Context.SaveChangesAsync();

            }
        }

        public async Task DeleteClient(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                var client = await Context.clients.FindAsync(id);

                Context.clients.Remove(client);
                await Context.SaveChangesAsync();
            }
        }

        public bool ClientExists(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return Context.clients.Any(e => e.ClientId == id);
            }
        }

    }
}
