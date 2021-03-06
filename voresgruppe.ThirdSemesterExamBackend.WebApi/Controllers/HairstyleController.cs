using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairstyleController : ControllerBase
    {
        private readonly IHairStyleService _hairstyleService;

        public HairstyleController(IHairStyleService hairStyleService)
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
        
        [HttpPost(nameof(Create))]
        public ActionResult<Hairstyle> Create(Hairstyle hairstyle)
        {
            var createdHairstyle = _hairstyleService.CreateHairstyle(hairstyle);
            return Created($"https://localhost/api/hairstyles/{createdHairstyle}", createdHairstyle);
        }
        [HttpPut(nameof(Update))]
        public ActionResult<Hairstyle> Update(int id, Hairstyle hairstyle)
        {
             Console.WriteLine(hairstyle.PossibleStyles);
            var updatedHairstyle = _hairstyleService.UpdateHairstyle(id, hairstyle);
            return updatedHairstyle;
        }

        [HttpPost(nameof(GetListOfHairstyles_FromListOfId))]
        public ActionResult<List<Hairstyle>> GetListOfHairstyles_FromListOfId(List<int> possibleStyles)
        {
            return _hairstyleService.GetListOfHairstyles_FromListOfId(possibleStyles);
        }
            
        [HttpGet(nameof(GetListOfHairstyles_IsStarterStyle))]
        public ActionResult<List<Hairstyle>> GetListOfHairstyles_IsStarterStyle()
        {
            return _hairstyleService.GetListOfHairstyles_IsStarterStyle();
        }
    }
}