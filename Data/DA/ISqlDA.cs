namespace Data.Layer.DA
{
    public interface ISqlDA
    {
        Task<IEnumerable<T>> GetData<T, P>
            (string spName, P parameters,
            string connectionId = "constr");

        Task SaveData<T>
            (string spName, T parameters,
            string connectionId = "constr");
    }
}
