﻿namespace ProductManagement.DTOs.Create;

public class CreateCategoryDTO
{
    public string Name { get; set; } = null!;

    public int? Subcategoryid { get; set; }

    public string? Description { get; set; }
}