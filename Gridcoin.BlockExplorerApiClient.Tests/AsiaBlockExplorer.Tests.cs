using System;
using Gridcoin.BlockExplorerApiClient.Explorers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gridcoin.BlockExplorerApiClient.Tests
{
    [TestClass]
    public class AsiaBlockExplorerTests
    {
        [TestMethod]
        public void GetDifficulty()
        {
            var explorer = new AsiaBlockExplorer();
            var result = explorer.GetCurrentDifficulty();
        }

        [TestMethod]
        public void GetBalance()
        {
            var explorer = new AsiaBlockExplorer();
            var address = new GridcoinAddress("S67nL4vELWwdDVzjgtEP4MxryarTZ9a8GB");
            var result = explorer.GetBalance(address);
        }

        [TestMethod]
        public void GetTransaction()
        {
            var explorer = new AsiaBlockExplorer();
            var transaction = new GridcoinTransactionId("35b8c4fb12bd687c6c8ed6d04eabe1fe99faa2554ad06393d3e4e4230c2771a0");
            var result = explorer.GetTransaction(transaction);
        }

        [TestMethod]
        public void GetBlock()
        {
            var explorer = new AsiaBlockExplorer();
            var block = new BlockHash("646c7cc5afe68330469ee0ca0519e434f0505dbb152dd1c7c6b119e06a242c2b");
            var result = explorer.GetBlock(block);
        }
    }
}
