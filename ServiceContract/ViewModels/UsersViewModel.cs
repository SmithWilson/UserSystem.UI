using System.Collections.Generic;

namespace ServiceContract.ViewModels
{
    public class UsersViewModel
    {
        public int Index { get; set; }

        public int Count { get; set; }

        public List<UserViewModel> Users { get; set; }
    }
}
