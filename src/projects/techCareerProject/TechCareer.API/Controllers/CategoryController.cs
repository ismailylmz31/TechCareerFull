﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TechCareer.Models.Dtos.Category;
using TechCareer.Models.Entities;
using TechCareer.Service.Abstracts;

namespace TechCareer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Tüm Kategorileri Listeleme
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] Expression<Func<Category, bool>>? filter = null,
            [FromQuery] Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
            [FromQuery] bool include = false,
            [FromQuery] bool withDeleted = false,
            [FromQuery] bool enableTracking = true)
        {
            var categories = await _categoryService.GetListAsync(filter, orderBy, include, withDeleted, enableTracking);
            return Ok(categories);
        }

        // Sayfalama ile Listeleme
        [HttpGet("paginate")]
        public async Task<IActionResult> GetPaginated(
            [FromQuery] int index = 0,
            [FromQuery] int size = 10,
            [FromQuery] Expression<Func<Category, bool>>? filter = null,
            [FromQuery] Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
            [FromQuery] bool include = true,
            [FromQuery] bool withDeleted = false,
            [FromQuery] bool enableTracking = true)
        {
            var paginatedCategories = await _categoryService.GetPaginateAsync(filter, orderBy, include, index, size, withDeleted, enableTracking);
            return Ok(paginatedCategories);
        }

        // Belirli Bir Kategori Detayı
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var categoryDetails = await _categoryService.GetByIdAsync(id);
                return Ok(categoryDetails);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Category not found.");
            }
        }

        // Yeni Kategori Ekleme
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCategory = await _categoryService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        // Kategori Güncelleme
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCategory = await _categoryService.UpdateAsync(id, dto);
            return Ok(updatedCategory);
        }

        // Kategori Silme
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] bool permanent = false)
        {
            try
            {
                var result = await _categoryService.DeleteAsync(id, permanent);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Category not found.");
            }
        }
    }
}