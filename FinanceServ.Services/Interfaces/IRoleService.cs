﻿using FinanceServ.Models.DTO;
using FinanceServ.Services.Interfaces.CRUD;

namespace FinanceServ.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными по ролям.
    /// </summary>
    public interface IRoleService : ICrudService<RoleDto>
    {
    }
}
