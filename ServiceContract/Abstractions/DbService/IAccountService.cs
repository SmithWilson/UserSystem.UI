using Entity.Models;
using System.Collections.Generic;

namespace ServiceContract.Abstractions.DbService
{
    public interface IAccountService
    {
        Account GetById(int id);

        Account GetByLogin(string login);

        int GetCount();

        List<Account> Get(int offset, int count = 10);

        int Add(Account account);

        bool Remove(int id);
    }
}
