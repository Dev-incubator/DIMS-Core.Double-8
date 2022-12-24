using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures;

public abstract class AbstractRepositoryFixture<TRepository> : IDisposable where TRepository : class
{
    public DimsCoreContext Context;
    public TRepository Repository => CreateRepository();

    protected AbstractRepositoryFixture()
    {
        var options = new DbContextOptionsBuilder<DimsCoreContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        Context = new DimsCoreContext(options);
        
        InitDB();
    }

    public abstract TRepository CreateRepository();
    protected abstract void InitDB();
    
    public void Dispose()
    {
        Context.Dispose();
    }
}