using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CircuitResistanceCalculator.UnitTests
{
	[TestFixture]
	class ValueValidatorTest
	{
		[Test(Description = "Позитивный тест метода AssertValueInRange")]
		public void TestAssertValueInRange_СorrectValue()
		{
			// arrange
			var value = 5.5;
			var minLimit = 0;
			var maxLimit = 10;
			var context = "экспериментальное значение";

			// act
			ValueValidator.AssertValueInRange(value, minLimit,
			  maxLimit, context);
		}

		[Test(Description = "Негативный тест метода AssertValueInRange")]
		public void TestAssertValueInRange_IncorrectValue()
		{
			// arrange
			var wrongValue = 10.5;
			var minLimit = 0;
			var maxLimit = 10;
			var context = "экспериментальное значение";

			// assert
			Assert.Throws<ArgumentException>(() =>
			{
				ValueValidator.AssertValueInRange(wrongValue, minLimit,
					maxLimit, context);
			}, "Должно возникать искючение, " +
			"если проверяемое число не входит в допустимый диапазон");
		}

		[Test(Description = "Позитивный тест метода AssertLengthInRange")]
		public void TestAssertLengthInRange_CorrectValue()
		{
			// arrange
			var value = "Резистор";
			var minLimit = 0;
			var maxLimit = 15;
			var context = "экспериментальное значение";

			// arrest
			ValueValidator.AssertLengthInRange(value,
					minLimit, maxLimit, context);
		}

		[Test(Description = "Негативный тест метода AssertLengthInRange")]
		public void TestAssertLengthInRange_IncorrectValue()
		{
			// arrange
			var wrongValue = "Николай";
			var minLimit = 0;
			var maxLimit = 5;
			var context = "экспериментальное значение";

			// arrest
			Assert.Throws<ArgumentException>(() =>
			{
				ValueValidator.AssertLengthInRange(wrongValue,
					minLimit, maxLimit, context);
			}, "Должно возникать искючение, если количество символов " +
			"в проверяемой строке не входит в допустимый диапазон");
		}
	}
}
