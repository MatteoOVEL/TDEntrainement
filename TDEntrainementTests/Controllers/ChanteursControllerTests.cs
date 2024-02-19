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
            _context = new (builder.Options);
            _controller = new (_context);
        }
        [TestMethod]
        public void GetSerie_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            Chanteur chanteur = new Chanteur
            {
                Idchanteur = 1,
                Nomchanteur = "oui",
            };

            // Act
            var result = _controller.GetChanteur(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ActionResult<Chanteur>), "Pas un ActionResult");

            var actionResult = result.Result as ActionResult<Chanteur>;

            // Assert
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.IsInstanceOfType(actionResult.Value, typeof(Chanteur), "Pas une serie");
            Assert.AreEqual(chanteur, (Chanteur)actionResult.Value, "Series pas identiques");
        }
    }
}