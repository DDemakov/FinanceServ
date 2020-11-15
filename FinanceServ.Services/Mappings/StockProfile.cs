﻿using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Services.Mappings
{
    /// <summary>
    /// Профиль маппинга (Акции).
    /// </summary>
    public class StockProfile : Profile
    {
        /// <summary>
        /// Инициализрует экзземпляр <see cref="StockProfile"/>
        /// </summary>
        public StockProfile()
        {
            CreateMap<Stock, StockDto>();
        }
    }
}
