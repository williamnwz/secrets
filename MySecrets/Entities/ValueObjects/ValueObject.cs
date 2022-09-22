namespace MySecrets.Domain.Entities.ValueObjects
{
    public abstract class ValueObject<T>
    {
        public ValueObject(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public abstract bool IsValid();
    }
}
