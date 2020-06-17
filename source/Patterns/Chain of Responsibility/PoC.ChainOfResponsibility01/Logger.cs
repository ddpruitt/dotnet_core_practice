namespace PoC.ChainOfResponsibility01
{
    /// <summary>
    /// Abstract Handler in chain of responsibility pattern.
    /// </summary>
    public abstract class Logger
    {
        protected LogLevel LogMask;

        // The next Handler in the chain
        protected Logger Next;

        protected Logger(LogLevel mask)
        {
            this.LogMask = mask;
        }

        /// <summary>
        /// Sets the Next logger to make a list/chain of Handlers.
        /// </summary>
        public Logger SetNext(Logger nextlogger)
        {
            Logger lastLogger = this;

            while (lastLogger.Next != null)
            {
                lastLogger = lastLogger.Next;
            }

            lastLogger.Next = nextlogger;
            return this;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & LogMask) != 0) // True only if any of the logMask bits are set in severity
            {
                WriteMessage(msg);
            }

            Next?.Message(msg, severity);
        }

        protected abstract void WriteMessage(string msg);
    }
}