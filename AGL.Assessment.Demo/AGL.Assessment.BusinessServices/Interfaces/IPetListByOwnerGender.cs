using AGL.Assessment.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.Assessment.BusinessServices.Interfaces
{
    public interface IPetListByOwnerGender
    {
        /// <summary>
        /// Returns the list of alphabetically sorted cats 
        /// Grouped in their owners' gender
        /// </summary>
        /// <returns></returns>
        List<PetListByOwnerGenderResponse> GetPetListByOwnerGender(string petType);
    }
}
