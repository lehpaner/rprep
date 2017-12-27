using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace RufaPoint.Cmis.Interface.Filter
{
    /// <summary>
    /// CMIS exception filter attribute. Handles all unhandled exceptions and returns CMIS compliant excpetions.
    /// </summary>
    public class CmisExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Fields
        readonly IHostingEnvironment _hostingEnvironment;
        readonly IModelMetadataProvider _modelMetadataProvider;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Interface.CmisExceptionFilterAttribute"/> class.
        /// </summary>
        /// <param name="hostingEnvironment">Hosting environment.</param>
        /// <param name="modelMetadataProvider">Model metadata provider.</param>
        public CmisExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment, 
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

		/// <summary>
		/// Runs when an unhandled exception occurs during the execution of an action.
		/// </summary>
		/// <param name="context">Exception context.</param>
		//public override void OnException(ExecutionContext context)
  //      {
  //          if (!_hostingEnvironment.IsDevelopment())
  //          {
  //              return;
  //          }
  //          context.Result = new BadRequestObjectResult(context.ModelState);
  //      }
        public override void OnException(ExceptionContext context)
        {
            if(_hostingEnvironment.IsDevelopment())
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                return;
            }
            base.OnException(context);

        }
    }
}
