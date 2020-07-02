using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoService
{
    public class DogService
    {
        private readonly List<Dog> _dogs;

        public DogService()
        {
            _dogs = new List<Dog>
            {
                new Dog
                {
                    Id = 1,
                    Name = "Boo",
                    Breed = "BMH"
                },
                new Dog
                {
                    Id = 2,
                    Name = "Barney",
                    Breed = "Labrador"
                },
                new Dog
                {
                    Id = 3,
                    Name = "Bobby",
                    Breed = "Labrador"
                }
            };
        }

        public async Task<Dog> Get(int id)
        {
            return await Task.FromResult(_dogs.FirstOrDefault(x => x.Id == id));
        }

        public async Task<List<Dog>> Get()
        {
            return await Task.FromResult(_dogs ?? new List<Dog>());
        }

        public async Task<int> Post(Dog dog)
        {
            _dogs.Add(dog);

            return await Task.FromResult(0);
        }
    }
}
