namespace Core.Utilities.Results;

public class Result : IResult
{
    // başarı durumunu ve mesajı döndürmek için
    // Result contructor'ını overload ediyoruz bu sayede : 
    // Sadece başarılı durumunu(status) göndermek isteyen için 
    // veya Sadece mesaj göndermek isteyen veya başarılı durumunu(status) veya mesajı da göndermek isteyen için. 3 durum 
    // referans nesne oluşturulduğunda-çalıştığında gelen paremetreye göre dinamik çalışsın
    // burda eğer iki parametre gönderilirse, this diyerek tek parametreli constructor'ın da çalışmasını sağlıyoruz
    //  success i aşağıda set ediyoruz : set metodu verilmeyen proplar constructor ile set edilebilir
    //
    public Result(bool success, string message) : this(success) 
    {
        this.Message = message; 
    }
     
    // sadece Mesajı döndür
    public Result(bool success)
    {
        this.Success = success; 
    }
    
    public bool Success { get; }
    public string Message { get; } 
}