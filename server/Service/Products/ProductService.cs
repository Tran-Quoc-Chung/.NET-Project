using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
using server.middlewares;
using server.Models;
using server.Service.Products;
using Microsoft.EntityFrameworkCore.Query;
namespace server.Service;

public class ProductService : IProductService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Cloudinary _cloudinary;
    public ProductService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor, Cloudinary cloudinary)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
        _cloudinary = cloudinary;
    }

    public async Task<ServiceResponse<ProductResponseDTO>> GetProductByID(int id)
    {

        var serviceResponse = new ServiceResponse<ProductResponseDTO>();
        var dbProduct = await _dataContext.Products.Include(x => x.Brand).Include(x => x.CreatedBy).Include(x => x.DialShape).Include(x => x.DialSize).Include(x => x.Gender).Include(x => x.StatusActive).Include(x => x.StrapMaterial).Include(x => x.Tag).Include(x => x.WaterResistance).FirstOrDefaultAsync(x => x.ProductID == id);
        var images = await _dataContext.Images.Where(x => x.Product.ProductID == dbProduct.ProductID && x.ImagesType == "Product").ToListAsync();
        var imagesResult = images.Select(x => new Images
        {
            ImagesID = x.ImagesID,
            ImagesDesc = x.ImagesDesc,
            ImagesType = x.ImagesType,
            ImagesUrl = x.ImagesUrl
        }).ToList();
        if (dbProduct is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Product not exists";
            return serviceResponse;
        }
        var productResult = new GetProductDTO
        {
            ProductID = dbProduct.ProductID,
            ProductName = dbProduct.ProductName,
            Description = dbProduct.Description,
            SellPrice = dbProduct.SellPrice,
            OriginPrice = dbProduct.OriginPrice,
            TotalRating = dbProduct.TotalRating,
            Original = dbProduct.Brand.Original,
            BrandID = dbProduct.Brand.BrandID,
            DialShapeID = dbProduct.DialShape.DialShapeID,
            DialSizeID = dbProduct.DialSize.DialSizeID,
            TagID = dbProduct.Tag.TagID,
            GenderID = dbProduct.Gender.GenderID,
            Color = dbProduct.Color,
            StatusID = dbProduct.StatusActive.StatusID,
            WaterResistanceID = dbProduct.WaterResistance.WaterResistanceID,
            StrapMaterialID = dbProduct.StrapMaterial.StrapMaterialID,
            CreatedBy = dbProduct.CreatedBy.DisplayName,
            CreatedAt = dbProduct.CreatedAt.ToString("dd/MM/yyyy"),
            Import_count = dbProduct.import_count,
            Sold_count = dbProduct.sold_count
        };
        var response = new ProductResponseDTO
        {
            Product = productResult,
            ProductImage = imagesResult
        };

        serviceResponse.Data = response;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetAllProductDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetAllProductDTO>>();
        var dbProduct = await _dataContext.Products.Include(x => x.Brand).Include(x => x.CreatedBy).Include(x => x.DialShape).Include(x => x.DialSize).Include(x => x.Gender).Include(x => x.StatusActive).Include(x => x.StrapMaterial).Include(x => x.Tag).Include(x => x.WaterResistance).ToListAsync();
        var result = dbProduct.Select(x => new GetAllProductDTO
        {
            ProductID = x.ProductID,
            ProductName = x.ProductName,
            Price = x.SellPrice,
            TagName = x.Tag.TagName,
            GenderName = x.Gender.GenderName,
            CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = x.CreatedBy.DisplayName,
            Images = _dataContext.Images.Where(item => item.ImagesType == "Product").Where(item => item.Product.ProductID == x.ProductID).Select(item => item.ImagesUrl).FirstOrDefault() ?? ""

        }).ToList();
        serviceResponse.Data = result;

        return serviceResponse;
    }

    public async Task<ServiceResponse<ProductClientDTO>> GetAllFromClient(PaginationDTO paginationDTO)
    {
        var serviceResponse = new ServiceResponse<ProductClientDTO>();

        var query = _dataContext.Products
        .Include(x => x.Tag)
        .Include(x => x.Brand)
        .Include(x => x.Gender)
        .Include(x => x.StatusActive).AsQueryable();

        if (paginationDTO.Brand.HasValue)
        {
            query = query.Where(x => x.Brand.BrandID == paginationDTO.Brand);
        }
        if (paginationDTO.Gender.HasValue)
        {
            query = query.Where(x => x.Gender.GenderID == paginationDTO.Gender);
        }
        if (paginationDTO.StrapMaterial.HasValue)
        {
            query = query.Where(x => x.StrapMaterial.StrapMaterialID == paginationDTO.StrapMaterial);
        }
        if (paginationDTO.Sort.HasValue)
        {

            if(paginationDTO.Sort==4)
            {
                query = query.OrderBy(x=>x.SellPrice);
            }else if(paginationDTO.Sort==3)
            {
                query = query.OrderByDescending(x=>x.CreatedAt);
            }
            else if(paginationDTO.Sort==1)
            {
                query = query.OrderByDescending(x => x.sold_count);
            }else if(paginationDTO.Sort==5)
            {
                query = query.OrderByDescending(x=>x.SellPrice);
            }
        }
        if(paginationDTO.Price.HasValue)
        {
            if(paginationDTO.Price==1)
            {
                query = query.Where(x => x.SellPrice >= 15000000);
            }
            else if(paginationDTO.Price==2)
            {
                query = query.Where(x => x.SellPrice <= 15000000 && x.SellPrice >= 10000000 );
            }
            else if(paginationDTO.Price==3)
            {
                query = query.Where(x => x.SellPrice <= 10000000 && x.SellPrice >= 5000000 );
            }
            else if(paginationDTO.Price==4)
            {
                query = query.Where(x => x.SellPrice <= 5000000  );
            }
        }
        // int page = paginationDTO?.Page ?? 1;
        // int limitNumber = page * 8;

        // var dbProduct = await _dataContext.Products.Include(x => x.Brand).Include(x => x.Gender).Include(x => x.StatusActive).Include(x => x.Tag).Take(limitNumber).ToListAsync();
        int page = paginationDTO.Page ?? 1;
        int limitNumber = page * 8; 
        var dbProduct = await query.Take(paginationDTO.Limit ?? limitNumber).ToListAsync();
        
        int remainProductCount = await query
                .Skip(limitNumber)
                .CountAsync();

        var product = dbProduct.Select(x => new GetAllProductDTO
        {
            ProductID = x.ProductID,
            ProductName = x.ProductName,
            Price = x.SellPrice,
            TagName = x.Tag.TagName,
            GenderName = x.Gender.GenderName,
            CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
            Images = _dataContext.Images.Where(item => item.ImagesType == "Product").Where(item => item.Product.ProductID == x.ProductID).Select(item => item.ImagesUrl).FirstOrDefault() ?? ""

        }).ToList();

        var result = new ProductClientDTO
        {
            ProductList = product,
            Page = page,
            RemainProduct = remainProductCount
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    
    public async Task<ServiceResponse<List<AddProductDTO>>> Create(AddProductDTO addProductDTO, List<IFormFile> imageFile)
    {
        var serviceResponse = new ServiceResponse<List<AddProductDTO>>();
        try
        {
            //check thông số
            var brandID = await _dataContext.Brands.SingleOrDefaultAsync(x => x.BrandID == addProductDTO.BrandID);
            var dialSizeID = await _dataContext.DialSizes.SingleOrDefaultAsync(x => x.DialSizeID == addProductDTO.DialSizeID);
            var strapMaterialID = await _dataContext.StrapMaterials.SingleOrDefaultAsync(x => x.StrapMaterialID == addProductDTO.StrapMaterialID);
            var gender = await _dataContext.Genders.SingleOrDefaultAsync(x => x.GenderID == addProductDTO.GenderID);
            var dialShape = await _dataContext.DialShapes.SingleOrDefaultAsync(x => x.DialShapeID == addProductDTO.DialShapeID);
            var statusActive = await _dataContext.SystemStatus.SingleOrDefaultAsync(x => x.StatusID == addProductDTO.StatusID);
            var tag = await _dataContext.Tags.SingleOrDefaultAsync(x => x.TagID == addProductDTO.TagID);
            var waterResistance = await _dataContext.WaterResistances.SingleOrDefaultAsync(x => x.WaterResistanceID == addProductDTO.WaterResistanceID);
            //check token expire 
            var token = _httpContextAccessor.HttpContext.Request.Cookies["user"];
            var userID = _authJwtToken.ValidateToken(token);
            var userInfo = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID.UserID);
            if (userInfo == null)
            {
                serviceResponse.Message = "user not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (brandID == null || dialSizeID == null || strapMaterialID == null || gender == null || dialShape == null || tag == null || waterResistance == null || statusActive == null || userInfo == null)
            {
                serviceResponse.Message = "Dữ liệu không hợp lệ";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            var images = await UploadImages(imageFile);

            var Product = _mapper.Map<Product>(addProductDTO);
            Product.Brand = brandID;
            Product.DialShape = dialShape;
            Product.DialSize = dialSizeID;
            Product.Gender = gender;
            Product.StrapMaterial = strapMaterialID;
            Product.WaterResistance = waterResistance;
            Product.StatusActive = statusActive;
            Product.Tag = tag;
            Product.CreatedBy = userInfo;
            Product.CreatedAt = DateTime.Now;
            _dataContext.Products.Add(Product);

            await _dataContext.SaveChangesAsync();
            Console.WriteLine("count" + images.Count);
            var check = await ImageService(images, Product);

            serviceResponse.Data = await _dataContext.Products.Select(x => _mapper.Map<AddProductDTO>(x)).ToListAsync();
            serviceResponse.Success = true;
        }
        catch (System.Exception ex)
        {
            serviceResponse.Message = "error:" + ex.Message;
            serviceResponse.Success = false;

        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AddProductDTO>> Update(AddProductDTO addProductDTO, List<IFormFile> newImages, List<int> newImagesID)
    {
        var serviceResponse = new ServiceResponse<AddProductDTO>();
        try
        {
            var Product = await _dataContext.Products.FirstOrDefaultAsync(c => c.ProductID == addProductDTO.ProductID);
            if (Product is null)
                throw new Exception("Product not found");

            var brandID = await _dataContext.Brands.SingleOrDefaultAsync(x => x.BrandID == addProductDTO.BrandID);
            var dialSizeID = await _dataContext.DialSizes.SingleOrDefaultAsync(x => x.DialSizeID == addProductDTO.DialSizeID);
            var strapMaterialID = await _dataContext.StrapMaterials.SingleOrDefaultAsync(x => x.StrapMaterialID == addProductDTO.StrapMaterialID);
            var gender = await _dataContext.Genders.SingleOrDefaultAsync(x => x.GenderID == addProductDTO.GenderID);
            var dialShape = await _dataContext.DialShapes.SingleOrDefaultAsync(x => x.DialShapeID == addProductDTO.DialShapeID);
            var statusActive = await _dataContext.SystemStatus.SingleOrDefaultAsync(x => x.StatusID == addProductDTO.StatusID);
            var tag = await _dataContext.Tags.SingleOrDefaultAsync(x => x.TagID == addProductDTO.TagID);
            var waterResistance = await _dataContext.WaterResistances.SingleOrDefaultAsync(x => x.WaterResistanceID == addProductDTO.WaterResistanceID);

            if (brandID == null || dialSizeID == null || strapMaterialID == null || gender == null || dialShape == null || tag == null || waterResistance == null || statusActive == null)
            {
                serviceResponse.Message = "Dữ liệu không hợp lệ";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            Product.ProductName = addProductDTO.ProductName;
            Product.SellPrice = addProductDTO.SellPrice;
            Product.OriginPrice = addProductDTO.OriginPrice;
            Product.Description = addProductDTO.Description;
            Product.Brand = brandID;
            Product.DialShape = dialShape;
            Product.DialSize = dialSizeID;
            Product.Gender = gender;
            Product.StrapMaterial = strapMaterialID;
            Product.WaterResistance = waterResistance;
            Product.StatusActive = statusActive;
            Product.Tag = tag;

            //update images table
            var imagesList = await _dataContext.Images.Where(x => x.Product.ProductID == Product.ProductID).ToListAsync();
            var recordsToRemove = imagesList.Where(image => !newImagesID.Contains(image.ImagesID) && image.ImagesType == "Product").ToList();

            _dataContext.Images.RemoveRange(recordsToRemove);
            if (newImages.Count > 0)
            {
                var images = await UploadImages(newImages);
                await ImageService(images, Product);
            };

            await _dataContext.SaveChangesAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = _mapper.Map<AddProductDTO>(Product);
            serviceResponse.Message = "Update successfully";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Product>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<Product>>();
        try
        {
            var Product = await _dataContext.Products.FirstOrDefaultAsync(c => c.ProductID == id);
            var images = await _dataContext.Images.Where(x => x.Product.ProductID == Product.ProductID).ToListAsync();
            if (Product is null)
                throw new Exception("ID product not found");
            _dataContext.Products.Remove(Product);
            _dataContext.Images.RemoveRange(images);
            await _dataContext.SaveChangesAsync();
            //serviceResponse.Data = await _dataContext.Products.Include(x=>x.Brand).Include(x=>x.CreatedBy).Include(x=>x.DialShape).Include(x=>x.DialSize).Include(x=>x.Gender).Include(x=>x.StatusActive).Include(x=>x.StrapMaterial).Include(x=>x.Tag).Include(x=>x.WaterResistance).Select(x => _mapper.Map<Product>(x)).ToListAsync();
            serviceResponse.Message = "Delete product successfully";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Detete failed";
        }
        return serviceResponse;
    }
    public async Task<List<ImagesDTO>> UploadImages(List<IFormFile> files)
    {
        var imagesInfoList = new List<ImagesDTO>();


        foreach (var file in files)
        {
            Console.WriteLine("fomr file" + file.FileName);

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };
                var uploadResult = _cloudinary.Upload(uploadParams);
                var imageInfo = new ImagesDTO
                {
                    URL = uploadResult.SecureUrl.ToString(),
                    Description = uploadResult.PublicId.ToString()
                };
                imagesInfoList.Add(imageInfo);
            }
            else
            {
                Console.WriteLine("Not found");
            }

        }
        return imagesInfoList;
    }

    public async Task<ServiceResponse<List<ImagesDTO>>> ImageService(List<ImagesDTO> images, Product product)
    {
        var serviceResponse = new ServiceResponse<List<ImagesDTO>>();
        var imagesEntities = new List<Images>();

        try
        {
            foreach (var item in images)
            {
                var image = new Images
                {
                    ImagesUrl = item.URL,
                    ImagesDesc = item.Description,
                    ImagesType = "Product",
                    Product = product
                };
                imagesEntities.Add(image);
                Console.WriteLine("Image added to the list");
            }

            Console.WriteLine($"Adding {imagesEntities.Count} images to the database");
            _dataContext.Images.AddRange(imagesEntities);
            await _dataContext.SaveChangesAsync();
            Console.WriteLine($"Successfully added {imagesEntities.Count} images to the database");

            serviceResponse.Data = images;
            serviceResponse.Success = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding images to the database: {ex.Message}");
            serviceResponse.Success = false;
            // Log the error or handle it accordingly
        }

        return serviceResponse;
    }
}