namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Связевая таблица Пользователь-Роль.
    /// </summary>
    public class UserRole : BaseEntity
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public Role Role { get; set; }
    }
}
