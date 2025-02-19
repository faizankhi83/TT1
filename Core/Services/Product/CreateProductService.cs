using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Product;
using Data.Repositories;

namespace Core.Services.Product
{
   // [AutoRegister]
   // public class CreateProductService : ICreateProductService
   // {
   //     private readonly IUpdateProductService _updateProductService;
   //     private readonly IIdObjectFactory<Products> _productFactory;
   //     private readonly IProductRepository _productRepository;

   //     public CreateProductService(IIdObjectFactory<Products> productFactory, IProductRepository productRepository, IUpdateProductService updateProductService)
   //     {
			//_productFactory = productFactory;
			//_productRepository = productRepository;
			//_updateProductService = updateProductService;
   //     }

   //     public Products Create(Guid id, string name, string email, int age, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
   //     {
   //         var product = _productFactory.Create(id);
			////_updateProductService.Update();
			////_updateProductService.Save(product);
			//return product;
   //     }
   // }
}