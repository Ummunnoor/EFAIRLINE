using EFAIRLINE.Repositories;
using EFAIRLINE.DTOs;
using EFAIRLINE.Entities;
using EFAirLine.Repositories;

namespace EFAIRLINE.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository userRepository)
        {
            _repository = userRepository;
        }

        public void Register(CreateUserDto createUserDto)
        {
            var user = new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                Password = createUserDto.Password,
                Address = new Address()
                {
                    NumberLine = createUserDto.NumberLine,
                    Street = createUserDto.Street,
                    City = createUserDto.City,
                    State = createUserDto.State,
                    Country = createUserDto.Country,
                    PostalCode = createUserDto.PostalCode,
                }
            };
            var response = _repository.Create(user);
            if (response)
            {
                Console.WriteLine("User Registered");
            }
            else
            {
                Console.WriteLine("Registration failed");
            }
        }
        public void LogIn(string email,string password,CreateUserDto createUserDto)
        {
           var updatedUser = _repository.GetByEmail(email);
           if(updatedUser == null)
           {
            Console.WriteLine($"No user found with email {email}");
            return; 
           }
           updatedUser.Email = createUserDto.Email;
           updatedUser.Password = createUserDto.Password;
           var response = _repository.Create(updatedUser);
            if (response)
            {
                Console.WriteLine("User logged in successfully");
            }
            else
            {
                Console.WriteLine("Log in fails");
            }
        }
        public void AddNewStaff(int id,string firstName,string lastName,CreateUserDto createUserDto)
        {
           var updatedUser = _repository.GetById(id);
           var Name = $"{firstName} {lastName}";
           if (updatedUser == null)
           {
                Console.WriteLine($"NO STAFF WITH NAME {Name} found");
                return;
           }
           updatedUser.FirstName = createUserDto.FirstName;
           updatedUser.LastName = createUserDto.LastName;
            var response = _repository.Create(updatedUser);
            if (response)
            {
                Console.WriteLine($"Staff with id {id} has been added successfully");
            }
            else
            {
                 Console.WriteLine($"No Staff with id {id} found");
            }
        }

        public void Edit(string email, UpdateUserDto updateUserDto)
        {
            var updatedUser = _repository.GetByEmail(email);
            if(updatedUser == null)
            {
                Console.WriteLine($"No User found with email {email}");
                return;
            }
            updatedUser.FirstName = updateUserDto.FirstName;
            updatedUser.LastName = updateUserDto.LastName;
            updatedUser.PhoneNumber = updateUserDto.PhoneNumber;
            updatedUser.Address.NumberLine = updateUserDto.NumberLine;
            updatedUser.Address.Country = updateUserDto.Country;
            updatedUser.Address.State = updateUserDto.State;
            updatedUser.Address.Street = updateUserDto.Street;
            updatedUser.Address.PostalCode = updateUserDto.PostalCode;
            updatedUser.Address.City = updateUserDto.City;
            var response = _repository.Update(updatedUser);
            if (response)
            {
                Console.WriteLine("User Updated Successfully");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
        }

        public GetUserDto Find(string email)
        {
            var user = _repository.GetByEmail(email);
            return new GetUserDto()
            {
                Name = $"{user.LastName} {user.FirstName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                NumberLine = user.Address.NumberLine,
                City = user.Address.City,
                State = user.Address.State,
                Street = user.Address.Street,
                PostalCode = user.Address.PostalCode,
            };
        }

        public void Delete(string email)
        {
            var user = _repository.GetByEmail(email);
            if (user == null)
            {
                Console.WriteLine($"Not User found with email {email}");
                return;
            }
            var response = _repository.Delete(user);
            if (response)
            {
                Console.WriteLine("User Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }

        public List<GetUserDto> GetAll()
        {
            var users = _repository.List();
            return users.Select(user => new GetUserDto
            {
                Name = $"{user.LastName} {user.FirstName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                NumberLine = user.Address.NumberLine,
                City = user.Address.City,
                State = user.Address.State,
                Street = user.Address.Street,
                PostalCode = user.Address.PostalCode,
            }).ToList();
        }
        
    }
}
