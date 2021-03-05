 namespace Rufat_Soap_to_Rest.Services
{
    public interface ICallIdService
    {
        int GetLastId();
    }

    public class CallIdService : ICallIdService
    {
        private int callId = 1;

        public int GetLastId()
        {
            return callId++;
        }
    }
}
