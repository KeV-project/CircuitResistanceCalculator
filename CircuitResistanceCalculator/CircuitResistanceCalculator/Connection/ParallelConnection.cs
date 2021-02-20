using System.Numerics;

namespace CircuitResistanceCalculator.Connection
{
	/// <summary>
	/// Класс <see cref="ParallelConnection"/> представляет узел цепи,
	/// организующий параллельное соединение элементов
	/// </summary>
	public class ParallelConnection : ConnectionBase
	{
		/// <summary>
		/// Возвращает имя узла
		/// </summary>
		public override string Name { get; }

		/// <summary>
		/// Инициализирует объект класса <see cref="ParallelConnection"/>
		/// </summary>
		public ParallelConnection()
		{
			Name = "Parallel";
		}

		/// <summary>
		/// Расчитывает общее сопротивление параллельной цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns>Общее сопротисление параллельной цепи 
		/// в комплексной форме</returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex z = new Complex(0, 0);

			for(int i = 0; i < NodesCount; i++)
			{
				Complex nodeZ = this[i].CalculateZ(frequency);
				if (nodeZ != new Complex(0, 0))
				{
					z += 1 / nodeZ;
				}
			}

			if(z != new Complex(0, 0))
			{
				z = 1 / z;
			}

			return z;
		}
	}
}
