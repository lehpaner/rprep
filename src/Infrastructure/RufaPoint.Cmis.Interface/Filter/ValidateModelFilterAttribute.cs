//
// ValidateModelFilterAttribute.cs
//


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RufaPoint.Cmis.Interface.Filter
{
	/// <summary>
	/// Validate model action filter attribute. 
    /// Validates the <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary"/>.
	/// </summary>
	public class ValidateModelFilterAttribute : ActionFilterAttribute
    {
		/// <summary>
		/// Validates the Validates the <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary"/> of the <paramref name="context"/>.
		/// </summary>
		/// <param name="context">The <see cref="ActionExecutingContext"/> of the executing action.</param>
		public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
