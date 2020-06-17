using System;

namespace PoC.ChainOfResponsibility01
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Writing to console: " + msg);
        }
    }

    public class EmailLogger : Logger
    {
        public EmailLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            // Placeholder for mail send logic, usually the email configurations are saved in config file.
            Console.WriteLine("Sending via email: " + msg);
        }
    }

    class FileLogger : Logger
    {
        public FileLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            // Placeholder for File writing logic
            Console.WriteLine("Writing to Log File: " + msg);
        }
    }
}
 
/* Output
Writing to console: Entering function ProcessOrder().
Writing to console: Order record retrieved.
Writing to console: Customer Address details missing in Branch DataBase.
Writing to Log File: Customer Address details missing in Branch DataBase.
Writing to console: Customer Address details missing in Organization DataBase.
Writing to Log File: Customer Address details missing in Organization DataBase.
Writing to console: Unable to Process Order ORD1 Dated D1 For Customer C1.
Sending via email: Unable to Process Order ORD1 Dated D1 For Customer C1.
Writing to console: Order Dispatched.
Sending via email: Order Dispatched.
*/

