//-----------------------------------------------------------------------
// <copyright file="FtpLogExtensions.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;

namespace FubarDev.FtpServer
{
    /// <summary>
    /// Extension methods for logging <see cref="FtpCommand"/> and <see cref="FtpResponse"/> objects.
    /// </summary>
    internal static class FtpLogExtensions
    {
        /// <summary>
        /// Logs a trace message with the data of the <see cref="FtpCommand"/>.
        /// </summary>
        /// <param name="log">The <see cref="ILogger"/> to use.</param>
        /// <param name="command">The <see cref="FtpCommand"/> to log.</param>
        public static void Command([NotNull] this ILogger log, [NotNull] FtpCommand command)
        {
            var arguments = string.Equals(command.Name, "PASS", System.StringComparison.OrdinalIgnoreCase)
                ? @"**************** (password omitted)"
                : command.Argument;
            log.LogDebug("{name} {arguments}", command.Name, arguments);
        }

        /// <summary>
        /// Logs a debug message with the data of the <see cref="FtpResponse"/>.
        /// </summary>
        /// <param name="log">The <see cref="ILogger"/> to use.</param>
        /// <param name="response">The <see cref="FtpResponse"/> to log.</param>
        public static void Debug([NotNull] this ILogger log, [NotNull] FtpResponse response)
        {
            log.LogDebug("{code} {message}", response.Code, response.Message);
        }

        /// <summary>
        /// Logs a info message with the data of the <see cref="FtpResponse"/>.
        /// </summary>
        /// <param name="log">The <see cref="ILogger"/> to use.</param>
        /// <param name="response">The <see cref="FtpResponse"/> to log.</param>
        public static void Info([NotNull] this ILogger log, [NotNull] FtpResponse response)
        {
            log.LogInformation("{code} {message}", response.Code, response.Message);
        }

        /// <summary>
        /// Logs a warning message with the data of the <see cref="FtpResponse"/>.
        /// </summary>
        /// <param name="log">The <see cref="ILogger"/> to use.</param>
        /// <param name="response">The <see cref="FtpResponse"/> to log.</param>
        public static void Warn([NotNull] this ILogger log, [NotNull] FtpResponse response)
        {
            log.LogWarning("{code} {message}", response.Code, response.Message);
        }

        /// <summary>
        /// Logs an error message with the data of the <see cref="FtpResponse"/>.
        /// </summary>
        /// <param name="log">The <see cref="ILogger"/> to use.</param>
        /// <param name="response">The <see cref="FtpResponse"/> to log.</param>
        public static void Error([NotNull] this ILogger log, [NotNull] FtpResponse response)
        {
            log.LogError("{code} {message}", response.Code, response.Message);
        }

        /// <summary>
        /// Logs a message with the data of the <see cref="FtpResponse"/>.
        /// </summary>
        /// <param name="log">The <see cref="ILogger"/> to use.</param>
        /// <param name="response">The <see cref="FtpResponse"/> to log.</param>
        /// <remarks>
        /// It logs either a trace, debug, or warning message depending on the
        /// <see cref="FtpResponse.Code"/>.
        /// </remarks>
        public static void Log([NotNull] this ILogger log, [NotNull] FtpResponse response)
        {
            if (response.Code >= 200 && response.Code < 300)
            {
                log.Debug(response);
            }
            else if (response.Code >= 300 && response.Code < 400)
            {
                log.Info(response);
            }
            else if (response.Code < 200)
            {
                log.Debug(response);
            }
            else
            {
                log.Warn(response);
            }
        }

#if NETSTANDARD1_3
        internal static void LogError(
            [NotNull] this ILogger log,
            System.Exception exception,
            string message,
            params object[] args)
        {
            log.LogError(0, exception, message, args);
        }

        internal static void LogWarning(
            [NotNull] this ILogger log,
            System.Exception exception,
            string message,
            params object[] args)
        {
            log.LogWarning(0, exception, message, args);
        }

        internal static void LogCritical(
            [NotNull] this ILogger log,
            System.Exception exception,
            string message,
            params object[] args)
        {
            log.LogCritical(0, exception, message, args);
        }
#endif
    }
}
