using System;
using System.Collections.Generic;
using System.Text;

namespace TopTransactions
{
    public class TransactionsProcessor
    {
        private readonly int _topCount;
        
        public List<Transaction> TopTransactions { get; set; }
        public event EventHandler TopTransactionsUpdated;

        public TransactionsProcessor(int topCount = 10)
        {
            _topCount = topCount;
            TopTransactions = new List<Transaction>();
        }

        public void UpdateTop(List<Transaction> newTransactions)
        {
            var updated = false;
            foreach(var newTransaction in newTransactions)
            {
                var newTransactionUsed = false;
                for (var i = 0; i < TopTransactions.Count; i++)
                {
                    if (newTransaction.Price > TopTransactions[i].Price)
                    {
                        TopTransactions.Insert(i, newTransaction);
                        if(TopTransactions.Count > _topCount)
                        {
                            TopTransactions.RemoveAt(TopTransactions.Count - 1);
                        }

                        newTransactionUsed = true;
                        updated = true;
                        break;
                    }
                }

                if (!newTransactionUsed && TopTransactions.Count < _topCount)
                {
                    TopTransactions.Add(newTransaction);
                }
            }

            if(updated)
            {
                TopTransactionsUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
