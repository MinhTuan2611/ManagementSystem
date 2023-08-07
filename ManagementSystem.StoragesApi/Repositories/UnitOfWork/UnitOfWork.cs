using ManagementSystem.AccountsApi.Repositories.GenericRepository;
using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ManagementSystem.AccountsApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private StoragesDbContext _context = null;
        private GenericRepository<Branch> _branchRepository;
        #endregion

        public UnitOfWork(StoragesDbContext context)
        {
            _context = context;
        }

        #region Public Repository Creation properties...



        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Branch> BranchRepository
        {
            get
            {
                if (this._branchRepository == null)
                    this._branchRepository = new GenericRepository<Branch>(_context);
                return _branchRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.Entries)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entity.GetType().Name, eve.State));
                    //foreach (var ve in eve.ValidationErrors)
                    //{
                    //    outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    //}
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }
        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
