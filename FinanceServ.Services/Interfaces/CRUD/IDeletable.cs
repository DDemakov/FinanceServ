﻿using System.Threading.Tasks;

namespace FinanceServ.Services.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для удаления сущностей.
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// Групповое удаление сущностей.
        /// </summary>
        /// <param name="ids">Идентификаторы.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        Task DeleteAsync(params long[] ids);
    }
}
