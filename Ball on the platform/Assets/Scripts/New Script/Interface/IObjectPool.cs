namespace NewScript
{
    public interface IObjectPool<T>
    {
        T GetObject(); // Получить объект из пула
        void ReturnObject(T obj); // Вернуть объект в пул
    }
}