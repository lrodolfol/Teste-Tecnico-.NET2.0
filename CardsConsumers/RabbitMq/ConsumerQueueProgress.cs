using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsConsumers.RabbitMq
{
    public class ConsumerQueueProgress : Consumer
    {
        public void Start()
        {
            Consume("progress-manager", "localhost");
        }
    }
}
