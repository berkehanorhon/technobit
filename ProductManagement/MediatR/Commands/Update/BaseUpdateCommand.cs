﻿using MediatR;
using ProductManagement.DTOs.Read;
using ProductManagement.DTOs.Update;

namespace ProductManagement.MediatR.Commands.Update;


public abstract record BaseUpdateCommand<TUpdateDTO>(TUpdateDTO dto) : IRequest<TUpdateDTO>;
