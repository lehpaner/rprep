﻿

using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS filter not valid exception.
    /// This exception MAY be returned by a repositiory in response to one or more CMIS service methods calls.
    /// The "Intent" ﬁeld indicates the intent of this exception.
    /// </summary>
    public class CmisFilterNotValidException : CmisExceptionBase
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
                return "The property ﬁlter or rendition ﬁlter input to the operation is not valid. The repository SHOULD NOT throw this expection if the ﬁlter syntax is correct but one or more elements in the ﬁlter is unknown. Unknown elements SHOULD be ignored.";
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
                return "ﬁlterNotValid";
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisFilterNotValidException"/> class.
        /// </summary>
        public CmisFilterNotValidException() { Code = 400L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisFilterNotValidException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CmisFilterNotValidException(string message) : base(message) { Code = 400L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisFilterNotValidException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CmisFilterNotValidException(string message, Exception innerException) : base(message, innerException) { Code = 400L; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisFilterNotValidException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Exception code.</param>
        /// <param name="content">Exception content.</param>
        public CmisFilterNotValidException(string message, Exception innerException, long? code, string content) : base(message, innerException, code, content) { Code = code ?? 400L; }

        #endregion
    }
}