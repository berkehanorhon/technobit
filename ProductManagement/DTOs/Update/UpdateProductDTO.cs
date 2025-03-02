﻿namespace ProductManagement.DTOs.Update;

public class UpdateProductDTO
{
    public int Id { get; set; }
    
    public int Categoryid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
