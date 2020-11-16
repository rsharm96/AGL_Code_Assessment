using AGL.Assessment.BusinessServices.Interfaces;
using AGL.Assessment.Entities;
using AGL.Assessment.ExternalServices;
using AGL.Assessment.ExternalServices.Interfaces;
using AGL.Assessment.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGL.Assessment.BusinessServices
{
    public class PetListByOwnerGender : IPetListByOwnerGender
    {
        IPetOwnerServices<PetOwner> _petOwnerServices;
        IHttpHelper<PetOwner> _httpHelper;

        public PetListByOwnerGender()
        {
            this._httpHelper = new HttpHelper<PetOwner>();
            this._petOwnerServices = new PetOwnerServices<PetOwner>(_httpHelper);


        }
        public PetListByOwnerGender(IPetOwnerServices<PetOwner> petOwnerServices, IHttpHelper<PetOwner> httpHelper)
        {
            this._petOwnerServices = petOwnerServices;
            this._httpHelper = httpHelper;
        }

        /// <summary>
        /// Returns the list of alphabetically sorted cats 
        /// Grouped in their owners gender
        /// </summary>
        /// <returns></returns>
        public List<PetListByOwnerGenderResponse> GetPetListByOwnerGender(string petType)
        {
            var petOwnerList = _petOwnerServices.GetPetOwners();

            var result = petOwnerList.SelectMany(o => (o.Pets ?? Enumerable.Empty<Pet>())
                                                            .Where(p => p.Type.ToUpper() == petType.ToUpper())
                                                                .Select(pet => new { ownerGender = o.Gender, catName = pet.Name }))
                                         .GroupBy(pair => pair.ownerGender, pair => pair.catName)
                                         .Select(g =>
                                                    new PetListByOwnerGenderResponse()
                                                    {
                                                        OwnerGender = g.Key,
                                                        PetNames = g.ToList()
                                                    }).ToList();

            return result;
        }
    }
}
