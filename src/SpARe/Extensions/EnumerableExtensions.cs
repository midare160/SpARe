namespace SpARe.Extensions
{
	public static class EnumerableExtensions
	{
		public static ICollection<T> AsCollection<T>(this IEnumerable<T> enumerable) => 
			enumerable as ICollection<T> ?? enumerable.ToList();

		public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this IEnumerable<T> enumerable) =>
			enumerable as IReadOnlyCollection<T> ?? enumerable.ToArray();
	}
}
