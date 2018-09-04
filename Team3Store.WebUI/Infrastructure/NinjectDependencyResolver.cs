using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;
using Team3Store.Domain.Concrete;
using System.Web.Mvc;

namespace Team3Store.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderStatusRepository>().To<OrderStatusRepository>();
            kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IReviewRepository>().To<ReviewRepository>();
            kernel.Bind<IVATRepository>().To<VATRepository>();
            kernel.Bind<IUserAddressRepository>().To<UserAddressRepository>();
            kernel.Bind<IUserPhoneRepository>().To<UserPhoneRepository>();
        }
    }
}