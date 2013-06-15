namespace DsmWebApi.Core
{
    using System;

    /// <summary>
    /// The exception that is thrown when an error occurs in a DSM API.
    /// </summary>
    public class DsmApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiException"/> class.
        /// </summary>
        public DsmApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code returned by the DSM API.</param>
        public DsmApiException(int errorCode)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DsmApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="errorCode">The error code returned by the DSM API.</param>
        /// <param name="message">The message that describes the error.</param>
        public DsmApiException(int errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public DsmApiException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="errorCode">The error code returned by the DSM API.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public DsmApiException(int errorCode, string message, Exception inner)
            : base(message, inner)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code returned by the DSM API.
        /// </summary>
        public int ErrorCode { get; private set; }
    }
}
