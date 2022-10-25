using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessContact.Dto.Response;
using BusinessLogic.Dto.Request;

namespace BusinessContact.Services.Interfaces
{
    public interface IContactService
    {
        Task<BaseResponseGeneric<ICollection<ContactResponse>>> GetListContact();

        Task<BaseResponseGeneric<int>> CreateAsync(ContactRequest request);

        Task<BaseResponse> UpdateAsync(int id, ContactRequest request);
    }
}