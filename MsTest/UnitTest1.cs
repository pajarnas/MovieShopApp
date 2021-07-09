using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieShopApp.API.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace MsTest
{
    [TestClass]
    public class MovieServiceUnitTest
	{
     // Add references first(ApplicationCore, Infrastructure)
	// sut represents System Under Test
		private MovieService _sut;
		
		private List<Movie> _fakeMovies;
		private readonly Mock<IMovieRepository> _mockMovieRepository;
		private readonly Mock<IEntityRepository<Genre>> _genreRepository;
		private readonly Mock<ICastRepository> _castRepository;
		private readonly Mock<IEntityRepository<Review>> _reviewRepository;
		private readonly Mock<IRelationRepository<MovieGenre>> _movieGenreRepository;
		private readonly Mock<IReviewService> _reviewService;
		private readonly IMapper _mapper;

		public MovieServiceUnitTest()
		{
			_mockMovieRepository = new Mock<IMovieRepository>();
/*			Mock<IMovieRepository> _mockMovieRepository;
		private readonly Mock<IEntityRepository<Genre>> _genreRepository;
		private readonly Mock<ICastRepository> _castRepository;
		private readonly Mock<IEntityRepository<Review>> _reviewRepository;
		private readonly Mock<IRelationRepository<MovieGenre>> _movieGenreRepository;
		private readonly Mock<IReviewService> _reviewService;*/

		_sut = new MovieService(_mockMovieRepository.Object);
		}

		[TestInitialize]
		// Triggered before every test case
		public void TestInitialize()
		{

			_fakeMovies = new List<Movie>{new Movie
{
Id = 1,
Title = "Test1",
Budget = 200000,
},
new Movie
{
	Id = 2,
	Title = "Test2",
	Budget = 3000000,
}
};

	

			// using Moq we are going to setup mock methods for IMovieRepository
			_mockMovieRepository.Setup(m =>
			m.GetHighestRevenueMovies()).ReturnsAsync(_fakeMovies);

			_mockMovieRepository.Setup(m =>m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
(int m) => _fakeMovies.FirstOrDefault(x => x.Id == 5));
		}



		[TestMethod]
		public void Test_For_TopRevenueMovies_From_FakeData()
		{
			_sut = new MovieService(_mockMovieRepository.Object);
		

		// Act
		var topMovies = _sut.GetTopRevenueMovies().Result;

			// Assert
			// you can do multiple asserts in one unit test method
			// when testing, even you have only one asserts fail, your whole test case fail

			// check topMovies is not null
			Assert.IsNotNull(topMovies);

			// check totalNumber of movies equal to 5
//			Assert.AreEqual(5, topMovies.Result.Count());

			// check the return type
			CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));
		}


	}
}
