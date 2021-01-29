using System.Numerics;

namespace CircuitResistanceCalculator.Connections
{
	/// <summary>
	/// Класс <see cref="ParallelConnection"/> представляет узел цепи,
	/// организующий параллельное соединение элементов
	/// </summary>
	public class ParallelConnection : ConnectionBase
	{
		/// <summary>
		/// Расчитывает общее сопротивление параллельной цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns>Общее сопротисление параллельной цепи 
		/// в комплексной форме</returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0,0);

			for(int i = 0; i < NodesCount; i++)
			{
				circuitResistance += 1 / this[i].CalculateZ(frequency);
			}

			circuitResistance = 1 / circuitResistance;

			return new Complex(circuitResistance.Real, 
				circuitResistance.Imaginary);
		}
	}
}
