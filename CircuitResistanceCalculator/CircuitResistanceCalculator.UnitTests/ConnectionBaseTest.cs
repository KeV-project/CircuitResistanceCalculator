using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace CircuitResistanceCalculator.UnitTests
{
	[TestFixture]
	class ConnectionBaseTest
	{

		[Test (Description = "Позитивный тест индексатора Nodes")]
		public void TestIndexerGet_CorrectValue()
		{

		}

		[Test(Description = "Позитивный тест метода AddNode " +
			"для добавления узла типа элемент")]
		public void TestAddNode_AddElement()
		{
			// arrenge
			SerialConnection serialConnection = new SerialConnection();
			Resistor resistor = new Resistor(1000.0);
			int expectedId = 1;
			int expectedIndex = 1;
			double expectedValue = 1000.0;

			// act
			serialConnection.AddNode(resistor);
			int actualId = serialConnection[0].Id;
			int actualIndex = ((ElementBase)serialConnection[0]).Index;
			double actualValue = ((ElementBase)serialConnection[0]).Value;

			// assert
			Assert.AreEqual(expectedId, actualId, "");
			Assert.AreEqual(expectedIndex, actualIndex, "");
			Assert.AreEqual(expectedValue, actualValue, "");
			Assert.IsFalse(resistor.IsValueChangedNull(), "");
			Assert.IsFalse(resistor.IsNodeChangedNull(), "");
			Assert.IsFalse(resistor.IsNodeRemovedNull(), "");

		}
	}
}
