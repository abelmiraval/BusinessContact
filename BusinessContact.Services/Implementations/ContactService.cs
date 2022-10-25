using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessContact.DataAccess.Interfaces;
using BusinessContact.Dto.Response;
using BusinessContact.Entities;
using BusinessContact.Services.Interfaces;
using BusinessLogic.Dto.Request;

namespace BusinessContact.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;


        public ContactService(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<ContactResponse>>> GetListContact()
        {
            var response = new BaseResponseGeneric<ICollection<ContactResponse>>();
            try
            {
                var collection = await _repository.GetListContact();

                response.Result = _mapper.Map<ICollection<ContactResponse>>(collection);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> CreateAsync(ContactRequest request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Result = await _repository.CreateAsync(_mapper.Map<Contact>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ContactRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var contact = await _repository.GetByIdAsync(id);

                if (contact == null)
                {
                    response.Success = false;
                    return response;
                }

                contact.Name = request.Name;
                contact.Phone = request.Phone;
                contact.Address = request.Address;
                contact.BusinessId = request.BusinessId;
                contact.Email = request.Email;

                await _repository.UpdateAsync();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}