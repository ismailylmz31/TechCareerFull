using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TechCareer.Models.Entities;
using TechCareer.Models.Dtos.Events;
using TechCareer.Service.Concretes;
using TechCareer.DataAccess.Repositories.Abstracts;
using TechCareer.Service.Rules;

namespace TechCareerFull.Tests
{
    public class EventServiceTests
    {
        private readonly Mock<IEventRepository> _eventRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<EventBusinessRules> _businessRulesMock;
        private readonly EventService _eventService;

        public EventServiceTests()
        {
            _eventRepositoryMock = new Mock<IEventRepository>();
            _mapperMock = new Mock<IMapper>();
            _businessRulesMock = new Mock<EventBusinessRules>();

            _eventService = new EventService(
                _eventRepositoryMock.Object,
                _mapperMock.Object,
                _businessRulesMock.Object
            );
        }

        [Fact]
        public async Task GetAllEvents_ShouldReturnListOfEvents()
        {
            // Arrange
            var events = new List<Event>
            {
                new Event { Id = Guid.NewGuid(), Title = "Event 1", CategoryId = 1 },
                new Event { Id = Guid.NewGuid(), Title = "Event 2", CategoryId = 2 }
            };
            _eventRepositoryMock.Setup(repo => repo.GetListAsync(null, null, true, false, true))
                .ReturnsAsync(events);

            var expectedDtos = new List<EventResponseDto>
            {
                new EventResponseDto { Id = events[0].Id, Title = "Event 1", CategoryId = 1 },
                new EventResponseDto { Id = events[1].Id, Title = "Event 2", CategoryId = 2 }
            };
            _mapperMock.Setup(m => m.Map<List<EventResponseDto>>(events)).Returns(expectedDtos);

            // Act
            var result = await _eventService.GetListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Event 1", result[0].Title);
        }

        [Fact]
        public async Task GetEventById_ShouldReturnEvent_WhenEventExists()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var eventEntity = new Event { Id = eventId, Title = "Event 1", CategoryId = 1 };
            var expectedDto = new EventResponseDto { Id = eventId, Title = "Event 1", CategoryId = 1 };

            _eventRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Guid>(), true))
                .ReturnsAsync(eventEntity);
            _mapperMock.Setup(m => m.Map<EventResponseDto>(eventEntity)).Returns(expectedDto);

            // Act
            var result = await _eventService.GetByIdAsync(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(eventId, result.Id);
            Assert.Equal("Event 1", result.Title);
        }

        [Fact]
        public async Task AddEvent_ShouldReturnCreatedEvent()
        {
            // Arrange
            var createDto = new CreateEventRequestDto
            {
                Title = "New Event",
                Description = "Description",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(2),
                CategoryId = 1
            };
            var eventEntity = new Event
            {
                Id = Guid.NewGuid(),
                Title = "New Event",
                Description = "Description",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(2),
                CategoryId = 1
            };
            var expectedDto = new EventResponseDto
            {
                Id = eventEntity.Id,
                Title = "New Event",
                Description = "Description",
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                CategoryId = 1
            };

            _mapperMock.Setup(m => m.Map<Event>(createDto)).Returns(eventEntity);
            _eventRepositoryMock.Setup(repo => repo.AddAsync(eventEntity)).ReturnsAsync(eventEntity);
            _mapperMock.Setup(m => m.Map<EventResponseDto>(eventEntity)).Returns(expectedDto);

            // Act
            var result = await _eventService.AddAsync(createDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Event", result.Title);
        }
    }
}
