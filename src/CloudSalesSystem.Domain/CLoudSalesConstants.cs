using CloudSalesSystem.Domain.Models.Accounts;
using CloudSalesSystem.Domain.Models.Customers;

namespace CloudSalesSystem.Domain
{
    public static class CLoudSalesConstants
    {
        public static readonly Guid CustomerId = new("b3fd58c6-03e6-4769-a3b7-892d12574111");

        public static readonly Guid AccountId1 = new("c73404d8-7346-4222-a576-b58f768ff1eb");
        public static readonly Guid AccountId2 = new("2bc60f98-8e04-4940-b7fb-04e2ec129c4d");
        public static readonly Guid AccountId3 = new("1225e582-71b6-4b81-ade8-6c37e32fdbc8");

        public static readonly Customer Customer = Customer.Create(CustomerId, "Customer1", "CustomerDesc");

        public static readonly Account Account1 = Account.Create(AccountId1, CustomerId, "Account1", "AccDesc1");
        public static readonly Account Account2 = Account.Create(AccountId2, CustomerId, "Account2", "AccDesc2");
        public static readonly Account Account3 = Account.Create(AccountId3, CustomerId, "Account3", "AccDesc3");

        public static readonly List<Account> Accounts = [Account1, Account2, Account3];
    }
}
