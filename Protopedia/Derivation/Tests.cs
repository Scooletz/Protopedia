using System.IO;
using NUnit.Framework;
using ProtoBuf;

namespace Protopedia.Derivation
{
    public class Tests
    {
        private const string Name = "Name";
        private const string AdditionalInfo = "AdditionalInfo";
        private const string SomeMoreInfo = "SomeMoreInfo";

        [Test]
        public void WhenMessageIsSerializedWithDerivation_ThenItCanBeDeserializedToASimpleCompositionBasedForm()
        {
            using (var ms = new MemoryStream())
            {
                // setup a C instance 
                var c = new Messages.C
                    {
                        Id = 5,
                        Name = Name,
                        AdditionalInfo = AdditionalInfo,
                        SomeMoreInfo = SomeMoreInfo
                    };

                Serializer.Serialize(ms, c);

                ms.Seek(0, SeekOrigin.Begin);
                var copositionedA = Serializer.Deserialize<MessagesWithCompositionInsteadOfInheritance.A>(ms);

                Assert.AreEqual(c.Id, copositionedA.Id);
                Assert.AreEqual(c.Name, copositionedA.Name);
                Assert.AreEqual(c.AdditionalInfo, copositionedA.BInstance.AdditionalInfo);
                Assert.AreEqual(c.SomeMoreInfo, copositionedA.BInstance.CInstance.SomeMoreInfo);
            }
        }
    }
}