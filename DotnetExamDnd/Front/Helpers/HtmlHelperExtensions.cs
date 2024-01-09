using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Front.Helpers;

public static class HtmlHelperExtensions
{
    public static IHtmlContent Validation<TModel, TResult>(this IHtmlHelper<TModel> helper,
        Expression<Func<TModel, TResult>> expression)
    {
        if (helper.ViewData.ModelState.GetFieldValidationState(helper.NameFor(expression)) ==
            ModelValidationState.Invalid)
            return new HtmlContentBuilder().AppendHtml("<div class=\"alert alert-danger\" role=\"alert\">")
                .AppendHtml(helper.ValidationMessageFor(expression))
                .AppendHtml("</div>");
        return new HtmlContentBuilder();
    }
}