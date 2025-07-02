using System.Collections.Generic;
using System.Linq;
using BlazorNotes.Data.Models;
using BlazorNotes.Data;
using BlazorNotes.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class NoteServiceTests
{
    [Fact]
    public void GetAllNotes_ReturnsNotesFromDbContext()
    {
        var data = new List<Note>
        {
            new Note { Id = 1, Title = "Test 1", Text = "Text 1" },
            new Note { Id = 2, Title = "Test 2", Text = "Text 2" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Note>>();
        mockSet.As<IQueryable<Note>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Note>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Note>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Note>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<MyDbContext>(new DbContextOptions<MyDbContext>());
        mockContext.Setup(c => c.Notes).Returns(mockSet.Object);

        var mockFactory = new Mock<IDbContextFactory<MyDbContext>>();
        mockFactory.Setup(f => f.CreateDbContext()).Returns(mockContext.Object);

        var service = new NoteService(mockFactory.Object);

        var result = service.GetAll().ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("Test 1", result[0].Title);
        Assert.Equal("Text 1", result[0].Text);
        Assert.Equal("Test 2", result[1].Title);
        Assert.Equal("Text 2", result[1].Text);
    }
}