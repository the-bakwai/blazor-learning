using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Business.Repositories.IRepositories
{
    public interface IHotelRoomRepository
    {
        Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto);
        Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto);
        Task<HotelRoomDto> GetHotelRoom(int roomId);
        Task<IEnumerable<HotelRoomDto>> GetAllHotelRooms();
        Task<HotelRoomDto> IsRoomUnique(string name);
        Task<int> DeleteHotelRoom(int roomId);
    }
}