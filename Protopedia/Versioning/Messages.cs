using ProtoBuf;
using System.Linq;

namespace Protopedia.Versioning
{
    public class Messages
    {
        [ProtoContract]
        public class MessageOld : Extensible
        {
            [ProtoMember(1)]
            public long Id { get; set; }

            [ProtoMember(2)]
            public string Name { get; set; }

            [ProtoMember(3)]
            public string Surname { get; set; }

            [ProtoMember(4)]
            public string Login { get; set; }

            [ProtoMember(5)]
            public byte[] Password { get; set; }

            public bool Equals(MessageOld other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.Id == Id
                       && Equals(other.Name, Name)
                       && Equals(other.Surname, Surname)
                       && Equals(other.Login, Login)
                       && other.Password.SequenceEqual(Password);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (MessageOld)) return false;
                return Equals((MessageOld) obj);
            }
        }

        [ProtoContract]
        public class MessageNew : Extensible
        {
            [ProtoMember(4)]
            public string Login { get; set; }

            [ProtoMember(5)]
            public byte[] Password { get; set; }

            [ProtoMember(6)]
            public bool IsPremiumAccount { get; set; }
        }
    }
}