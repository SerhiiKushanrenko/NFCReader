using BLL.DTO;
using BLL.Services;
using Moq;
using Moq.Protected;
using System.Net;

namespace NfcReader.UnitTests
{
    public class HttpServiceTest
    {
        public static IEnumerable<object[]> GetUserAuthDTO()
        {

            yield return new object[]
            {
                new UserAuthDTO()
                {
                    UsbDeviceId = "null",
                    DeviceId = Guid.NewGuid(),
                    Name = "Sam"
                },HttpStatusCode.OK,
            };

            yield return new object[]
            {
                new UserAuthDTO()
                {
                    UsbDeviceId = "null",
                    DeviceId = Guid.NewGuid(),
                },HttpStatusCode.BadRequest,
            };
        }

        [Theory]
        [MemberData(nameof(GetUserAuthDTO))]
        public async void ShouldCallCreatePostApi(UserAuthDTO userAuthDTO, HttpStatusCode httpStatusCode)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = httpStatusCode
            };
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            var httpService = new HttpService(httpClient);

            var statusCode = await httpService.UserAuthOnCloudBackEndAsync(userAuthDTO);

            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
                ItExpr.IsAny<CancellationToken>());

            Assert.Equal(httpStatusCode, statusCode);


        }
    }
}
