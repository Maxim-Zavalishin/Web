﻿namespace BaikalNews.DAL.Interfeces;

public interface IBaseRepository<T>
{
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    IQueryable<T> Get();
}