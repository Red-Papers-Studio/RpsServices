using System.Reflection;

namespace Auth.Domain.Base;

public abstract class DomainEnumeration<TId>
{
    public TId Id { get; }
    public string Name { get; }

    protected DomainEnumeration(TId id, string name)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }


    public static IEnumerable<T> GetAll<T>() where T : DomainEnumeration<TId>
    {
        return typeof(T).GetFields(BindingFlags.Public |
                                   BindingFlags.Static |
                                   BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    }


    public static DomainEnumeration<TId> FromId<T>(TId id) where T : DomainEnumeration<TId>
    {
        return GetAll<T>().Single(e => Equals(e.Id, id));
    }

    public static DomainEnumeration<TId> FromName<T>(string name) where T : DomainEnumeration<TId>
    {
        return GetAll<T>().Single(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}