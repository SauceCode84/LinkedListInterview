using System.Collections.Generic;

using NUnit.Framework;

namespace LinkedListInterview
{
    public class LinkedListTests
    {
        [Test]
        public void LinkedList_ImplementsGenericIEnumerable()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.IsInstanceOf<IEnumerable<int>>(list);
        }
    }
}
