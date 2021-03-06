﻿using System.Threading.Tasks;

namespace FinanceServ.Services.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для создания сущности.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface ICreatable<TDto>
    {
        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <returns>Идентификатор созданной сущности.</returns>
        Task<TDto> CreateAsync(TDto dto);
    }
}
