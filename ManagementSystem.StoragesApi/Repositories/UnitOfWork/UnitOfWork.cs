using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ManagementSystem.StoragesApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private StoragesDbContext _context = null;
        private GenericRepository<Branch> _branchRepository;
        private GenericRepository<Storage> _storageRepository;
        private GenericRepository<Unit> _unitRepository;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<ProductStorage> _productStorageRepository;
        private GenericRepository<ProductUnit> _productUnitRepository;
        private GenericRepository<Supplier> _supplierRepository;
        private GenericRepository<RequestSample> _requestSampleRepository;
        private GenericRepository<Request> _requestRepository;
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Bill> _billRepository;
        private GenericRepository<BillDetail> _billDetailRepository;
        private GenericRepository<PaymentMethod> _paymentMethodRepository;
        private GenericRepository<BillPayment> _billPaymentRepository;
        private GenericRepository<AnimalPartRefCode> _animalPartRefCodeRepository;
        private GenericRepository<ProductSupplier> _productSupplierRepository;
        private GenericRepository<ProductUnitBranch> _productUnitBranchRepository;
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
                if (_branchRepository == null)
                    _branchRepository = new GenericRepository<Branch>(_context);
                return _branchRepository;
            }
        }

        public GenericRepository<Storage> StorageRepository
        {
            get
            {
                if (_storageRepository == null)
                    _storageRepository = new GenericRepository<Storage>(_context);
                return _storageRepository;
            }
        }
        public GenericRepository<Unit> UnitRepository
        {
            get
            {
                if (_unitRepository == null)
                    _unitRepository = new GenericRepository<Unit>(_context);
                return _unitRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new GenericRepository<Category>(_context);
                return _categoryRepository;
            }
        }
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_context);
                return _productRepository;
            }
        }
        public GenericRepository<ProductStorage> ProductStorageRepository
        {
            get
            {
                if (_productStorageRepository == null)
                    _productStorageRepository = new GenericRepository<ProductStorage>(_context);
                return _productStorageRepository;
            }
        }
        public GenericRepository<ProductUnit> ProductUnitRepository
        {
            get
            {
                if (_productUnitRepository == null)
                    _productUnitRepository = new GenericRepository<ProductUnit>(_context);
                return _productUnitRepository;
            }
        }

        public GenericRepository<Supplier> SupplierRepository
        {
            get
            {
                if (_supplierRepository == null)
                    _supplierRepository = new GenericRepository<Supplier>(_context);
                return _supplierRepository;
            }
        }
        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new GenericRepository<Customer>(_context);
                return _customerRepository;
            }
        }
        public GenericRepository<Bill> BillRepository
        {
            get
            {
                if (_billRepository == null)
                    _billRepository = new GenericRepository<Bill>(_context);
                return _billRepository;
            }
        }
        public GenericRepository<BillDetail> BillDetailRepository
        {
            get
            {
                if (_billDetailRepository == null)
                    _billDetailRepository = new GenericRepository<BillDetail>(_context);
                return _billDetailRepository;
            }
        }
        public GenericRepository<PaymentMethod> PaymentMethodRepository
        {
            get
            {
                if (_paymentMethodRepository == null)
                    _paymentMethodRepository = new GenericRepository<PaymentMethod>(_context);
                return _paymentMethodRepository;
            }
        }
        public GenericRepository<BillPayment> BillPaymentRepository
        {
            get
            {
                if (_billPaymentRepository == null)
                    _billPaymentRepository = new GenericRepository<BillPayment>(_context);
                return _billPaymentRepository;
            }
        }

        public GenericRepository<RequestSample> RequestSampleRepository
        {
            get
            {
                if (_requestSampleRepository == null)
                    _requestSampleRepository = new GenericRepository<RequestSample>(_context);
                return _requestSampleRepository;
            }
        }

        public GenericRepository<Request> RequestRepository
        {
            get
            {
                if (_requestRepository == null)
                    _requestRepository = new GenericRepository<Request>(_context);
                return _requestRepository;
            }
        }

        public GenericRepository<AnimalPartRefCode> AnimalPartRefCodeRepository
        {
            get
            {
                if (_animalPartRefCodeRepository == null)
                    _animalPartRefCodeRepository = new GenericRepository<AnimalPartRefCode>(_context);
                return _animalPartRefCodeRepository;
            }
        }
        public GenericRepository<ProductSupplier> ProductSupplierRepository
        {
            get
            {
                if (_productSupplierRepository == null)
                    _productSupplierRepository = new GenericRepository<ProductSupplier>(_context);
                return _productSupplierRepository;
            }
        }

        public GenericRepository<ProductUnitBranch> ProductUnitBranchRepository
        {
            get
            {
                if (_productUnitBranchRepository == null)
                    _productUnitBranchRepository = new GenericRepository<ProductUnitBranch>(_context);
                return _productUnitBranchRepository;
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
                File.AppendAllLines(@"C:\errors.txt", outputLines);

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
            if (!disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            disposed = true;
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
