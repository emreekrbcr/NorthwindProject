using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        #region ForEntities
        IDataResult<List<Product>> GetAll();
        //IDataResult<List<Product>> GetAllByCategoryId(int id);
        //IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);

        ////IDataResult<Product> GetById(int id);

        IResult Add(Product product);
        ////IResult Delete(Product product);
        ////IResult Update(Product product);
        #endregion

        #region ForDtos
        //DataResult<List<ProductDetailDto>> GetProductDetails();
        #endregion
    }
}
