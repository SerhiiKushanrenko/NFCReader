namespace BLL.DTO
{
    public class UsbDeviceInfoDTO
    {
        public string DeviceId { get; private set; }
        public string PnpDeviceId { get; private set; }
        public string Description { get; private set; }

        public UsbDeviceInfoDTO(string deviceID, string pnpDeviceID, string description)
        {
            DeviceId = deviceID;
            PnpDeviceId = pnpDeviceID;
            Description = description;
        }

        public UsbDeviceInfoDTO()
        {

        }

        public string GetUniqueDeviceID()
        {

            return DeviceId.Split("\\").Last();
        }
    }
}
