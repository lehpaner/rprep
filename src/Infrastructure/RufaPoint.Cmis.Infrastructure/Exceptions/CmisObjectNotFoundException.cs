

using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// Cmis object not found exception.
    /// This exception MAY be returned by a repository in response to ANY CMIS service method call.
    /// The "Cause" ﬁeld indicates the circumstances under which a repository SHOULD return this exception.
    /// </summary>
    public class CmisObjectNotFoundException : CmisExceptionBase
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
                return "The service call has speciﬁed an object, an object-type or a repository that does not exist.";
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
                return "objectNotFound";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisObjectNotFoundException"/> class.
        /// </summary>
        public CmisObjectNotFoundException() { Code = 404L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisObjectNotFoundException(string message) : base(message) { Code = 404L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { Code = 404L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisObjectNotFoundException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 404L; }

        #endregion
    }
}