using CloudSalesSystem.Application.CloudComputingService.Models;

namespace CCPService
{
    public static class MockCloudComputingData
    {
        private static List<SoftwareService> SoftwareServices = new List<SoftwareService>
        {
            new SoftwareService(Guid.Parse("0c686230-e2dd-4023-affb-31761333155d"), "Software 1", "Description 1", 100, 350, DateTime.Now.AddDays(30)),
            new SoftwareService(Guid.Parse("df132a03-5eb2-468b-8060-878babf1bd2a"), "Software 2", "Description 2", 150, 600, DateTime.Now.AddDays(45)),
            new SoftwareService(Guid.Parse("d3092888-dc80-4122-ae2b-4408af0e65b8"), "Software 3", "Description 4", 200, 300, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("c2e33655-d5da-4246-bf90-a779954b0408"), "Software 4", "Description 5", 50, 420, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("863aa171-6198-46fc-8e82-0a2a819eae02"), "Software 5", "Description 6", 300, 200, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("37481d87-82e0-4df7-9a12-8f91b739a268"), "Software 11", "Description 1", 100, 350, DateTime.Now.AddDays(30)),
            new SoftwareService(Guid.Parse("d2b9f023-1bda-4fa2-8caa-2ccdff20e35e"), "Software 22", "Description 2", 150, 600, DateTime.Now.AddDays(45)),
            new SoftwareService(Guid.Parse("4e73d673-b82f-4c72-9107-dd41af0839d0"), "Software 33", "Description 4", 200, 300, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("21413b84-5a2e-4188-bf15-9e2fc9b1228b"), "Software 44", "Description 5", 50, 420, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("1afbc65d-fc92-40e7-bfee-a323110b1c31"), "Software 55", "Description 6", 300, 200, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("cca9dfd2-bc76-4e76-ae44-c41089dc765a"), "Software 111", "Description 1", 100, 350, DateTime.Now.AddDays(30)),
            new SoftwareService(Guid.Parse("eebf408b-88f5-4d1e-a551-5dbb9fce2c07"), "Software 222", "Description 2", 150, 600, DateTime.Now.AddDays(45)),
            new SoftwareService(Guid.Parse("84a7b208-2b8d-4d2e-a147-126b925e261f"), "Software 333", "Description 4", 200, 300, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("f957ce97-95f4-4053-9ee6-9f09e71d6530"), "Software 444", "Description 5", 50, 420, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("cb67d589-a5cd-43af-b8ba-96cc0011456e"), "Software 555", "Description 6", 300, 200, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("c2364e1a-eb27-48ef-8610-bdb29bb65601"), "Software 6", "Description 1", 100, 350, DateTime.Now.AddDays(30)),
            new SoftwareService(Guid.Parse("4d96fe50-be1e-43d3-9f8c-ab43c0adc866"), "Software 7", "Description 2", 150, 600, DateTime.Now.AddDays(45)),
            new SoftwareService(Guid.Parse("74a2ac8d-5a3a-43cc-bb86-c1cf650492d7"), "Software 8", "Description 4", 200, 300, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("b8e5cff1-f048-4111-b187-f3a342ebed2c"), "Software 9", "Description 5", 50, 420, DateTime.Now.AddDays(60)),
            new SoftwareService(Guid.Parse("3983b4ab-011f-4d4c-89c8-27daf7beb5b4"), "Software 10", "Description 6", 300, 200, DateTime.Now.AddDays(60)),
            // Add more mock software services as needed
        };

        private static readonly List<PurchasedSoftware> PurchasedSoftwares = new List<PurchasedSoftware>();

        public static SoftwareServiceResponse GetSoftwareServices(int page = 0, int pageSize = 10)
        {
            var totalItems = SoftwareServices.Count;
            var items = SoftwareServices.Skip(page * pageSize).Take(pageSize).ToList();
            return new SoftwareServiceResponse(items, page, pageSize, totalItems);
        }

        public static OrderServiceResponse OrderSoftwareService(PursacheServiceRequest request)
        {
            var softwareService = SoftwareServices.FirstOrDefault(s => s.Id == request.SubscriptionId);
            if (softwareService == null)
            {
                return new OrderServiceResponse(false, "Software service not found", null, null);
            }

            if (request.Quantity > softwareService.AvailableLicenses && request.ValidToDate < softwareService.ValidToDate)
            {
                return new OrderServiceResponse(false, "License for this software is not valid for requested expiration date", null, null);
            }

            var pursachedSoftware = new PurchasedSoftware(softwareService.Id, softwareService.Name, request.Quantity, softwareService.ValidToDate, Guid.NewGuid(), DateTime.UtcNow);
            PurchasedSoftwares.Add(pursachedSoftware);

            return new OrderServiceResponse(true, "Order placed successfully", null, pursachedSoftware);
        }

        public static bool ChangeSoftwareServiceQuantity(Guid subscriptionId, int newQuantity)
        {
            var softwareService = SoftwareServices.FirstOrDefault(s => s.Id == subscriptionId);
            if (softwareService == null)
            {
                return false;
            }

            if (softwareService.AvailableLicenses > newQuantity)
            {
                return true;
            }

            return false;
        }

        public static bool CancelSoftware(Guid subscriptionId)
        {
            var purchasedSoftware = PurchasedSoftwares.FirstOrDefault(p => p.SubscriptionId == subscriptionId);
            if (purchasedSoftware == null)
            {
                return false;
            }

            PurchasedSoftwares.Remove(purchasedSoftware);
            return true;
        }

        public static ExtendSoftwareValidityResponse ExtendSoftwareValidity(Guid softwareId, DateTime newValidityDate)
        {
            var purchasedSoftware = PurchasedSoftwares.FirstOrDefault(p => p.SubscriptionId == softwareId);
            if (purchasedSoftware == null)
            {
                return new ExtendSoftwareValidityResponse(false, softwareId, Guid.NewGuid(), DateTime.Now);
            }

            var extendSoftwareValidityResponse = new ExtendSoftwareValidityResponse(true, softwareId, Guid.NewGuid(), DateTime.Now);
            return extendSoftwareValidityResponse;
        }
    }
}
