using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// Represents errors that occur during a 4me web query execution.
    /// </summary>
    [Serializable]
    public class Sdk4meException : Exception
    {
        /// <summary>
        /// Gets additional details of the exception.
        /// </summary>
        public string DetailedMessage { get; private set; } = "";

        /// <summary>
        /// Initializes a new instance of the Sdk4meException class.
        /// </summary>
        public Sdk4meException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sdk4meException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public Sdk4meException(string message) :
            base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sdk4meException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public Sdk4meException(string message, Exception inner) : 
            base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sdk4meException class with a specified error message and additional details.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errors">A list with additional details.</param>
        public Sdk4meException(string message, List<List<string>> errors) : 
            base(message)
        {
            DetailedMessage = ParseDetails(errors);
        }

        /// <summary>
        /// Initializes a new instance of the Sdk4meException class with a specified error message, a reference to the inner exception that is the cause of this exception and additional details.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errors">A list with additional details.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public Sdk4meException(string message, List<List<string>> errors, Exception innerException) : 
            base(message, innerException)
        {
            DetailedMessage = ParseDetails(errors);
        }

        /// <summary>
        /// Parse the exception details to a string value.
        /// </summary>
        /// <param name="errors">A list with additional details.</param>
        /// <returns>A parsed value of the list with additional details.</returns>
        private string ParseDetails(List<List<string>> errors)
        {
            string retval = "";
            if (errors != null)
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    if (errors[i] != null)
                    {
                        for (int a = 0; a < errors[i].Count; a++)
                        {
                            retval += errors[i][a] + (a < errors[i].Count - 1 ? ": " : "");
                        }
                        retval += (i < errors.Count - 1 ? ". " : "");
                    }
                }
            }

            return retval;
        }
    }
}
