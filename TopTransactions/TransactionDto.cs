using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TopTransactions
{
    class TransactionDto
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("data")]
        public Transaction Data { get; set; }
    }
}
