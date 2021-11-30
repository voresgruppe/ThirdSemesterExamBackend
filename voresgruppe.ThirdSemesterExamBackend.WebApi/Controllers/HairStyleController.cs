using System.Collections.Generic;
using System.IO;
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
        
        [HttpPost]
        public ActionResult<HairStyle> Create([FromBody]HairStyle hairStyle)
        {
            var createdHairstyle = _hairstyleService.CreateHairstyle(hairStyle);
            return Created($"https://localhost/api/hairstyles/{createdHairstyle}", createdHairstyle);
        }
        [HttpPut]
        public ActionResult<HairStyle> Update(int id, string name, int estimatedTime)
        {
             
            var updatedHairstyle = _hairstyleService.UpdateHairstyle(id, new HairStyle() {Name = name, EstimatedTime = estimatedTime});
            return Created($"https://localhost/api/hairstyles/{updatedHairstyle}", updatedHairstyle);
        }
    }
}