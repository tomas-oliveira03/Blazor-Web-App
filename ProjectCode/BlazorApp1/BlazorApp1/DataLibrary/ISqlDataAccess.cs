﻿

namespace DataLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionString);
        public Task<T> ExecuteScalarAsync<T>(string sql, object parameters, string connectionString);
    }
}