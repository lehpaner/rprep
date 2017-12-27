

using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS not supported exception.
    /// This exception MAY be returned by a repository in response to ANY CMIS service method call.
    /// The "Cause" ﬁeld indicates the circumstances under which a repository SHOULD return this exception.
    /// </summary>
    public class CmisNotSupportedException : CmisExceptionBase
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
                return "The service method invoked requires an optional capability not supported by the repository.";
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
                return "notSupported";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisNotSupportedException"/> class.
        /// </summary>
        public CmisNotSupportedException() { Code = 405L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisNotSupportedException(string message) : base(message) { Code = 405L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisNotSupportedException(string message, Exception innerException) : base(message, innerException) { Code = 405L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisNotSupportedException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 405L; }

        #endregion
    }
}