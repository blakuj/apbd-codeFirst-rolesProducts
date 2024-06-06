using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class ProductService
{
    private readonly ApplicationContext _context;

    public ProductService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task InsertProduct(InsertDTO insertDto)
    {
        using (var transaction =  await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var product = new Products()
                {
                    Name = insertDto.ProductName,
                    weight = insertDto.ProductWeight,
                    width = insertDto.ProductWidth,
                    height = insertDto.ProductHeight,
                    depth = insertDto.ProductDepth,
                };
                await _context.ProductsEnumerable.AddAsync(product);
                await _context.SaveChangesAsync();

                

                // foreach (var catID in insertDto.ProductCategories)
                // {
                //     var ProdCategories = new Products_Categories();
                //     ProdCategories.FK_Product = product.PK_Product;
                //     ProdCategories.FK_Category = catID;
                //     await _context.ProductsCategoriesEnumerable.AddAsync(ProdCategories);
                //     
                // }
                
                
                
                var prodCats = insertDto.ProductCategories.Select(categoryId => new Products_Categories
                {
                    FK_Product = product.PK_Product,
                    FK_Category = categoryId
                }).ToList();

          
                await _context.ProductsCategoriesEnumerable.AddRangeAsync(prodCats);
                await _context.SaveChangesAsync();


                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }


    public async Task<bool> DoesCategoryExist(InsertDTO insertDto)
    {
        foreach (var categoryID in insertDto.ProductCategories)
        {
            var category = await _context
                .ProductsCategoriesEnumerable
                .FindAsync(categoryID);

            if (category == null)
            {
                return false;
            }
        }

        return true;






    }
}