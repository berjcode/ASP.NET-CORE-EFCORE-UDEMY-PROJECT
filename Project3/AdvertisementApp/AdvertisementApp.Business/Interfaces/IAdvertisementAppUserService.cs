using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type);

        Task<IResponse> RemoveAsync(int id);
    }
}
