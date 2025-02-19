namespace Core.Utilities.Results;

public class Result : IResult
{
    // başarı durumunu ve mesajı döndürmek için
    // Result contructor'ını overload ediyoruz bu sayede : 
    // Sadece başarılı durumunu(status) göndermek isteyen için 
    // veya Sadece mesaj göndermek isteyen veya başarılı durumunu(status) veya mesajı da göndermek isteyen için.   3 durum
    // referans nesne oluşturulduğunda-çalıştığında gelen paremetreye göre dinamik çalışsın
    public Result(bool success, string message) : this(message)
    {
        this.Success = success; 
    }
     
    // sadece Mesajı döndür
    public Result(string message)
    {
        this.Message = message; 
    }
    
    public bool Success { get; }
    public string Message { get; } 
}