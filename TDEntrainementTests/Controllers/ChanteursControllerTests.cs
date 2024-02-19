using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDEntrainement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDEntrainement.Models.EntityFramework;

namespace TDEntrainement.Controllers.Tests
{
    
   

   

    [TestClass()]
    public class ChanteursControllerTests
    {
        private TDEntrainementContext _context;
        private ChanteursController _controller;

        
        public ChanteursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<TDEntrainementContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=ovemat;uid=ovemat;SearchPath=tdentrai;password=1gJeFH;");
            _context = new TDEntrainementContext(builder.Options);
            _controller = new TDEntrainementContext(_context);
        }
        [TestMethod()]
        public void ChanteursControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetChanteursTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetChanteurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutChanteurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostChanteurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteChanteurTest()
        {
            Assert.Fail();
        }
    }
}