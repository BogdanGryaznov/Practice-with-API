namespace BackendApi.Contracts.User
{
    public class CreateUserRequest
    {
        public int IdUser { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public string Address { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
