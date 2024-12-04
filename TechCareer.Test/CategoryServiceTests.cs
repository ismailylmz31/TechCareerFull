using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechCareer.Service.Concretes;
using TechCareer.DataAccess.Repositories.Abstracts;
using TechCareer.Models.Entities;
using TechCareer.Models.Dtos.Category;
using AutoMapper;
using TechCareer.Service.Rules;

namespace TechCareerFull.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<CategoryBusinessRules> _businessRulesMock;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapperMock = new Mock<IMapper>();
            _businessRulesMock = new Mock<CategoryBusinessRules>();
            _categoryService = new CategoryService(
                _categoryRepositoryMock.Object,
                _mapperMock.Object,
                _businessRulesMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnCategory_WhenCategoryExists()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Category 1" };
            var expectedDto = new CategoryResponseDto { Id = 1, Name = "Category 1" };

            // Mock directly returns a category for a specific id
            _categoryRepositoryMock
                .Setup(repo => repo.GetAsync(It.IsAny<int>(), true))
                .ReturnsAsync(category);

            _mapperMock.Setup(m => m.Map<CategoryResponseDto>(category)).Returns(expectedDto);

            // Act
            var result = await _categoryService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Category 1", result.Name);
        }

        [Fact]
        public async Task AddCategory_ShouldReturnCreatedCategory()
        {
            // Arrange
            var createDto = new CreateCategoryRequestDto { Name = "New Category" };
            var category = new Category { Id = 1, Name = "New Category" };
            var expectedDto = new CategoryResponseDto { Id = 1, Name = "New Category" };

            _mapperMock.Setup(m => m.Map<Category>(createDto)).Returns(category);
            _categoryRepositoryMock.Setup(repo => repo.AddAsync(category)).ReturnsAsync(category);
            _mapperMock.Setup(m => m.Map<CategoryResponseDto>(category)).Returns(expectedDto);

            // Act
            var result = await _categoryService.AddAsync(createDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("New Category", result.Name);
        }

        [Fact]
        public async Task UpdateCategory_ShouldReturnUpdatedCategory()
        {
            // Arrange
            var updateDto = new UpdateCategoryRequestDto { Id = 1, Name = "Updated Category" };
            var existingCategory = new Category { Id = 1, Name = "Old Category" };
            var updatedCategory = new Category { Id = 1, Name = "Updated Category" };
            var expectedDto = new CategoryResponseDto { Id = 1, Name = "Updated Category" };

            _categoryRepositoryMock
                .Setup(repo => repo.GetAsync(1, true))
                .ReturnsAsync(existingCategory);

            _mapperMock.Setup(m => m.Map(updateDto, existingCategory)).Returns(updatedCategory);

            _categoryRepositoryMock
                .Setup(repo => repo.UpdateAsync(updatedCategory))
                .ReturnsAsync(updatedCategory);

            _mapperMock.Setup(m => m.Map<CategoryResponseDto>(updatedCategory)).Returns(expectedDto);

            // Act
            var result = await _categoryService.UpdateAsync(1, updateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Updated Category", result.Name);
        }

        [Fact]
        public async Task DeleteCategory_ShouldThrowException_WhenCategoryDoesNotExist()
        {
            // Arrange
            _categoryRepositoryMock
                .Setup(repo => repo.GetAsync(99, false))
                .ReturnsAsync((Category)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _categoryService.DeleteAsync(99, true));
        }
    }
}
