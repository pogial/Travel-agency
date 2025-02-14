﻿using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Application.Interfaces
{
    public interface IPreferredHotelUseCase
    {
        public Task<IActionResult> SavePreferredHotel(PreferredHotelInsertDto preferredHotelInsertDto);
    }
}
