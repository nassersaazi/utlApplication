using api.ControlObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace api.Tests.ControlObjects
{   [TestFixture]
    public class QueueInsertionTest
    {
        private IQueue queue;
        //inject dependency

        public QueueInsertionTest(IQueue queue)
        {
            this.queue = queue;
        }

        public string StoreFloatRequestsToQueue(string path)
        {
            return "";
            //implement method that you want to test here
        }

        [Test]
        public void insertInQueue_isDataInserted_returnsTrue()
        {

        }
        
    }
}
