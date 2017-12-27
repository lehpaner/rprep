
using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS stream not supported exception.
    /// This exception MAY be returned by a repositiory in response to one or more CMIS service methods calls.
    /// The "Intent" ﬁeld indicates the intent of this exception.
    /// </summary>
    public class CmisStreamNotSupportedException : CmisExceptionBase
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
                return "The operation is attempting to get or set a content stream for a document whose object-type speciﬁes that a content stream is not allowed for document’s of that type.";
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
                return "streamNotSupported";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisStreamNotSupportedException"/> class.
        /// </summary>
        public CmisStreamNotSupportedException() { Code = 403L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisStreamNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisStreamNotSupportedException(string message) : base(message) { Code = 403L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisStreamNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisStreamNotSupportedException(string message, Exception innerException) : base(message, innerException) { Code = 403L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisStreamNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisStreamNotSupportedException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 403L; }

        #endregion
    }
}