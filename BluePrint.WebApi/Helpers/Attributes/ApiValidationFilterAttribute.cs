using BluePrint.Domain.Common.Data;
using BluePrint.Domain.Exceptions;
using BluePrint.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BluePrint.WebApi.Helpers.Attributes;

public class ApiValidationFilterAttribute : ActionFilterAttribute
{
    #region Overrides of ActionFilterAttribute

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Select(s =>
                    new ErrorDetail(s.Key,
                        string.Join(", ", s.Value!.Errors.Select(d => d.ErrorMessage))))
                .ToList();
            var result = ResultModel<object>.Fail(new InvalidRequestException(info: errors));

            context.Result = new ObjectResult(result)
            {
                StatusCode = result.ErrorCode.ToStatusCode()
            };
            context.ModelState.Clear();
        }

        base.OnResultExecuting(context);
    }

    #endregion
}