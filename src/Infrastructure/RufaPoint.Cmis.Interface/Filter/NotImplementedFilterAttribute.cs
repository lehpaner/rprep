
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RufaPoint.Cmis.Interface.Filter
{
    /// <summary>
    /// Not implemented filter attribute. 
    /// Handles <see cref="NotImplementedException"/> and returns a 501 HTTP status code (not implemented).
    /// </summary>
    public class NotImplementedFilterAttribute : ExceptionFilterAttribute
    {
		/// <summary>
		/// Runs when an unhandled exception occurs during the execution of an action.
		/// Handles only <see cref="NotImplementedException"/> and returns a 501 HTTP status code (not implemented).
		/// </summary>
		/// <param name="context">Exception context.</param>
		public override void OnException(ExceptionContext context)
        {
			if (context.Exception is NotImplementedException)
			{
                context.Result = new StatusCodeResult(StatusCodes.Status501NotImplemented);
			}
        }
    }
}
