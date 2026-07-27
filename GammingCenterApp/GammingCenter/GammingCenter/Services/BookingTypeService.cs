using GammingCenter.DTOs.BookingType;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class BookingTypeService
    {
        // Repository dependency injected through the constructor
        private readonly BookingTypeRepository _repository;

        //Constractor
        public BookingTypeService(BookingTypeRepository repository)
        {
            _repository = repository;
        }

        ////////////////////////////////////////////////////////////

        // 1- Add Booking Type
        public void AddBookingType(BookingTypeCreateDto dto)
        {
            BookingType bookingType = new BookingType
            {
                TypeName = dto.TypeName,
                Description = dto.Description
            };

            _repository.AddBookingType(bookingType);
        }

        ////////////////////////////////////////////////////////

        // 2- Update Booking Type
        public bool UpdateBookingType(int BookingTypeId, BookingTypeUpdateDto dto)
        {
            BookingType existingbookingType = _repository.GetBookingTypeById(BookingTypeId);

            // Check if booking type exists
            if(existingbookingType == null)
            {
                return false;
            }

            existingbookingType.TypeName = dto.TypeName;
            existingbookingType.Description = dto.Description;

            _repository.UpdateBookingType(existingbookingType);

            return true;

        }

        ////////////////////////////////////////////////////////

        // 3- Delete Booking Type
        public bool DeleteBookingType(int BookingTypeId)
        {
            BookingType existbookingType = _repository.GetBookingTypeById(BookingTypeId);

                 // Check if booking type exists
                if (existbookingType == null)
                {
                    return false;

                }

            _repository.UpdateBookingType(existbookingType);

            return true;
            }

        ////////////////////////////////////////////////////////

        // 4- View Booking Types
        public List<BookingTypeResponseDto> GetBookingTypes()
        {
            // Retrieve all booking types from DB through Repo
            List<BookingType> bookingTypes = _repository.GetBookingTypes();

            // Convert each BookingType Model into a BookingTypeResponseDto To return only required date to user
            List<BookingTypeResponseDto> responseDtos = bookingTypes.Select(

                // Take each BookingType object from the list
                bookingTypes =>

                // Create new Response DTO for current BookingType
                new BookingTypeResponseDto
            {
                    // Map the BookingType from  Model to Response DTO
                    BookingTypeID = bookingTypes.BookingTypeID,
                TypeName = bookingTypes.TypeName,
                Description = bookingTypes.Description

            }).ToList();

            return responseDtos;
        }

    }


}

