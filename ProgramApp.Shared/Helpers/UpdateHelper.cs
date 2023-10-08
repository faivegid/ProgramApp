using System.Reflection;

namespace ProgramApp.Shared.Helpers
{
    public static class UpdateHelper
    {
        public static void UpdateModelProperties<TTarget, TSource>(TTarget target, TSource source)
        {
            Type sourceType = source.GetType();
            PropertyInfo[] sourceProperties = sourceType.GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                object sourceValue = sourceProperty.GetValue(source);

                if (sourceValue != null)
                {
                    PropertyInfo targetProperty = target.GetType().GetProperty(sourceProperty.Name);

                    if (targetProperty != null)
                    {
                        targetProperty.SetValue(target, sourceValue);
                    }
                }
            }
        }
    }
}
