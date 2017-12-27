
using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS content already exists exception.
    /// This exception MAY be returned by a repositiory in response to one or more CMIS service methods calls.
    /// The "Intent" ﬁeld indicates the intent of this exception.
    /// </summary>
    public class CmisContentAlreadyExistsException : CmisExceptionBase
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
                return "The operation attempts to set the content stream for a document that already has a content stream without explicitly specifying the \"overwriteFlag\" parameter.";
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
                return "contentAlreadyExists";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisContentAlreadyExistsException"/> class.
        /// </summary>
        public CmisContentAlreadyExistsException() { Code = 409L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisContentAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisContentAlreadyExistsException(string message) : base(message) { Code = 409L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisContentAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisContentAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { Code = 409L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisContentAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisContentAlreadyExistsException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 409L; }

        #endregion
    }
}
