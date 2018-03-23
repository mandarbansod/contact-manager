using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContactManager.Tests.Unit.Framework
{
    /// <summary>
    /// Contains methods for verifying conditions and object equality. 
    /// </summary>
    public static class Verify
    {
        /// <summary>
        /// Verify the expected string contains the actual string.
        /// </summary>
        /// <param name="expectedSubstring">Expected substring contained in actual string.</param>
        /// <param name="actualString">Actual string to compare</param>
        public static void Contains(string expectedSubstring, string actualString)
        {
            Xunit.Assert.Contains(expectedSubstring, actualString);
        }

        /// <summary>
        /// Verify that a string ends with a given string.
        /// </summary>
        /// <param name="expectedEndstring">Expected substring contained in actual string.</param>
        /// <param name="actualString">Actual string to compare</param>
        public static void EndsWith(string expectedEndstring, string actualString)
        {
            Xunit.Assert.EndsWith(expectedEndstring, actualString);
        }

        /// <summary>
        /// Verify that two objects are equal.
        /// Do not use this method for Json objects comparison.
        /// </summary>
        /// <param name="expected">Expected object</param>
        /// <param name="actual">Actual object</param>
        public static new void Equals(object expected, object actual)
        {
            Xunit.Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verify the expected value is equal to the actual value.
        /// </summary>
        /// <param name="expected">Expected integer.</param>
        /// <param name="actual">Actual integer.</param>
        public static void Equals(int expected, int actual)
        {
            Xunit.Assert.Equal(expected, actual);
        }

        /// <summary> 
        /// Verifying that two strings are not equal. 
        /// </summary> 
        /// <param name="expected">Expected string.</param> 
        /// <param name="actual">Actual string.</param> 
        public static void NotEqual(string expected, string actual)
        {
            Xunit.Assert.NotEqual(expected, actual);
        }

        /// <summary>
        /// Verify two objects are equal.
        /// </summary>
        /// <param name="expected">Expected object.</param>
        /// <param name="actual">Actual object.</param>
        public static void NotEqual(object expected, object actual)
        {
            Xunit.Assert.NotEqual(expected, actual);
        }

        /// <summary>
        /// Verify the actual value is greater than the expected value.
        /// </summary>
        /// <param name="expected">Expected integer.</param>
        /// <param name="actual">Actual integer.</param>
        public static void GreaterThan(int expected, int actual)
        {
            Xunit.Assert.True(actual > expected);
        }

        /// <summary>
        /// Verify the actual value is less than the expected value.
        /// </summary>
        /// <param name="expected">Expected integer.</param>
        /// <param name="actual">Actual integer.</param>
        public static void LessThan(int expected, int actual)
        {
            Xunit.Assert.True(actual < expected);
        }

        /// <summary>
        /// Verify the actual string matches the expected string.
        /// </summary>
        /// <param name="expected">Expected string.</param>
        /// <param name="actual">Actual string.</param>
        public static void Equals(string expected, string actual)
        {
            Xunit.Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verify the actual string matches the expected string ignoring the case of the letters in the string.
        /// </summary>
        /// <param name="expected">Expected string.</param>
        /// <param name="actual">Actual string.</param>
        public static void EqualsIgnoreCase(string expected, string actual)
        {
            Xunit.Assert.Equal(expected.ToLower(), actual.ToLower());
        }

        /// <summary>
        /// Verify the given string is empty.
        /// </summary>
        /// <param name="actual">Expected string to compare.</param>
        public static void IsEmpty(string actual)
        {
            Xunit.Assert.Equal(string.Empty, actual);
        }

        /// <summary>
        /// Verify the expected status string is equal to the actual status string.
        /// </summary>
        /// <param name="expectedStatus">Expected status HttpStatusCode.</param>
        /// <param name="actualStatus">Actual status HttpStatusCode from the API response.</param>
        public static void Status(HttpStatusCode expectedStatus, HttpStatusCode actualStatus)
        {
            Xunit.Assert.Equal(expectedStatus, actualStatus);
        }

        /// <summary>
        /// Verify the result is true.
        /// </summary>
        /// <param name="result">True when the result is true.</param>
        public static void True(bool result)
        {
            Xunit.Assert.True(result);
        }

        /// <summary>
        /// Verify the result is true. Displays appropriate user message when false.
        /// </summary>
        /// <param name="result">True when the result is true.</param>
        /// <param name="userMessage">The message to be shown when the condition is false.</param>
        public static void True(bool result, string userMessage)
        {
            Xunit.Assert.True(result, userMessage);
        }

        /// <summary>
        /// Verify the result is false.
        /// </summary>
        /// <param name="result">True when result is false.</param>
        public static void False(bool result)
        {
            Xunit.Assert.False(result);
        }

        /// <summary>
        /// Verify the given string is a valid GUID.
        /// </summary>
        /// <param name="guid">Globally Unique Identifier.</param>
        public static void IsGuid(string guid)
        {
            var isValid = false;

            try
            {
                Guid.Parse(guid);
                isValid = true;
            }
            catch (Exception ex)
            {
                // TODO: Add proper logging.
                Console.WriteLine($"The GUID {guid} is not the correct format. Exception {ex.Message}");
            }

            Xunit.Assert.True(isValid);
        }

        /// <summary>
        /// Verify the given string is not empty.
        /// </summary>
        /// <param name="actual">Expected string to compare.</param>
        public static void IsNotEmpty(string actual)
        {
            Xunit.Assert.NotEqual(string.Empty, actual);
        }

        /// <summary>
        /// Verify the expected string is null.
        /// </summary>
        /// <param name="actual">Expected value to check for null.</param>
        public static void IsNull(object actual)
        {
            Xunit.Assert.Null(actual);
        }

        /// <summary>
        /// Verify the expected string is not null.
        /// </summary>
        /// <param name="actual">Expected value to not be null.</param>
        public static void IsNotNull(object actual)
        {
            Xunit.Assert.NotNull(actual);
        }

        /// <summary>
        /// Verify the expected string is not null and not empty.
        /// </summary>
        /// <param name="actual">Expected value to not be null.</param>
        public static void IsNotNullOrEmpty(object actual)
        {
            Xunit.Assert.NotNull(actual);
            Xunit.Assert.NotEqual(string.Empty, actual);
        }
    }
}