using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Connections
{
	//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
	/// <summary>
	/// Класс <see cref="SerialConnection"/> представляет узел цепи,
	/// организующий последовательное соединение элементов
	/// </summary>
	public class SerialConnection : ConnectionBase
	{
		/// <summary>
		/// Расчитывает общее сопротивление последовательной цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns>Общее сопротивление последовательной цепи 
		/// в комплексной форме</returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0, 0);

			for (int i = 0; i < NodesCount; i++)
			{
				circuitResistance += this[i].CalculateZ(frequency);
			}
			//TODO: Округление на нижнем уровне - плохая практика, т.к. это приведёт к потери точности. +
			return new Complex(circuitResistance.Real, 
				circuitResistance.Imaginary);
		}
	}
}
