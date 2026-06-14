using System.Collections.Generic;

public interface IAssetService<T>
{
    public T Load(string path);
    public T LoadAsync(string path);
    public List<T> LoadAll(string path);
    public List<T> LoadAllAsync(string path);
}
