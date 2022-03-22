using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Sdk4me
{
    /// <summary>
    /// Represent errors that occur during 4me execution.
    /// </summary>
    public class Sdk4meException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Sdk4meException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public Sdk4meException(string message) :
            base(GetResultFromResponseMessage(message))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sdk4meException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public Sdk4meException(string message, Exception inner) :
            base(GetResultFromResponseMessage(message), inner)
        {
        }

        /// <summary>
        /// Returns the message value from a json formatted string.
        /// </summary>
        /// <param name="message">The json formatted string containing a message property.</param>
        /// <returns>The message value from the json formatted string; or the message itself.</returns>
        private static string GetResultFromResponseMessage(string message)
        {
            try
            {
                string result = string.Empty;
                JObject data = JObject.Parse(message);

                if (data.ContainsKey("message"))
                    result = data["message"].Value<string>();

                if (data.ContainsKey("errors"))
                {
                    foreach (JToken token in data["errors"])
                        result += $". {token[1]} ({token[0]})";
                }

                return string.IsNullOrWhiteSpace(result) ? data.ToString(Formatting.Indented) : result + ".";
            }
            catch
            {
                return message;
            }
        }
    }
}
