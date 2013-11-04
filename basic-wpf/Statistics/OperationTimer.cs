// -----------------------------------------------------------------------
// <copyright file="Class1.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace basic.wpf.Statistics
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Records length of time a logical operation takes
    /// </summary>
    public class OperationTimer : IOperationTimer
    {
        /// <summary>
        /// The stopwatch used to record the length of operations.
        /// </summary>
        private readonly Stopwatch stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationTimer" /> class.
        /// </summary>
        public OperationTimer()
        {
            this.stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Begins the timing a new operation.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <returns>
        /// Returns the operation result, note this implements <see cref="IDisposable" /> so you can wrap in a using. Calling dispose implicitly ends the operation.
        /// </returns>
        public IOperationResult Begin(string operationName)
        {
            if (!this.stopwatch.IsRunning)
            {
                this.stopwatch.Start();
            }

            var result = new OperationResult(this)
            {
                Name = operationName,
                StartOffset = this.stopwatch.ElapsedMilliseconds
            };

            return result;
        }

        /// <summary>
        /// Ends the specified operation being timed.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <returns>
        /// Returns the operation result
        /// </returns>
        public IOperationResult End(string operationName)
        {
            return null;
        }

        /// <summary>
        /// Ends the specified operation being timed.
        /// </summary>
        /// <param name="operationResult">Operation result.</param>
        /// <returns>
        /// Returns the operation result
        /// </returns>
        public IOperationResult End(IOperationResult operationResult)
        {
            operationResult.Elapsed = TimeSpan.FromMilliseconds(this.stopwatch.ElapsedMilliseconds - operationResult.StartOffset);
            return operationResult;
        }
    }
}