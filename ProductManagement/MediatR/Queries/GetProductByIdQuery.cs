﻿using MediatR;
using ProductManagement.DTOs.Read;

namespace ProductManagement.MediatR.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductDTO>;
