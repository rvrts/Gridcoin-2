using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridcoin.BlockExplorer;
using Gridcoin.BlockExplorer.Web.Asia;
using Gridcoin.BlockExplorer.Web.Asia.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gridcoin.BlockExplorerApiClient.Tests
{
    [TestClass]
    public class BlockExplorerTests
    {
        [TestMethod]
        public void GetBlockByIndex()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var asiaRestClient = new AsiaBlockExplorerRestClient(uri);
            var explorer = new AsiaBlockExplorer(asiaRestClient);

            var blockIndex = new BlockIndex(0);
            var block = explorer.GetBlock(blockIndex);
        }

        [TestMethod]
        public void GetBlockByHash()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var asiaRestClient = new AsiaBlockExplorerRestClient(uri);
            var explorer = new AsiaBlockExplorer(asiaRestClient);

            var blockHash = new BlockHash("646c7cc5afe68330469ee0ca0519e434f0505dbb152dd1c7c6b119e06a242c2b");
            var block = explorer.GetBlock(blockHash);
        }
        [TestMethod]
        public void GetPreviousBlock()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var asiaRestClient = new AsiaBlockExplorerRestClient(uri);
            var explorer = new AsiaBlockExplorer(asiaRestClient);

            var blockIndex = new BlockIndex(1);
            var block = explorer.GetBlock(blockIndex);

            var nextBlock = block.GetPreviousBlock();
        }
        [TestMethod]
        public void GetNextBlock()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var asiaRestClient = new AsiaBlockExplorerRestClient(uri);
            var explorer = new AsiaBlockExplorer(asiaRestClient);

            var blockHash = new BlockHash("646c7cc5afe68330469ee0ca0519e434f0505dbb152dd1c7c6b119e06a242c2b");
            var block = explorer.GetBlock(blockHash);

            var nextBlock = block.GetNextBlock();
        }

        [TestMethod]
        public void GetTransactionByHash()
        {
            var uri = new Uri("http://explorer.gridcoin.asia");
            var asiaRestClient = new AsiaBlockExplorerRestClient(uri);
            var explorer = new AsiaBlockExplorer(asiaRestClient);

            var transactionHash = new TransactionHash("35b8c4fb12bd687c6c8ed6d04eabe1fe99faa2554ad06393d3e4e4230c2771a0");
            var transaction = explorer.GetTransaction(transactionHash);
        }
    }
}
