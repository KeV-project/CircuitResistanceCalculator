using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculatorUI.DrawingCircuit
{
	/// <summary>
	/// Класс <see cref="MatrixOperations"/> предоставляет 
	/// методы для выполнения матричных операций
	/// </summary>
	public static class MatrixOperations
	{
		/// <summary>
		/// Выполняет умножение матриц
		/// </summary>
		/// <param name="firstMatrix">Множимая матрица</param>
		/// <param name="secondMatrix">Матрица множитель</param>
		/// <param name="rowsCount">Количество строк множимой матрицы</param>
		/// <param name="columnsCount">Количество столбцов множимой матрицы</param>
		/// <returns></returns>
		public static int[,] Multiplication(int[,] firstMatrix,
			int[,] secondMatrix, int rowsCount, int columnsCount)
		{
			int[,] resultMatrix = new int[rowsCount, columnsCount];
			for (int i = 0; i < rowsCount; i++)
			{
				for (int j = 0; j < columnsCount; j++)
				{
					resultMatrix[i, j] = 0;
					for (int ii = 0; ii < columnsCount; ii++)
					{
						resultMatrix[i, j] += firstMatrix[i, ii] *
							secondMatrix[ii, j];
					}
				}
			}
			return resultMatrix;
		}
	}
}
