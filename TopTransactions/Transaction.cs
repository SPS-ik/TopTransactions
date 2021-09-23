using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TopTransactions
{
    public class Transaction
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("id_str")]
        public string IdStr { get; set; }

        [JsonPropertyName("order_type")]
        public int OrderType { get; set; }

        [JsonPropertyName("datetime")]
        public string DateTime { get; set; }

        [JsonPropertyName("microtimestamp")]
        public string MicroTimestamp { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("amount_str")]
        public string AmountStr { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("price_str")]
        public string PriceStr { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                   Id == transaction.Id &&
                   IdStr == transaction.IdStr &&
                   OrderType == transaction.OrderType &&
                   DateTime == transaction.DateTime &&
                   MicroTimestamp == transaction.MicroTimestamp &&
                   Amount == transaction.Amount &&
                   AmountStr == transaction.AmountStr &&
                   Price == transaction.Price &&
                   PriceStr == transaction.PriceStr;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdStr);
            hash.Add(OrderType);
            hash.Add(DateTime);
            hash.Add(MicroTimestamp);
            hash.Add(Amount);
            hash.Add(AmountStr);
            hash.Add(Price);
            hash.Add(PriceStr);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
