namespace basic.wpf.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// An operation result, returned from <see cref="IOperationTimer.Begin"/>
    /// </summary>
    public class OperationResult : IOperationResult
    {
        /// <summary>
        /// Tracks if this instance has been disposed or not.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult" /> class.
        /// </summary>
        /// <param name="timer">The timer.</param>
        public OperationResult(OperationTimer timer)
        {
            this.Timer = timer;
            this.SplitTimes = new Dictionary<string, IOperationResult>();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OperationResult" /> class.
        /// </summary>
        ~OperationResult()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        /// <value>
        /// The timer.
        /// </value>
        public OperationTimer Timer { get; set; }

        /// <summary>
        /// Gets or sets the elapsed time this operation took to complete.
        /// </summary>
        public TimeSpan Elapsed { get; set; }

        /// <summary>
        /// Gets or sets the start point in milliseconds.
        /// </summary>
        /// <value>
        /// The start offset in milliseconds.
        /// </value>
        public long StartOffset { get; set; }

        /// <summary>
        /// Gets or sets the split times.
        /// </summary>
        /// <value>
        /// The split times.
        /// </value>
        public IDictionary<string, IOperationResult> SplitTimes { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <inheritdoc />
        public IOperationResult Begin(string operationName)
        {
            var split = this.Timer.Begin(operationName);
            this.SplitTimes.Add(operationName, split);
            return split;
        }

        /// <inheritdoc />
        public IOperationResult End(string operationName)
        {
            return this.End(this.SplitTimes[operationName]);
        }

        /// <inheritdoc />
        public IOperationResult End(IOperationResult operationResult)
        {
            operationResult.Dispose();
            return operationResult;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat(
                CultureInfo.CurrentCulture, "{0, -12}{1, 12:N0}{2}", "Name", "Time", Environment.NewLine);
            result.AppendFormat(
                CultureInfo.CurrentCulture, "{0, -12:N0}{1, 10:N0}ms", this.Name, this.Elapsed.TotalMilliseconds);

            return result.ToString();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.Timer != null)
                    {
                        this.Timer.End(this);
                    }
                }

                this.disposed = true;
            }
        }
    }
}