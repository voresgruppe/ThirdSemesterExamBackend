using System;
using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class HairstyleEntityUtils
    {
        public Hairstyle EntityToHairStyle(HairstyleEntity entity)
        {
            Hairstyle hairstyle = new Hairstyle
            {
                Id = entity.Id,
                Name = entity.Name,
                EstimatedTime = entity.EstimatedTime,
                Description = entity.Description,
                Price = entity.Price,
                PossibleStyles = StringToListInt(entity.PossibleStyles),
            };

            return hairstyle;
        }

        public HairstyleEntity HairstyleToEntity(Hairstyle hairstyle)
        {
            return new HairstyleEntity()
            {
                Id = hairstyle.Id,
                Name = hairstyle.Name,
                EstimatedTime = hairstyle.EstimatedTime,
                Description = hairstyle.Description,
                Price = hairstyle.Price,
                PossibleStyles = (ListIntToString(hairstyle.PossibleStyles))
            };
        }

        private List<int> StringToListInt(string s)
        {
            List<int> possibleStyles = new List<int>();

            string[] iDs = s.Split(",");
            
            foreach (var iD in iDs)
            {
                
                if (Int32.TryParse(iD, out int i))
                {
                   possibleStyles.Add(i); 
                }
                else
                {
                    Console.WriteLine(iD);
                }
                
            }

            return possibleStyles;
        }

        private string ListIntToString(List<int> iDs)
        {
            string s = " ";
            foreach (var iD in iDs)
            {
                s += iD + ",";
            }

            s.Remove(s.Length-1);

            return s;
        }

        

        
    }
}