namespace FinanceServ.Models.Responses.Role
{
    /// <summary>
    /// Ответ на запросы по ролям.
    /// </summary>
    public class RoleResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название роли.
        /// </summary>
        public string Name { get; set; }
    }
}
