using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Repositories.IRepositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repositories
{
    public class HotelRoomRepository: IHotelRoomRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto)
        {
            var hotelRoom = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";
            hotelRoom.UpdatedBy = "";
            hotelRoom.UpdatedDate = DateTime.Now;
            var addedHotelRoom = await _context.HotelRooms.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDto>(addedHotelRoom.Entity);

        }

        public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto)
        {
            try
            {
                if (roomId == hotelRoomDto.Id)
                {
                    var roomDetails = await _context.HotelRooms.FindAsync(hotelRoomDto.Id);
                    var room = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto, roomDetails);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;
                    var updateRoom = _context.HotelRooms.Update(room);
                    await _context.SaveChangesAsync();

                    return _mapper.Map<HotelRoom, HotelRoomDto>(updateRoom.Entity);

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public async Task<HotelRoomDto> GetHotelRoom(int roomId)
        {
            try
            {
                var hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>( await _context.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));

                return hotelRoom;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<HotelRoomDto>> GetAllHotelRooms()
        {
            try
            {
                var hotelRoomsDtos =
                    _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDto>>(_context.HotelRooms);

                return hotelRoomsDtos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> IsRoomUnique(string name)
        {
            try
            {
                var hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>( await _context.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                return hotelRoom;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            try
            {
                var roomDetails = await _context.HotelRooms.FindAsync(roomId);
                if (roomDetails != null)
                {
                    _context.HotelRooms.Remove(roomDetails);
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}