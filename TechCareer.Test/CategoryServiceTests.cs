using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechCareer.DataAccess.Repositories.Abstracts;
using TechCareer.Models.Dtos.Category;
using TechCareer.Models.Entities;
using TechCareer.Service.Abstracts;
using TechCareer.Service.Concretes;
using TechCareer.Service.Rules;
using Xunit;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<CategoryBusinessRules> _mockBusinessRules;
    private readonly ICategoryService _service;

    public CategoryServiceTests()
    {
        _mockRepository = new Mock<ICategoryRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockBusinessRules = new Mock<CategoryBusinessRules>();
        _service = new CategoryService(_mockRepository.Object, _mockMapper.Object, _mockBusinessRules.Object);
    }

    [Fact]
    public async Task AddAsync_Should_Add_Category_Successfully()
    {
        // Arrange
        var createDto = new CreateCategoryRequestDto("Test Category");

        var categoryEntity = new Category { Id = 1, Name = createDto.Name };

        _mockBusinessRules
            .Setup(r => r.CategoryNameMustBeUnique(createDto.Name))
            .Returns(Task.CompletedTask);

        _mockRepository
            .Setup(r => r.AddAsync(It.IsAny<Category>()))
            .ReturnsAsync(categoryEntity);

        _mockMapper
            .Setup(m => m.Map<Category>(createDto))
            .Returns(categoryEntity);

        _mockMapper
            .Setup(m => m.Map<CategoryResponseDto>(categoryEntity))
            .Returns(new CategoryResponseDto(categoryEntity.Id, categoryEntity.Name));

        // Act
        var result = await _service.AddAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoryEntity.Id, result.Id);
        Assert.Equal(categoryEntity.Name, result.name);
        _mockRepository.Verify(r => r.AddAsync(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_Should_Delete_Category_Successfully()
    {
        // Arrange
        var id = 1;
        var categoryEntity = new Category { Id = id, Name = "Test Category" };

        _mockBusinessRules
            .Setup(r => r.CategoryMustExist(id))
            .ReturnsAsync(categoryEntity);

        _mockRepository
            .Setup(r => r.DeleteAsync(categoryEntity, It.IsAny<bool>()))
            .Returns((Task<Category>)Task.CompletedTask);

        // Act
        var result = await _service.DeleteAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Category successfully deleted.", result);
        _mockRepository.Verify(r => r.DeleteAsync(categoryEntity, It.IsAny<bool>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Category_Successfully()
    {
        // Arrange
        var id = 1;
        var updateDto = new UpdateCategoryRequestDto(id, "Updated Category");

        var categoryEntity = new Category { Id = id, Name = "Old Category" };

        _mockBusinessRules
            .Setup(r => r.CategoryMustExist(id))
            .ReturnsAsync(categoryEntity);

        _mockMapper
            .Setup(m => m.Map(updateDto, categoryEntity))
            .Callback(() => categoryEntity.Name = updateDto.name);

        _mockRepository
            .Setup(r => r.UpdateAsync(categoryEntity))
            .ReturnsAsync(categoryEntity);

        _mockMapper
            .Setup(m => m.Map<CategoryResponseDto>(categoryEntity))
            .Returns(new CategoryResponseDto(categoryEntity.Id, categoryEntity.Name));

        // Act
        var result = await _service.UpdateAsync(id, updateDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updateDto.name, result.name);
        _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Category()
    {
        // Arrange
        var id = 1;
        var categoryEntity = new Category { Id = id, Name = "Test Category" };

        _mockBusinessRules
            .Setup(r => r.CategoryMustExist(id))
            .ReturnsAsync(categoryEntity);

        _mockMapper
            .Setup(m => m.Map<CategoryResponseDto>(categoryEntity))
            .Returns(new CategoryResponseDto(categoryEntity.Id, categoryEntity.Name));

        // Act
        var result = await _service.GetByIdAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoryEntity.Id, result.Id);
        Assert.Equal(categoryEntity.Name, result.name);
    }
}
