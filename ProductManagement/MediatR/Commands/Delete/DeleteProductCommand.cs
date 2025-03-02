﻿using MediatR;

namespace ProductManagement.MediatR.Commands.Delete;
public record DeleteProductCommand(int Id) : BaseDeleteCommand(Id);