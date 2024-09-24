﻿using System.Security.Claims;
using MediatR;
using TechnoBit.DTOs;
using TechnoBit.Interfaces;
using TechnoBit.MediatR.Commands;
using TechnoBit.Repositories;

namespace TechnoBit.MediatR.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly SellerRepository _sellerRepository;

    public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService, IConfiguration configuration, SellerRepository sellerRepository)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _configuration = configuration;
        _sellerRepository = sellerRepository;
    }

    public async Task<TokenDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Geçersiz kullanıcı adı veya şifre.");
        }
        var seller = await _sellerRepository.GetSellerByIdAsync(user.Id);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : seller == null ? "User" : "Seller"),
        };
        
        var returnModel = new TokenDTO
        {
            AccessToken = _tokenService.GenerateAccessToken(claims),
            RefreshToken = _tokenService.GenerateRefreshToken()
        };

        user.RefreshToken = returnModel.RefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["JwtSettings:RefreshTokenExpirationDays"]));
        await _userRepository.UpdateModelAsync(user);

        return returnModel;
    }
}
