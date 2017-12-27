
using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS permission denied exception.
    /// This exception MAY be returned by a repository in response to ANY CMIS service method call.
    /// The "Cause" ﬁeld indicates the circumstances under which a repository SHOULD return this exception.
    /// </summary>
    public class CmisPermissionDeniedException : CmisExceptionBase
    {
        #region Properties

        /// <summary>
        /// Gets the exception cause.
        /// </summary>
        /// <value>The exception cause.</value>
        public override string Cause
        {
            get
            {
                return "The caller of the service method does not have suﬃcient permissions to perform the operation.";
            }
        }

        /// <summary>
        /// Gets the CMIS exception name.
        /// </summary>
        /// <value>The CMIS exception name.</value>
        public override string Name
        {
            get
            {
                return "permissionDenied";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisPermissionDeniedException"/> class.
        /// </summary>
        public CmisPermissionDeniedException() { Code = 403L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisPermissionDeniedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisPermissionDeniedException(string message) : base(message) { Code = 403L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisPermissionDeniedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisPermissionDeniedException(string message, Exception innerException) : base(message, innerException) { Code = 403L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisPermissionDeniedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisPermissionDeniedException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 403L; }

        #endregion
    }
}