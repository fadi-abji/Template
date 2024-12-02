
namespace Business.Models
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal class HideFromApiRefAttribute : Attribute
    {
    }
}