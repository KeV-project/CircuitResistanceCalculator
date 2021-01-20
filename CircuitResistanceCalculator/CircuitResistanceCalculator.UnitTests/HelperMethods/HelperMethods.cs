using System;
using System.Reflection;


namespace CircuitResistanceCalculator.UnitTests.HelperMethods
{
	/// <summary>
	/// Класс <see cref="HelperMethods"/> предоставляет вспомогательные 
	/// методы для тестирования логики приложения
	/// </summary>
	public static class HelperMethods
	{
		//TODO: XML комментарии? +
		/// <summary>
		/// Метод предназначен для выявления подписки события на обработчик(и)
		/// </summary>
		/// <param name="node">Узел цепи</param>
		/// <param name="eventName">Имя события</param>
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
