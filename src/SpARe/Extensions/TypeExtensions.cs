namespace SpARe.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsImplementationOf<T>(this Type type) where T : class
        {
            ArgumentNullException.ThrowIfNull(type);

            var genericType = typeof(T);

            if (!genericType.IsInterface)
            {
                throw new ArgumentException($"{genericType} is not an interface!", nameof(T));
            }

            return !type.IsInterface && type.IsAssignableTo(genericType);
        }
    }
}
