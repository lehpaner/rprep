
using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS versioning exception.
    /// This exception MAY be returned by a repositiory in response to one or more CMIS service methods calls.
    /// The "Intent" ﬁeld indicates the intent of this exception.
    /// </summary>
    public class CmisVersioningException : CmisExceptionBase
    {
        #region Properties

        /// <summary>
        /// Gets the exception intent.
        /// </summary>
        /// <value>The exception intent.</value>
        public override string Intent
        {
            get
            {
                return "The operation is attempting to perform an action on a non-current version of a document that cannot be performed on a non-current version.";
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
                return "versioning";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisVersioningException"/> class.
        /// </summary>
        public CmisVersioningException() { Code = 409L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisVersioningException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisVersioningException(string message) : base(message) { Code = 409L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisVersioningException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisVersioningException(string message, Exception innerException) : base(message, innerException) { Code = 409L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisVersioningException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisVersioningException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 409L; }

        #endregion
    }
}