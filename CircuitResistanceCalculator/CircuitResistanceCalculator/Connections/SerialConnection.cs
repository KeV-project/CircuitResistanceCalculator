using System.Numerics;

namespace CircuitResistanceCalculator.Connections
{
	/// <summary>
	/// Класс <see cref="SerialConnection"/> представляет узел цепи,
	/// организующий последовательное соединение элементов
	/// </summary>
	public class SerialConnection : ConnectionBase
	{
		/// <summary>
		/// Возвращает имя узла
		/// </summary>
		public override string Name { get; }

		/// <summary>
		/// Инициализирует объект класса <see cref="SerialConnection"/>
		/// </summary>
		public SerialConnection()
		{
			Name = "Serial";
		}

		/// <summary>
		/// Расчитывает общее сопротивление последовательной цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns>Общее сопротивление последовательной цепи 
		/// в комплексной форме</returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex z = new Complex(0, 0);

			for (int i = 0; i < NodesCount; i++)
			{
				z += this[i].CalculateZ(frequency);
			}
			return z;
		}
	}
}
