
using System;
namespace RufaPoint.Cmis.Infrastructure.Exceptions
{
    /// <summary>
    /// CMIS exception base class. Abstract base class for all CMIS exceptions.
    /// </summary>
    public abstract class CmisExceptionBase : Exception
    {
        #region Properties

        /// <summary>
        /// Gets or sets the exception cause.
        /// </summary>
        /// <value>The exception cause.</value>
        public virtual string Cause { get; protected set; }

        /// <summary>
        /// Gets or sets the CMIS exception code.
        /// </summary>
        /// <value>The code.</value>
        public long? Code { get; protected set; }

        /// <summary>
        /// Gets or sets the content of the exception.
        /// </summary>
        /// <value>The content of the exception.</value>
        public string Content { get; protected set; }

        /// <summary>
        /// Gets or sets the excpetion intent.
        /// </summary>
        /// <value>The exception intent.</value>
        public virtual string Intent { get; protected set; }

        /// <summary>
        /// Gets or sets the CMIS exception name.
        /// </summary>
        /// <value>The CMIS exception name.</value>
        public virtual string Name { get; protected set; }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisExceptionBase"/> class.
        /// </summary>
        protected CmisExceptionBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisExceptionBase"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        protected CmisExceptionBase(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisExceptionBase"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        protected CmisExceptionBase(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisExceptionBase"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">CMIS exception code.</param>
        /// <param name="content">Exception content.</param>
        protected CmisExceptionBase(string message, Exception innerException, long? code, string content) : this(message, innerException)
        {
            Content = content;
            Code = code;
        }

        #endregion
    }
}