using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        private static class CommonMessages<T>
        {
            private static readonly string itemName;

            static CommonMessages()
            {
                itemName = typeof(T).Name;
            }

            public static class SuccessMessages
            {
                public static readonly string ItemsListed = itemName + "s listed"; //daha generic bir yapı olması adına const kelimesinden vazgeçtim
                public static readonly string ItemFounded = itemName + " founded";
                public static readonly string ItemAdded = itemName + " added";
                public static readonly string ItemDeleted = itemName + " deleted";
                public static readonly string ItemUpdated = itemName + " updated";
            }

            public static class ErrorMessages
            {
                public static readonly string ItemsNotListed = itemName + "s could not listed";
                public static readonly string ItemNotFounded = itemName + " could not founded";
                public static readonly string ItemNotAdded = itemName + " could not added";
                public static readonly string ItemNotDeleted = itemName + " could not deleted";
                public static readonly string ItemNotUpdated = itemName + " could not updated";
            }
        }

        public static class ProductMessages
        {
            public static class SuccessMessages
            {
                public static readonly string ProductsListed = CommonMessages<Product>.SuccessMessages.ItemsListed;
                public static readonly string ProductFounded = CommonMessages<Product>.SuccessMessages.ItemFounded;
                public static readonly string ProductAdded = CommonMessages<Product>.SuccessMessages.ItemAdded;
                public static readonly string ProductDeleted = CommonMessages<Product>.SuccessMessages.ItemDeleted;
                public static readonly string ProductUpdated = CommonMessages<Product>.SuccessMessages.ItemUpdated;
            }
            public static class ErrorMessages
            {
                public static readonly string ProductsNotListed = CommonMessages<Product>.ErrorMessages.ItemsNotListed;
                public static readonly string ProductNotFounded = CommonMessages<Product>.ErrorMessages.ItemNotFounded;
                public static readonly string ProductNotAdded = CommonMessages<Product>.ErrorMessages.ItemNotAdded;
                public static readonly string ProductNotDeleted = CommonMessages<Product>.ErrorMessages.ItemNotDeleted;
                public static readonly string ProductNotUpdated = CommonMessages<Product>.ErrorMessages.ItemNotUpdated;

                public const string CategoryLimitExceeded =
                    "You can not add product because you exceeded category limit";
                public const string ProductNameInvalid = "Product name is invalid";
            }
        }

        public static class SystemMessages
        {
            public const string MaintenanceTime = "System is under maintenance";
        }
    }
}
