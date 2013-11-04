namespace basic.wpf.Statistics
{
    using System;

    using StructureMap;

    /// <summary>
    /// Records length of time a logical operation takes
    /// </summary>
    [PluginFamily(IsSingleton = true)]
    public interface IOperationTimer
    {
        /// <summary>
        /// Begins the timing a new operation.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <returns>Returns the operation result, note this implements <see cref="IDisposable"/> so you can wrap in a using. Calling dispose implicitly ends the operation.</returns>
        IOperationResult Begin(string operationName);

        /// <summary>
        /// Ends the specified operation being timed.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <returns>Returns the operation result</returns>
        IOperationResult End(string operationName);

        /// <summary>
        /// Ends the specified operation being timed.
        /// </summary>
        /// <param name="operationResult">Operation result.</param>
        /// <returns>Returns the operation result</returns>
        IOperationResult End(IOperationResult operationResult);
    }
}