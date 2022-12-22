using AutoFixture;
using BLL.DTO;
using BLL.Services;
using BLL.Services.Interfaces;
using Moq;

namespace NfcReader.UnitTests
{
    public class UsbListenerTest
    {
        private readonly Mock<IUsbDeviceService> _usbDeviceServiceMock;
        public List<UsbDeviceInfoDTO> _staticDevices = new List<UsbDeviceInfoDTO>()
        {
            new UsbDeviceInfoDTO(new Fixture().Create<string>(),new Fixture().Create<string>(),new Fixture().Create<string>()),
            new UsbDeviceInfoDTO(new Fixture().Create<string>(),new Fixture().Create<string>(),new Fixture().Create<string>()),
            new UsbDeviceInfoDTO(new Fixture().Create<string>(),new Fixture().Create<string>(),new Fixture().Create<string>()),
        };
        public UsbListenerTest()
        {
            _usbDeviceServiceMock = new();
            _usbDeviceServiceMock.Setup(b => b.StaticDevices).Returns(_staticDevices);
        }


        [Fact]
        public void GetEmptyDTO_NoUsbDevicesEnter()
        {
            _usbDeviceServiceMock.Setup(builder => builder.GetUSBDevices()).Returns(_staticDevices);

            // arrange    
            var service = _usbDeviceServiceMock.Object;
            var usbListener = new UsbListenerService(service);
            var newDevices = usbListener.StartListenUsbPosts();

            //act
            var result = new UsbDeviceInfoDTO();

            //assert
            Assert.Equal(result.DeviceId, newDevices.DeviceId);
        }
    }
}