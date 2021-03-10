using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            var logicsControlResult = BusinessRulesEngine.Run<List<Product>>(CheckSystemMaintenanceTime());

            if (logicsControlResult.Success.Equals(false))
            {
                return logicsControlResult;
            }

            var executionResult = BusinessOperationExecuteEngine.Run(() => _productDal.GetAll(),
             Messages.ProductMessages.SuccessMessages.ProductsListed,
             Messages.ProductMessages.ErrorMessages.ProductsNotListed);

            return executionResult; //Eğer iş kurallarından geçerse de işlem çalıştırılmaya çalışacak ve herhangi bir hata oluşmazsa sonucu döndürecek 
        }

        //public IDataResult<Product> GetById(int id)
        //{
        //    return CheckDataResult(() => _productDal.Get(p => p.ProductId.Equals(id)),
        //        Messages.ProductMessages.SuccessMessages.ProductFounded, Messages.ProductMessages.ErrorMessages.ProductNotFounded);
        //}

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Business kodları verinin uygunluğuyla ilgili kontrollerin yapılacağı kodlardır.
            //Örneğin bir müşteri bankadan kredi alacağı zaman krediye uygun olup olmadığının kontrolü yapılacağı yer burasıdır.

            //Validation verinin integrity yani yapısal olarak uygunluğunun kontrolünün yapılacağı kodlardır.
            //Örneğin Müşterinin adı 2 ile 10 karakter arası olsun, telefon numarasında sadece sayısal karakterler olsun gibi kontroller burada yapılır.

            //Validation işlemindeki kodlar sadece Product'a özgü olmayabilir. Hepsinde ortak kullanılacak kodlar olabilir. Dolayısıyla tekrara düşmemek ve daha nesnel bir kod yazmak için bu işlemler Fluent Validation ile yapılacaktır. Bunları bazen Entities katmanında prop'ların üzerine attribute vererek yani Data Annotation kullanarak yapanlar olabilir. Bu yanlış bir kullanımdır. SOLID'in S harfine aykırıdır. Entities'in sorumluluğu sadece veri şablonu olarak kullanılmaktadır. Örneğin TcNo'ya Required ekleyelim. Sistem sadece Türk vatandaşlara yönelik düşünüldüğü için başlarda problem olmayabilir, ancak ileride yabancı uyruklu kişiler sisteme ekleneceği zaman onlar için TcNo'ya gerek olmadığı için düzeltmesi zor olacaktır ve kodlar zamanla spagettileşmeye başlayacaktır.

            //Business altında ValidationRules oluşturulacak. FluentValidation alternatifi olan bir teknoloji old. için o da klasörlenecek. Sonrasında ilk başta Product için doğrulama kodu yazılacağı için ProductValidator.cs oluştur.

            var logicControlResult = BusinessRulesEngine.Run(CheckCategoryLimitExceeded(product.CategoryId),CheckSystemMaintenanceTime());

            if (logicControlResult.Success.Equals(false))
            {
                return logicControlResult;
            }

            var executionResult = BusinessOperationExecuteEngine.Run(() => _productDal.Add(product),
                Messages.ProductMessages.SuccessMessages.ProductAdded,
                Messages.ProductMessages.ErrorMessages.ProductNotAdded);

            return executionResult;

        }

        //public IResult Delete(Product product)
        //{
        //    return CheckResult(() => _productDal.Delete(product),
        //        Messages.ProductMessages.SuccessMessages.ProductDeleted,
        //        Messages.ProductMessages.ErrorMessages.ProductNotDeleted);
        //}

        //public IResult Update(Product product)
        //{
        //    return CheckResult(() => _productDal.Update(product),
        //        Messages.ProductMessages.SuccessMessages.ProductUpdated,
        //        Messages.ProductMessages.ErrorMessages.ProductNotUpdated);
        //}

        #region BusinessRules

        private IResult CheckSystemMaintenanceTime()
        {
            if (DateTime.Now.Hour == 20) //deneme amaçlı API'de bakım hata mesajı görmek için
            {
                return new ErrorResult(Messages.SystemMessages.MaintenanceTime);
            }

            return new SuccessResult();
        }

        private IResult CheckCategoryLimitExceeded(int categoryId)
        {
            int result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.ProductMessages.ErrorMessages.CategoryLimitExceeded);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
