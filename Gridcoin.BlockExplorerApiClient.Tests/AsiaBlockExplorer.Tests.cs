using System;
using Gridcoin.BlockExplorer;
using Gridcoin.BlockExplorer.Web.Asia;
using Gridcoin.BlockExplorer.Web.Asia.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gridcoin.BlockExplorerApiClient.Tests
{
    [TestClass]
    public class AsiaBlockExplorerTests
    {
        [TestMethod]
        public void GetDifficulty()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var explorer = new AsiaBlockExplorerRestClient(uri);
            var result = explorer.GetCurrentDifficulty();
        }

        [TestMethod]
        public void GetBalance()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var explorer = new AsiaBlockExplorerRestClient(uri);
            var address = new GridcoinAddress("S67nL4vELWwdDVzjgtEP4MxryarTZ9a8GB");
            var result = explorer.GetBalance(address);
        }

        [TestMethod]
        public void GetTransaction()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var explorer = new AsiaBlockExplorerRestClient(uri);
            var transaction = new TransactionHash("35b8c4fb12bd687c6c8ed6d04eabe1fe99faa2554ad06393d3e4e4230c2771a0");
            var result = explorer.GetTransaction(transaction);
        }

        [TestMethod]
        public void GetBlockHash()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var explorer = new AsiaBlockExplorerRestClient(uri);
            var index = new BlockIndex(0);
            var result = explorer.GetBlockHash(index);
        }

        [TestMethod]
        public void GetBlock()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var explorer = new AsiaBlockExplorerRestClient(uri);
            var block = new BlockHash("646c7cc5afe68330469ee0ca0519e434f0505dbb152dd1c7c6b119e06a242c2b");
            var result = explorer.GetBlock(block);
        }
    }
}
