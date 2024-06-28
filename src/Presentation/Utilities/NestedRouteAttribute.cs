using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Presentation.Utilities;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal sealed class NestedRouteAttribute<TController>(string template)
    : Attribute, IRouteTemplateProvider
    where TController : ControllerBase
{
    private readonly Type _controllerType = typeof(TController);
    
    public string Template => CreateTemplate();
    public int? Order => null;
    public string Name => template;

    private string CreateTemplate()
    {
        var baseType = _controllerType.BaseType;
        var routeAttr = baseType?.GetCustomAttribute(typeof(NestedRouteAttribute<>)) as IRouteTemplateProvider;
        return Path.Join(routeAttr?.Template, template);
    }
}