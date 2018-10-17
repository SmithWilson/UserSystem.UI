using Entity;
using Entity.Models;
using ServiceContract.Abstractions.DbService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Implementations.DbService
{
    public class AccountService : IAccountService
    {
        private readonly UserSystemContext _context;

        public AccountService(UserSystemContext context)
        {
            _context = context;
        }

        public int Add(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var exists = _context.Accounts.FirstOrDefault(a => a.Login.ToUpper() == account.Login.ToUpper());
            if (exists != null)
            {
                return -1;
            }

            var added = _context.Accounts.Add(account);
            _context.SaveChanges();

            return added.Id;
        }

        public List<Account> Get(int offset, int count = 10)
        {
            var accounts = _context.Accounts
                .OrderByDescending(a => a.RegisterDateTime)
                .Skip(offset)
                .Take(count)
                .ToList();

            return accounts;
        }

        public Account GetById(int id)
            => _context.Accounts.FirstOrDefault(a => a.Id == id);

        public Account GetByLogin(string login)
            => _context.Accounts.FirstOrDefault(a => a.Login.ToUpper() == login.ToUpper());

        public int GetCount()
            => _context.Accounts.Count();

        public bool Remove(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }

            return true;
        }
    }
}