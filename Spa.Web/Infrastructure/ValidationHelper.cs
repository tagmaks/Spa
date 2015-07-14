using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using GenericLibsBase;

namespace Spa.Web.Infrastructure
{
    public static class ValidationHelper
    {
        public static void CopyErrorsToModelState(this ISuccessOrErrors errorHolder, ModelStateDictionary modelState)
        {
            if (errorHolder.IsValid) return;

            foreach (var error in errorHolder.Errors)
                modelState.AddModelError("", error.ErrorMessage);
        }
    }
}