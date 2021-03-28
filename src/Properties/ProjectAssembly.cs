using System;
using System.Linq;
using System.Reflection;

namespace Spare.Properties
{
    public static class ProjectAssembly
    {
        public static string? Copyright { get; } = GetAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        public static string? RepositoryUrl { get; } = GetAttribute<AssemblyMetadataAttribute>()?.Value;

        private static T? GetAttribute<T>() where T : Attribute =>
            Assembly.GetExecutingAssembly().GetCustomAttributes<T>().FirstOrDefault();
    }
}
