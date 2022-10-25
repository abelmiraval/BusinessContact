using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessContact.DataAccess.Interfaces;
using BusinessContact.Dto.Response;
using BusinessContact.Entities;
using BusinessContact.Services.Interfaces;
using BusinessContact.Services.Util.Constants;
using BusinessLogic.Dto.Request;
using Microsoft.Extensions.Logging;

namespace BusinessContact.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactService> _logger;

        public ContactService(IContactRepository repository, IMapper mapper, ILogger<ContactService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogCritical(ex.StackTrace);
                response.Success = false;
                response.Errors.Add(ErrorConstant.Message);
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
                _logger.LogCritical(ex.StackTrace);
                response.Success = false;
                response.Errors.Add(ErrorConstant.Message);
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

                _mapper.Map(request, contact);

                await _repository.UpdateAsync();

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.StackTrace);
                response.Success = false;
                response.Errors.Add(ErrorConstant.Message);
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
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

                await _repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.StackTrace);
                response.Success = false;
                response.Errors.Add(ErrorConstant.Message);
            }

            return response;
        }
    }
}