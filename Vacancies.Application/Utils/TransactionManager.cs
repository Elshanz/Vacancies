using System;
using Vacancies.Persistence;

namespace Vacancies.Application.Utils
{
    public interface ITransactionManager
    {
        Task HandleTransaction<TInput>(Func<TInput, Task> action, TInput input);
        Task<T> HandleTransaction<T>(Func<Task<T>> func);
        Task<T> HandleTransaction<T, TInput>(Func<TInput, Task<T>> func, TInput input);
        Task<T> HandleTransaction<T, TInput1, TInput2>(Func<TInput1, TInput2, Task<T>> func, TInput1 input1, TInput2 input2);
    }
    public class TransactionManager : ITransactionManager
	{
        private readonly IUnitOfWork _unitofwork;
		public TransactionManager(IUnitOfWork unitOfWork)
		{
            _unitofwork = unitOfWork;
		}

        public async Task HandleTransaction<TInput>(Func<TInput, Task> action, TInput input)
        {
            try
            {
                await _unitofwork.BeginTransactionAsync();
                await action(input);
                await _unitofwork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitofwork.RollbackAsync();
                throw;
            }
            finally
            {
                _unitofwork.Dispose();
            }
        }

        public async Task<T> HandleTransaction<T>(Func<Task<T>> func)
        {
            try
            {
                await _unitofwork.BeginTransactionAsync();
                var result = await func();
                await _unitofwork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                _unitofwork.RollbackAsync();
                throw;
            }
            finally
            {
                _unitofwork.Dispose();
            }
        }

        public async Task<T> HandleTransaction<T, TInput>(Func<TInput, Task<T>> func, TInput input)
        {
            try
            {
                await _unitofwork.BeginTransactionAsync();
                var result = await func(input);
                await _unitofwork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                _unitofwork.RollbackAsync();
                throw;
            }
            finally
            {
                _unitofwork.Dispose();
            }
        }

        public async Task<T> HandleTransaction<T, TInput1, TInput2>(Func<TInput1, TInput2, Task<T>> func, TInput1 input1, TInput2 input2)
        {
            try
            {
                await _unitofwork.BeginTransactionAsync();
                var result = await func(input1, input2);
                await _unitofwork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                _unitofwork.RollbackAsync();
                throw;
            }
            finally
            {
                _unitofwork.Dispose();
            }
        }
    }
}

