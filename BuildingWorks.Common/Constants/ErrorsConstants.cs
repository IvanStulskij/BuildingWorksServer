namespace BuildingWorks.Common.Constants;

public static class ErrorsConstants
{
    public static class Codes
    {
        public const int DuplicateDatabaseEntity = 23505;
    }

    public static class Messages
    {
        public const string ContractHasConditions = "Невозможно удалить договор, который уже имеет условия";
        public const string ContractIsSigned = "Невозможно обновить договор, который уже подписан";
        public const string BuildingObjectAlreadyHasProvider = "Поставщик уже добавлен к стоительному объекту";
        public const string ContractAlreadyHasProvider = "Поставщик уже добавлен к договору";
    }
}
