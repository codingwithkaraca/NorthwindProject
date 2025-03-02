using Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    public static string CategoryLimitExceeded = "Kategori sayısı 15'i geçtiği için yeni ürün eklenemez";
    public static string ProductCountOfCategoryError = "Bu kategori türünde en fazla 10 ürün olabilir";
    public static string ProductNameAlreadyExists = "Aynı isimde bir ürün var, farklı bir isim seçiniz";
    public static string ProductAdded = "Ürün Eklendi";
    public static string ProductUpdated = "Ürün güncellendi";
    public static string ProductNameInvalid = "Ürün ismi geçersiz";
    public static string MaintenanceTime = "Sitem bakım zamanı";
    public static string ProductsListed = "Ürünler listelendi";
}