using AGL.Assessment.Entities;
using AGL.Assessment.ExternalServices.Interfaces;
using System.Collections.Generic;

namespace AGL.Assessment.ExternalServices
{
    public class PetOwnerServices<T> : IPetOwnerServices<T>
    {
        private readonly IHttpHelper<T> _httpHelper;
       
        public PetOwnerServices(IHttpHelper<T> httpHelper)
        {
            this._httpHelper = httpHelper;            
        }
        
        /// <summary>
        /// Returns the list of Pet Owners and their pets
        /// </summary>
        /// <returns></returns>
        public List<T> GetPetOwners()
        {
            string url = @"http://agl-developer-test.azurewebsites.net/people.json";
            return _httpHelper.GetContentFromURL(url);
        }
    }
}
