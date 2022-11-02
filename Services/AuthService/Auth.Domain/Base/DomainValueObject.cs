namespace Auth.Domain.Base;

public abstract class DomainValueObject : ICloneable
{
    protected static bool EqualOperator(DomainValueObject left, DomainValueObject right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;
        return ReferenceEquals(left, right) || Equals(left, right);
    }

    protected static bool NotEqualOperator(DomainValueObject left, DomainValueObject right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (DomainValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }
    
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x == null! ? 0 : x.GetHashCode())
            .Aggregate(HashCode.Combine);
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}