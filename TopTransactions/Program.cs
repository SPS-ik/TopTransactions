using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TopTransactions
{
    class Program
    {
        private static TransactionsProcessor _processor;

        static void Main(string[] args)
        {
            _processor = new TransactionsProcessor();
            _processor.TopTransactionsUpdated += OnTopTransactionsUpdated;

            var consumer = new TransactionsConsumer(_processor);

            var thread = new Thread(() => consumer.Start(new List<string> { "BcToUsdTransactions" }));
            thread.Start();
            //Task.Run(() => consumer.Start(new List<string> { "Transactions" }));

            Console.ReadKey(true);
        }

        private static void OnTopTransactionsUpdated(object sender, EventArgs e)
        {
            PrintTopTransactions();
        }

        private static void PrintTopTransactions()
        {
            Console.WriteLine($"{DateTime.Now} - Top {_processor.TopTransactions.Count} BC to USD Transactions:");
            var i = 0;
            foreach(var transaction in _processor.TopTransactions)
            {
                Console.WriteLine($"{++i} - {transaction}");
            }

            Console.WriteLine();
        }
    }
}
