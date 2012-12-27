using ProtoBuf;

namespace Protopedia.Derivation
{
    public class Messages
    {
        public const int TagIncludingFirstDerivingType = 10;

        [ProtoContract]
        [ProtoInclude(TagIncludingFirstDerivingType, typeof(B))]
        public class A
        {
            [ProtoMember(1)]
            public string Name { get; set; }

            [ProtoMember(2)]
            public int Id { get; set; }
        }

        [ProtoContract]
        [ProtoInclude(TagIncludingFirstDerivingType, typeof(C))]
        public class B : A
        {
            [ProtoMember(1)]
            public string AdditionalInfo { get; set; }
        }

        [ProtoContract]
        public class C : B
        {
            [ProtoMember(1)]
            public string SomeMoreInfo { get; set; }
        }
    }
}