using System;

namespace NiGames.Tweening
{
    public readonly struct NiTweenHandle : IEquatable<NiTweenHandle>
    {
        /// <summary>
        /// Unique tween identifier.
        /// </summary>
        public readonly int Id;
        
        /// <summary>
        /// Identifier of the repository to which the tween belongs.
        /// </summary>
        public readonly int RepositoryId;
        
        /// <summary>
        /// Tween version.
        /// </summary>
        public readonly int Version;
        
        public NiTweenHandle(int id, int repositoryId, int version)
        {
            Id = id;
            RepositoryId = repositoryId;
            Version = version;
        }
        
        public bool Equals(NiTweenHandle other)
        {
            return Id == other.Id && RepositoryId == other.RepositoryId && Version == other.Version;
        }

        public override bool Equals(object obj)
        {
            return obj is NiTweenHandle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, RepositoryId, Version);
        }
        
        public static bool operator ==(NiTweenHandle p1, NiTweenHandle p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(NiTweenHandle p1, NiTweenHandle p2)
        {
            return !(p1 == p2);
        }

        public static readonly NiTweenHandle Invalid = new(-1, -1, -1);
    }
}