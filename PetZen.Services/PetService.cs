using PetZen.Data;
using PetZen.Models;
using PetZen.Models.PetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetZen.Services
{
    public class PetService
    {
        private readonly Guid _userId;

        public PetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePet(PetCreate model)
        {
            var entity =
                new Pet()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Species = model.Species,
                    Breed = model.Breed,
                    Weight = model.Weight,
                    DateOfBirth = model.DateOfBirth,
                    MealsPerDay = model.MealsPerDay        
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<PetListItem> GetPets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pets
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PetListItem
                                {
                                    PetId = e.PetId,
                                    Name = e.Name,
                                    DateOfBirth = e.DateOfBirth,
                                    MealsPerDay = e.MealsPerDay
                                }
                         );
                return query.ToArray();
            }
        }
    }
}
