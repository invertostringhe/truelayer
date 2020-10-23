using Moq;
using System;
using TrueLayer.WebApi.Exceptions;
using TrueLayer.WebApi.Interfaces;
using TrueLayer.WebApi.Models.PokeApi;
using TrueLayer.WebApi.Repositories;
using TrueLayer.Tests.MockFactories;
using Xunit;

namespace TrueLayer.Tests.Repositories
{
    public class PokemonRepositoryTests
    {
        [Fact]
        public async void AssertNullReferenceExceptionIsThrownIfFlavorTextEntriesIsNull()
        {
            var mockedNetworkService = new Mock<INetworkService>();

            var name = "oddish";

            var mockObject = PokemonSpeciesResponseMockFactory.WithFlavorTextEntriesNull();

            mockedNetworkService.Setup(_ => _.GetData<PokemonSpeciesResponse>(It.IsAny<string>()))
                                .ReturnsAsync(mockObject);

            var repository = new PokemonRepository(mockedNetworkService.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () => await repository.GetByName(name));
        }

        [Fact]
        public async void AssertEmptyListExceptionIsThrownIfFlavorTextEntriesIsEmpty()
        {
            var mockedNetworkService = new Mock<INetworkService>();

            var name = "oddish";

            var mockObject = PokemonSpeciesResponseMockFactory.WithFlavorTextEntriesEmpty();

            mockedNetworkService.Setup(_ => _.GetData<PokemonSpeciesResponse>(It.IsAny<string>()))
                                .ReturnsAsync(mockObject);

            var repository = new PokemonRepository(mockedNetworkService.Object);

            await Assert.ThrowsAsync<EmptyListException>(async () => await repository.GetByName(name));
        }

        [Fact]
        public async void AssertNullReferenceExceptionIsThrownIfNoMatchingDescription()
        {
            var mockedNetworkService = new Mock<INetworkService>();

            var name = "oddish";

            var mockObject = PokemonSpeciesResponseMockFactory.WithNoMatchingFlavorTextEntries();

            mockedNetworkService.Setup(_ => _.GetData<PokemonSpeciesResponse>(It.IsAny<string>()))
                                .ReturnsAsync(mockObject);

            var repository = new PokemonRepository(mockedNetworkService.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () => await repository.GetByName(name));
        }
    }
}
