using System;
using NitroxModel.Helper;
using ProtoBufNet;

namespace NitroxModel.DataStructures.GameLogic
{
    [ProtoContract]
    [Serializable]
    public struct NitroxVector3
    {
        [ProtoMember(1)]
        public float X;

        [ProtoMember(2)]
        public float Y;

        [ProtoMember(3)]
        public float Z;

        public NitroxVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static NitroxVector3 Zero => new(0, 0, 0);

        public static NitroxVector3 One => new(1, 1, 1);

        public bool Equals(NitroxVector3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is NitroxVector3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static NitroxVector3 operator +(NitroxVector3 a, NitroxVector3 b)
        {
            return new(a.X + b.X,
                       a.Y + b.Y,
                       a.Z + b.Z);
        }

        public static NitroxVector3 operator -(NitroxVector3 a, NitroxVector3 b)
        {
            return new(a.X - b.X,
                       a.Y - b.Y,
                       a.Z - b.Z);
        }

        public static NitroxVector3 operator -(NitroxVector3 a)
        {
            return new(-a.X,
                       -a.Y,
                       -a.Z);
        }

        public static NitroxVector3 operator /(NitroxVector3 lhs, float rhs)
        {
            return new(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        public static NitroxVector3 operator *(NitroxVector3 lhs, float rhs)
        {
            return new(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }

        public static bool operator ==(NitroxVector3 lhs, NitroxVector3 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        public static bool operator !=(NitroxVector3 lhs, NitroxVector3 rhs)
        {
            return !(lhs == rhs);
        }

        public static NitroxVector3 Normalize(NitroxVector3 value)
        {
            float ls = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
            float length = Mathf.Sqrt(ls);
            return new NitroxVector3(value.X / length, value.Y / length, value.Z / length);
        }

        public static float Length(NitroxVector3 value)
        {
            float ls = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
            return Mathf.Sqrt(ls);
        }

        public static NitroxVector3 Cross(NitroxVector3 vector1, NitroxVector3 vector2)
        {
            return new(
                vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                vector1.Z * vector2.X - vector1.X * vector2.Z,
                vector1.X * vector2.Y - vector1.Y * vector2.X);
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }
    }
}
