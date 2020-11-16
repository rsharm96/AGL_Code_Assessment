using AGL.Assessment.BusinessServices.Interfaces;
using AGL.Assessment.Entities;
using AGL.Assessment.ExternalServices.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AGL.Assessment.BusinessServices.UnitTests
{
    [TestClass]
    public class BL_PetListByOnerGender
    {
        private List<PetOwner> _petOwners;
        private Mock<IPetOwnerServices<PetOwner>> _petOwnerServices;
        private Mock<IHttpHelper<PetOwner>> _httpServices;
        private IPetListByOwnerGender _petListByOwnerGender;

        [TestInitialize]
        public void Setup()
        {
            _petOwnerServices = new Mock<IPetOwnerServices<PetOwner>>();
            _httpServices = new Mock<IHttpHelper<PetOwner>>();
            _petListByOwnerGender = new PetListByOwnerGender(_petOwnerServices.Object, _httpServices.Object);

            _petOwners = new List<PetOwner>()
            {
                new PetOwner
                {
                    Name= "Bob",
                    Age =23,
                    Gender = "Male",
                    Pets = new List<Pet>() { new Pet { Name = "Garfield", Type="CAT" } , new Pet { Name = "Fido", Type = "Dog" }  }
                },
                new PetOwner
                {
                    Name= "Jennifer",
                    Age =18,
                    Gender = "Female",
                    Pets = new List<Pet>() { new Pet { Name = "Garfield", Type="CAT" }  }
                },
                new PetOwner
                {
                    Name= "Fred",
                    Age =40,
                    Gender = "Male",
                    Pets = new List<Pet>() { new Pet { Name = "Garfield", Type = "CAT" }, new Pet { Name = "Tom", Type="CAT" } , new Pet { Name = "Max", Type = "CAT" }, new Pet { Name = "Jim", Type = "CAT" }, new Pet { Name = "Sam", Type = "Dog" }  }
                }
            };

            _petOwnerServices.Setup(x => x.GetPetOwners()).Returns(_petOwners);
        }
        
        /// <summary>
        /// Test the Count of Pets by Owner gender
        /// </summary>
        [TestMethod]
        public void BL_GetPetListbyOwnerGender_PetCount_OK()
        {
            var result = _petListByOwnerGender.GetPetListByOwnerGender("Cat");

            Assert.AreEqual(5, result.Where(x => x.OwnerGender == "Male").Select(s => s.PetNames.Count()).FirstOrDefault());
            Assert.AreEqual(1, result.Where(x => x.OwnerGender == "Female").Select(s => s.PetNames.Count()).FirstOrDefault());
        }

        [TestMethod]
        public void BL_GetPetListbyOwnerGender_PetOrder_OK()
        {
            var result = _petListByOwnerGender.GetPetListByOwnerGender("Cat");

            Assert.AreEqual("Garfield", result.Where(x => x.OwnerGender == "Male").Select(s => s.PetNames.First()).FirstOrDefault());
            Assert.AreEqual("Garfield", result.Where(x => x.OwnerGender == "Female").Select(s => s.PetNames.Last()).FirstOrDefault());
            Assert.AreEqual("Tom", result.Where(x => x.OwnerGender == "Female").Select(s => s.PetNames.First()).FirstOrDefault());
        }
    }
}
