using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace PeriodicLoopCon
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            CancelKeyPress += (_, args) => 
            {
                cts.Cancel();
                cts.Dispose();
                args.Cancel = true;
            };

            WriteLine("Starting loop. Ctrl-C to stop.");
            return RunLoop(cts.Token);
        }

        internal static async Task RunLoop(CancellationToken cancellation)
        {
            var spinner = new []{'|', '/', '-', '+', '\\', '*'};
            int spinIdx = 0;
            try
            {
                var row = CursorTop;
                while (!cancellation.IsCancellationRequested)
                {
                    spinIdx = spinIdx >= spinner.Length ? 0 : spinIdx;
                    await Task.Delay(1000, cancellation);

                    SetCursorPosition(1,row);
                    Write($"Loop! On thread: {Thread.CurrentThread.ManagedThreadId} {spinner[spinIdx++]} ");
                }
            }
            catch (TaskCanceledException tex) { WriteLine(tex.ToString()); }
            catch (Exception ex)              { WriteLine(ex.ToString());  }
        }
    }
}
