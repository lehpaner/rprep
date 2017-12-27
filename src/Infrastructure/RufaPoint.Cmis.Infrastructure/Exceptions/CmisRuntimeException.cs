
using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS runtime exception.
    /// This exception MAY be returned by a repository in response to ANY CMIS service method call.
    /// The "Cause" ﬁeld indicates the circumstances under which a repository SHOULD return this exception.
    /// </summary>
    public class CmisRuntimeException : CmisExceptionBase
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
                return "Any other cause not expressible by another CMIS exception.";
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
                return "runtime";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisRuntimeException"/> class.
        /// </summary>
        public CmisRuntimeException() { Code = 500L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisRuntimeException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisRuntimeException(string message) : base(message) {Code = 500L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisRuntimeException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisRuntimeException(string message, Exception innerException) : base(message, innerException) { Code = 500L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisRuntimeException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisRuntimeException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 500L; }

        #endregion
    }
}