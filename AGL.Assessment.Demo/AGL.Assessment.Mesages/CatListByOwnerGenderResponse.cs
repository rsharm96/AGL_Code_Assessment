using System;
using System.Collections.Generic;
using System.Linq;

namespace AGL.Assessment.Messages
{
    public class PetListByOwnerGenderResponse
    {
        private List<String> _petNames;
        public string OwnerGender { get; set; }
        public List<String> PetNames 
        {
            get => this._petNames.OrderBy(n => n, StringComparer.OrdinalIgnoreCase).ToList();
            set => this._petNames = value;
        }

    }
}
