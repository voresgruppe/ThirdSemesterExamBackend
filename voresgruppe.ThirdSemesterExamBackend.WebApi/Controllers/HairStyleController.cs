using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStyleController : ControllerBase
    {
        private readonly IHairStyleService _hairstyleService;

        public HairStyleController(IHairStyleService hairStyleService)
        {
            if (hairStyleService == null)
            {
                throw new InvalidDataException("hairStyleService Cannot be null");
            }

            _hairstyleService = hairStyleService;
        }

        [HttpGet]
        public ActionResult<List<HairStyle>> GetAll()
        {
            return _hairstyleService.GetHairstyles();
        }
        
        [HttpGet("{id}")]
        public ActionResult<HairStyle> GetById(int id)
        {
            return _hairstyleService.GetHairstyleByID(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _hairstyleService.DeleteHairstyleById(id);
        }
    }
}