﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Filters
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);
            base.OnActionExecuting(context);
        }
    }
}
