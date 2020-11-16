using System;
using System.Collections.Generic;
using System.Text;
using AGL.Assessment.Entities;

namespace AGL.Assessment.ExternalServices.Interfaces
{
    public interface IPetOwnerServices<T>
    {
        /// <summary>
        /// Returns the list of Pet Owners and their pets
        /// </summary>
        /// <returns></returns>
        List<T> GetPetOwners();
    }
}
