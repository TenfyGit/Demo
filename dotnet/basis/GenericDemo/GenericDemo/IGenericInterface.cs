namespace GenericDemo
{
    /// <summary>
    /// 一个接口来满足不同的具体类型的接口，做相同的事儿
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericInterface<T>
    {
        T GetT(T t);//泛型类型的返回值
    }
}
