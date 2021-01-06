using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace CircuitResistanceCalculator.UnitTests.HelperMethods
{
	public static class HelperMethods
	{
		//TODO: XML комментарии?
		public static void VerifyDelegateAttachedTo(object node,
			string eventName)
		{
			var allBindings = BindingFlags.IgnoreCase | BindingFlags.Public |
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

			var type = node.GetType().BaseType;
			var fieldInfo = type.GetField(eventName, allBindings);

			var value = fieldInfo.GetValue(node);

			var handler = value as Delegate;

			if (handler == null)
			{
				throw new ArgumentNullException("Событие " + eventName +
				//TODO: Опечатка +
					" должно быть подписано на обработчик");
			}
		}
	}
}
