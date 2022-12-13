namespace BLL.DTO
{
    public class UserAuthDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? UsbDeviceId { get; set; }

        public Guid DeviceId { get; set; }
    }
}
