﻿using ProductManagement.DTOs.Create;
using ProductManagement.DTOs.Read;
using ProductManagement.DTOs.Update;

namespace ProductManagement.Interfaces;

public interface IProductService : IService<CreateProductDTO, ProductDTO, UpdateProductDTO>;
