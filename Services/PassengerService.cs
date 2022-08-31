using EFAIRLINE.Entities;
using EFAIRLINE.DTOs;
using EFAIRLINE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAIRLINE.Services
{
    public class PassengerService
    {
        private readonly PassengerRepository _repository;

        public PassengerService(PassengerRepository repository)
        {
            _repository = repository;
        }

        public void Register(CreatePassengerDto createPassengerDto)
        {
            var passenger = new Passenger()
            {
                NextOfKin = createPassengerDto.NextOfKin,
                DateOfBirth = createPassengerDto.DateOfBirth,
                Gender = createPassengerDto.Gender,
                IsActive = createPassengerDto.isActive,
                User = new User
                {
                    LastName = createPassengerDto.User.LastName,
                    FirstName = createPassengerDto.User.FirstName,
                    Email = createPassengerDto.User.Email,
                    PhoneNumber = createPassengerDto.User.PhoneNumber,
                    Password = createPassengerDto.User.Password,
                    Address = new Address
                    {
                        City = createPassengerDto.User.City,
                        Country = createPassengerDto.User.Country,
                        State = createPassengerDto.User.State,
                        NumberLine = createPassengerDto.User.NumberLine,
                        PostalCode = createPassengerDto.User.PostalCode,
                        Street = createPassengerDto.User.Street,
                    } 
                }
            };
            var response = _repository.Create(passenger);
            if(response)
            {
                Console.WriteLine("Passengers created Sucessfully");
            }
            else
            {
                Console.WriteLine("Passengers not created");
            }
        }
        public void LogIn(string email,string password,CreatePassengerDto createPassengerDto)
        {
           var updatedPassenger = _repository.GetByEmail(email);
           if(updatedPassenger == null)
           {
            Console.WriteLine($"No passenger found with email {email}");
            return; 
           }
           updatedPassenger.User.Email = createPassengerDto.Email;
           updatedPassenger.User.Password = createPassengerDto.Password;
           var response = _repository.Create(updatedPassenger);
            if (response)
            {
                Console.WriteLine("Passenger logged in successfully");
            }
            else
            {
                Console.WriteLine("Log in fails");
            }
        }
        public void UpdateWallet(string email,UpdatePassengerDto updatePassengerDto)
        {
            var updatedPassenger = _repository.GetByEmail(email);
            updatedPassenger.Wallet += updatePassengerDto.Wallet;
            var response = _repository.Create(updatedPassenger);
            if (response)
            {
                Console.WriteLine("Passenger wallet updated successfully");
                Console.WriteLine($"Your wallet balance is  {updatedPassenger.Wallet}");
            }
             else
            {
                Console.WriteLine("Passenger wallet updated failed");
            }
        }
        public void FundWallet(string email,GetPassengerDto getPassengerDto)
        {
                Console.WriteLine("Enter amount to fund your wallet");
                decimal amount = decimal.Parse(Console.ReadLine());
                UpdatePassengerDto updatePassengerDto = new UpdatePassengerDto()
                {
                    Wallet = amount,
                };
                UpdateWallet(getPassengerDto.User.Email, updatePassengerDto);
        }
        public GetPassengerDto CheckWallet(string email)
        {
            var Passenger = _repository.GetByEmail(email);
            return new GetPassengerDto()
            {
                Wallet = Passenger.Wallet
            };
        }
        public Passenger ViewProfile(string email)
        {
            var Passenger = _repository.GetByEmail(email);
            return Passenger;
        }
          
        
        public void Edit(string email, UpdatePassengerDto updatePassengerDto)
        {
            var updatedPassenger = _repository.GetByEmail(email);
            if (updatedPassenger != null)
            {
                updatedPassenger.NextOfKin = updatePassengerDto.NextOfKin;
                updatedPassenger.DateOfBirth = updatePassengerDto.DateOfBirth;
                updatedPassenger.Gender = updatePassengerDto.Gender;
                updatedPassenger.User.FirstName = updatePassengerDto.User.FirstName;
                updatedPassenger.User.LastName = updatePassengerDto.User.LastName;
                updatedPassenger.User.PhoneNumber = updatePassengerDto.User.PhoneNumber;
                updatedPassenger.User.Address.NumberLine = updatePassengerDto.User.NumberLine;
                updatedPassenger.User.Address.Street = updatePassengerDto.User.Street;
                updatedPassenger.User.Address.City = updatePassengerDto.User.City;
                updatedPassenger.User.Address.Country = updatePassengerDto.User.Country;
                updatedPassenger.User.Address.PostalCode = updatePassengerDto.User.PostalCode;
                updatedPassenger.User.Address.State = updatePassengerDto.User.State;
                var response = _repository.Update(updatedPassenger);
                if (response)
                {
                    Console.WriteLine("Passenger updated sucessfully");
                }
                else
                {
                    Console.WriteLine("Passenger update failed");
                }
            }
            else
            {
                Console.WriteLine("Passenger not found");
            }
            
        }
        public GetPassengerDto Find(string email)
        {
            var passenger = _repository.GetByEmail(email);
            return new GetPassengerDto()
            {
                NextOfKin = passenger.NextOfKin,
                DateOfBirth = passenger.DateOfBirth,
                Gender = passenger.Gender,
                IsActive = passenger.IsActive,
                User = new GetUserDto()
                {
                    Name = $"{passenger.User.LastName} {passenger.User.FirstName}",
                    Email = passenger.User.Email,
                    PhoneNumber = passenger.User.PhoneNumber,
                    City = passenger.User.Address.City,
                    Country = passenger.User.Address.Country,
                    State = passenger.User.Address.State,
                    NumberLine = passenger.User.Address.NumberLine,
                    PostalCode = passenger.User.Address.PostalCode,
                    Street = passenger.User.Address.Street
                }
            };
        }
        public List<GetPassengerDto> GetAll()
        {
            var customers = _repository.List();
            return customers.Select(customer => new GetPassengerDto
            {
                NextOfKin = customer.NextOfKin,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                IsActive = customer.IsActive,
                User = new GetUserDto()
                {
                    Name = $"{customer.User.LastName} {customer.User.FirstName}",
                    Email = customer.User.Email,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            }).ToList();
        }
    }
}
