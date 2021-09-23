using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace TopTransactions
{
    public class TransactionsConsumer
    {
        private ConsumerConfig _config;
        private bool _started;
        private bool _canceled;

        TransactionsProcessor _processor;

        public TransactionsConsumer(TransactionsProcessor processor)
        {
            _processor = processor;

            _config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "Group1",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };
        }

        public void Start(IEnumerable<string> topics)
        {
            if (_started)
            {
                return;
            }

            _started = true;

            using (var consumer = new ConsumerBuilder<Ignore, string>(_config).Build())
            {
                consumer.Subscribe(topics);

                while (!_canceled)
                {
                    var consumeResult = consumer.Consume();

                    var transactionDto = JsonSerializer.Deserialize<TransactionDto>(consumeResult.Message.Value);

                    _processor.UpdateTop(new List<Transaction> { transactionDto.Data });
                    //Console.WriteLine(transactionDto.Data);

                    consumer.Commit();
                }

                consumer.Close();
                _started = false;
            }
        }

        public void Stop()
        {
            _canceled = true;
        }
    }
}
