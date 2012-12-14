using System.IO;
using NUnit.Framework;
using ProtoBuf;

namespace Protopedia.Versioning
{
    public class Tests
    {
        [Test]
        public void WhenExtensibleUsedAsBase_ThenOldMessagesCanBeDeserializedFrom()
        {
            using (var ms = new MemoryStream())
            {
                // create an old message and serialize it
                var messageOld = new Messages.MessageOld
                              {
                                  Id = 5,
                                  Login = "test",
                                  Name = "nameeee",
                                  Password = new byte[] { 1, 4, 2, 3, 5, 3, 4 },
                                  Surname = "test"
                              };
                Serializer.Serialize(ms, messageOld);

                // deserialize and serialize back a new message
                ms.Seek(0, SeekOrigin.Begin);
                var messageNew = Serializer.Deserialize<Messages.MessageNew>(ms);

                ms.Seek(0, SeekOrigin.Begin);
                Serializer.Serialize(ms, messageNew);

                // deserialize a message by an old type and check whether it retrieves forgotten fields
                ms.Seek(0, SeekOrigin.Begin);
                var messageOld2 = Serializer.Deserialize<Messages.MessageOld>(ms);
                
                Assert.True(messageOld.Equals(messageOld2));
            }
        }
    }
}