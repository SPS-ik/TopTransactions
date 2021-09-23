using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.Json;
using TopTransactions;

namespace TopTransactionsTest
{
    [TestClass]
    public class TransactionProcessorTest
    {
        [TestMethod]
        public void TopTransactionTest()
        {
            var processor = new TransactionsProcessor(3);

            var newTransactions = new List<Transaction>
            {
                // price: 2
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":2,\"price_str\":\"2\"}"
                    ),
                // price: 3
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":3,\"price_str\":\"3\"}"
                    ),
                // price: 1
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":1,\"price_str\":\"1\"}"
                    ),
                // price: 4
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":4,\"price_str\":\"4\"}"
                    ),
            };

            var expTopTransactions = new List<Transaction>
            {
                // price: 4
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":4,\"price_str\":\"4\"}"
                    ),
                // price: 3
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":3,\"price_str\":\"3\"}"
                    ),
                // price: 2
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":2,\"price_str\":\"2\"}"
                    ),
            };

            processor.UpdateTop(newTransactions);

            CollectionAssert.AreEqual(expTopTransactions, processor.TopTransactions);
        }

        [TestMethod]
        public void TopTransaction_NotEnoughData_Test()
        {
            var processor = new TransactionsProcessor(5);

            var newTransactions = new List<Transaction>
            {
                // price: 2
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":2,\"price_str\":\"2\"}"
                    ),
                // price: 3
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":3,\"price_str\":\"3\"}"
                    ),
                // price: 1
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":1,\"price_str\":\"1\"}"
                    ),
                // price: 4
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":4,\"price_str\":\"4\"}"
                    ),
            };

            var expTopTransactions = new List<Transaction>
            {
                // price: 4
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":4,\"price_str\":\"4\"}"
                    ),
                // price: 3
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":3,\"price_str\":\"3\"}"
                    ),
                // price: 2
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":2,\"price_str\":\"2\"}"
                    ),
                // price: 1
                JsonSerializer.Deserialize<Transaction>(
                    "{\"id\":1406187386294275,\"id_str\":\"1406187386294275\",\"order_type\":1,\"datetime\":\"1632142442\",\"microtimestamp\":\"1632142442392000\",\"amount\":0.04626521,\"amount_str\":\"0.04626521\",\"price\":1,\"price_str\":\"1\"}"
                    ),
            };

            processor.UpdateTop(newTransactions);

            CollectionAssert.AreEqual(expTopTransactions, processor.TopTransactions);
        }
    }
}
