using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AGL.Assessment.BusinessServices.Interfaces;
using Microsoft.Extensions.Options;
using AGL.Assessment.Messages;
using Microsoft.Extensions.Logging;

namespace AGL.Assessment.Demo.Controllers
{
    public class HomeController : Controller
    {
        IPetListByOwnerGender _catListByOnerGender;
        ILogger _logger;

        public HomeController(IPetListByOwnerGender catListByOwnerGender, ILogger logger )
        {
            _catListByOnerGender = catListByOwnerGender;
            _logger = logger;
        }
        public IActionResult Index(string petType)
        {
            List<PetListByOwnerGenderResponse> response = new List<PetListByOwnerGenderResponse>();
            try
            {
                response = _catListByOnerGender.GetPetListByOwnerGender(petType ?? "CAT");
            }
            catch (Exception e)
            {
                var exceptions = (e as AggregateException)?.InnerExceptions ?? new[] { e }.AsEnumerable();

                _logger.LogError("Execution failed due to the following errors:");
                foreach (var ex in exceptions)
                {
                    _logger.LogError($"{ex.GetType().FullName}: {ex.Message}");
                }
            }
            return View(response);
        }
    }
}