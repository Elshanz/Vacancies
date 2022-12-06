using System;
using Microsoft.EntityFrameworkCore.Storage;
using Vacancies.Persistence.EF;

namespace Vacancies.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task RollbackAsync();
        Task CommitAsync();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
    public class UnitOfWork : IUnitOfWork
	{
        private readonly VacanciesDbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;

        public UnitOfWork(VacanciesDbContext context)
		{
            _context = context;
		}

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.RollbackAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.CommitAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // called via myClass.Dispose(). 
                    // OK to use any private object references
                    if (_transaction is not null) _transaction.Dispose();
                    _context.Dispose();
                }
                // Release unmanaged resources.
                // Set large fields to null.                
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

