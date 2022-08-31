using EFAIRLINE.Entities;
using EFAIRLINE.DTOs;
using EFAIRLINE.Repositories;
using EFAirLine.Repositories;

namespace EFAIRLINE.Services
{
    public class FlightService
    {
        private readonly FlightRepository _repository;
        private object flight;

        public FlightService(FlightRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateFlightDto createFlightDto)
        {
            var flight = new Flight()
            {
                Type = createFlightDto.Type,
                Id = createFlightDto.FlightId,
                Price = createFlightDto.Price,
                IsAvailable = createFlightDto.isAvailable,
            };
            var response = _repository.Create(flight);
            if (response)
            {
                Console.WriteLine("Flight Created Successfully");
            }
            else
            {
                Console.WriteLine("Flight Creation Failed");
            }
        }

        public void Update(int flightId, UpdateFlightDto updateFlightDto)
        {
            var flight = _repository.GetById(flightId);
            if (flight == null)
            {
                Console.WriteLine("flight not found");
            }
            else
            {
                flight.Type = updateFlightDto.Type;
                flight.Price = updateFlightDto.Price;
                var response = _repository.Update(flight);
                if (response)
                {
                    Console.WriteLine("Update Succcessful");
                }
                else
                {
                    Console.WriteLine("Update Unsucccessful");
                }

            }
        }



        public List<GetFlightDto> GetAll()
        {
            var flights = _repository.List();
            return flights.Select(flight => new GetFlightDto
            {
                Type = flight.Type,
                FlightId = flight.FlightId,
                IsAvailable = flight.IsAvailable,
                Price = flight.Price,
                TakeOffPoint = flight.TakeOffPoint,
                Destination = flight.Destination,
                BoardDate = flight.BoardDate,

            }).ToList();

        }

        public GetFlightDto Find(int flightId)
        {
            var flight = _repository.GetById(flightId);
            return new GetFlightDto
            {
                Type = flight.Type,
                FlightId = flight.FlightId,
                IsAvailable = flight.IsAvailable,
                Price = flight.Price,
            };
        }
        public void Delete(int flightId)
        {
            var flight = _repository.GetById(flightId);
            if (flight == null)
            {
                Console.WriteLine($"No flight found with flightId {flightId}");
                return;
            }
            var response = _repository.Delete(flightId);
            if (response)
            {
                Console.WriteLine("Flight Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }
        public Flight ViewFlight(int flightId)
        {
            var Flight = _repository.GetById(flightId);
            return Flight;
        }

    }
}
