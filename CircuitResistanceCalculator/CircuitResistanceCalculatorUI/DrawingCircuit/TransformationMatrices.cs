namespace CircuitResistanceCalculatorUI.DrawingCircuit
{
	/// <summary>
	/// Класс <see cref="TransformationMatrices"/> предоставляет 
	/// матрицы преобразований
	/// </summary>
	public class TransformationMatrices
	{
		/// <summary>
		/// Предоставляет матрицу сдвига
		/// </summary>
		/// <param name="dx">Сдвиг по оси x</param>
		/// <param name="dy">Сдвиг по оси y</param>
		/// <returns>Матрица сдвига</returns>
		public static int[,] GetShiftMatrix(int dx, int dy)
		{
			int[,] shiftMatrix = new int[3, 3];

			shiftMatrix[0, 0] = 1; shiftMatrix[0, 1] = 0; shiftMatrix[0, 2] = 0;
			shiftMatrix[1, 0] = 0; shiftMatrix[1, 1] = 1; shiftMatrix[1, 2] = 0;
			shiftMatrix[2, 0] = dx; shiftMatrix[2, 1] = dy; shiftMatrix[2, 2] = 1;

			return shiftMatrix;
		}
	}
}
