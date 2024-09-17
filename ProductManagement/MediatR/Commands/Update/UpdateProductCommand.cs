﻿using MediatR;
using ProductManagement.DTOs.Read;
using ProductManagement.DTOs.Update;

namespace ProductManagement.MediatR.Commands.Update;

public record UpdateProductCommand(UpdateProductDTO dto) : BaseUpdateCommand<UpdateProductDTO>(dto);
