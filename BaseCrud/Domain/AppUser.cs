using System;

namespace BaseCrud.Domain
{
    public class AppUser : IEntity, INamed
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdUser { get; set; }
        public DateTime Created { get; set; }
    }
}