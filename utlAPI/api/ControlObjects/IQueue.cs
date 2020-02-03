using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.ControlObjects
{
    public interface IQueue
    {
        string StoreFloatRequestsToQueue(decimal FloatAmount, int AgentId);

        string StoreFloatCreditsToQueue(decimal floatAmount, int agentId);

        string insertInQueue(Object ag, string queueName);
    }
}
