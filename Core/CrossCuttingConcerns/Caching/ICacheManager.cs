namespace Core.CrossCuttingConcerns.Caching;

public interface ICacheManager
{
    // cashleme mantığı key-value pairing şeklinde gider
    T Get<T>(string key);
    object Get(string key);
    void Add(string key, object value, int duration);
    bool IsAdd(string key);
    void Remove(string key);
    void RemoveByPattern(string pattern);
}