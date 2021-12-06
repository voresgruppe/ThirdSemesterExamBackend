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
        public ActionResult<List<Hairstyle>> GetAll()
        {
            return _hairstyleService.GetHairstyles();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Hairstyle> GetById(int id)
        {
            return _hairstyleService.GetHairstyleByID(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _hairstyleService.DeleteHairstyleById(id);
        }
        
        [HttpPost]
        public ActionResult<Hairstyle> Create([FromBody]Hairstyle hairstyle)
        {
            var createdHairstyle = _hairstyleService.CreateHairstyle(hairstyle);
            return Created($"https://localhost/api/hairstyles/{createdHairstyle}", createdHairstyle);
        }
        [HttpPut]
        public ActionResult<Hairstyle> Update(int id, Hairstyle hairstyle)
        {
             
            var updatedHairstyle = _hairstyleService.UpdateHairstyle(id, hairstyle);
            return Created($"https://localhost/api/hairstyles/{updatedHairstyle}", updatedHairstyle);
        }
    }
}