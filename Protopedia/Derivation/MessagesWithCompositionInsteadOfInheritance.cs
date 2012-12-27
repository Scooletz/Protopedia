using ProtoBuf;

namespace Protopedia.Derivation
{
    public class MessagesWithCompositionInsteadOfInheritance
    {
        [ProtoContract]
        public class A
        {
            [ProtoMember(1)]
            public string Name { get; set; }

            [ProtoMember(2)]
            public int Id { get; set; }

            [ProtoMember(Messages.TagIncludingFirstDerivingType)]
            public B BInstance { get; set; }
        }

        [ProtoContract]
        public class B
        {
            [ProtoMember(1)]
            public string AdditionalInfo { get; set; }

            [ProtoMember(Messages.TagIncludingFirstDerivingType)]
            public C CInstance { get; set; }
        }

        [ProtoContract]
        public class C
        {
            [ProtoMember(1)]
            public string SomeMoreInfo { get; set; }
        }
    }
}