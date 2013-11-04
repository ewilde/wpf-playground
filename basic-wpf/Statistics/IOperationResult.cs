namespace basic.wpf.Statistics
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The result of a timing operation
    /// </summary>
    public interface IOperationResult : IDisposable
    {
        /// <summary>
        /// Gets or sets the elapsed time this operation took to complete.
        /// </summary>
        TimeSpan Elapsed { get; set; }

        /// <summary>
        /// Gets or sets the start point in milliseconds.
        /// </summary>
        /// <value>
        /// The start offset in milliseconds.
        /// </value>
        long StartOffset { get; set; }

        /// <summary>
        /// Gets the split times associated with this instance.
        /// </summary>
        /// <value>
        /// The split times.
        /// </value>
        IDictionary<string, IOperationResult> SplitTimes { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <inheritdoc />
        IOperationResult Begin(string operationName);

        /// <inheritdoc />
        IOperationResult End(string operationName);

        /// <inheritdoc />
        IOperationResult End(IOperationResult operationResult);
    }
}