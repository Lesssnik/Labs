using System.ServiceModel;

namespace MvсTester
{
    [ServiceContract]
    public interface IUserInfoService
    {
        [OperationContract]
        int GetUsersCount();

        [OperationContract]
        int GetUserTestsCount(string user);
    }
}
