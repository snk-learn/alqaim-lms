// An abstraction for persistance
using AlQaim.Lms.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks; // Add this line

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
   
}