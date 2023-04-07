
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_02_EntityFramework.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public int CitiesId { get; set; }
        public Cities Cities { get; set; }
        public AirplaneTypes AirplaneTypes { get; set; }
        public int AirplaneTypesId { get; set; }

    }
}
