using BLL.DTO;

namespace NfcReader.UnitTests
{
    public class UsbDeviceInfoTest
    {

        [Fact]
        public void GetUniqueDeviceID_True()
        {
            //arrange
            var model = new UsbDeviceInfoDTO("USB\\VID_13FE&PID_4300\\071C1CB41BA41291", "dasdas", "dadasd");
            var expect = "071C1CB41BA41291";

            //act
            var result = model.GetUniqueDeviceID();
            //assert
            Assert.Equal(expect, result);
        }
    }
}
