using System;
using System.Drawing;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculatorUI.DrawingCircuit
{
	/// <summary>
	/// Класс <see cref="Painter"/> предназначен для отрисовки цепи
	/// </summary>
	public static class Painter
	{
		/// <summary>
		/// Буфер для Bitmap-изображения
		/// </summary>
		private static Bitmap _bitmap;

		/// <summary>
		/// Цвет линии
		/// </summary>
		private static Color _lineColor = Color.Black;
		/// <summary>
		/// Толщина линии
		/// </summary>
		private static int _lineWidth = 2;

		/// <summary>
		/// Длина последовательного соединения элементов
		/// </summary>
		private static int _horizontalLinesLength = 35;
		/// <summary>
		/// Длина параллельного соединения элементов
		/// </summary>
		private static int _verticalLinesLength = 50;

		/// <summary>
		/// Высота резистора
		/// </summary>
		private static int _resistorHeight = 20;
		/// <summary>
		/// Ширина резистора
		/// </summary>
		private static int _resistorWidth = 40;
		/// <summary>
		/// Высота конденсатора
		/// </summary>
		private static int _capacitorHeight = 40;
		/// <summary>
		/// Ширина конденсатора
		/// </summary>
		private static int _capacitorWidth = 20;

		/// <summary>
		/// Рисует линию по координатам двух точек
		/// </summary>
		/// <param name="x1">Абцисса начальной точки линии</param>
		/// <param name="y1">Ордината начальной точки линии</param>
		/// <param name="x2">Абцисса конечной точки линии</param>
		/// <param name="y2">Ордината коонечной точки линии</param>
		/// <param name="lineColor">Цвет линии</param>
		/// <param name="lineWidth">Ширина линии</param>
		private static void DrawLine(int x1, int y1, int x2, int y2,
			Color lineColor, int lineWidth)
		{
			Pen myPen = new Pen(lineColor, lineWidth);
			Graphics g = Graphics.FromImage(_bitmap);

			g.DrawLine(myPen, x1, y1, x2, y2);

			g.Dispose();
			myPen.Dispose();
		}

		/// <summary>
		/// Рисует резистор
		/// </summary>
		/// <param name="x">Абцисса точки включения резистора</param>
		/// <param name="y">Ордината точки включения резистора</param>
		private static void DrawResistor(int x, int y)
		{
			DrawLine(x, y, x += 20, y, _lineColor, _lineWidth);
			DrawLine(x, y - _resistorHeight / 2, x, y + _resistorHeight / 2, 
				_lineColor, _lineWidth);
			DrawLine(x, y - _resistorHeight / 2, x + _resistorWidth, 
				y - _resistorHeight / 2, _lineColor, _lineWidth);
			DrawLine(x, y + _resistorHeight / 2, x + _resistorWidth, 
				y + _resistorHeight / 2, _lineColor, _lineWidth);
			DrawLine(x + _resistorWidth, y - _resistorHeight / 2, 
				x + _resistorWidth, y + _resistorHeight / 2, _lineColor, _lineWidth);
			DrawLine(x + _resistorWidth, y, x + _resistorWidth + 55, 
				y, _lineColor, _lineWidth);
		}

		/// <summary>
		/// Рисует катушку индуктивности
		/// </summary>
		/// <param name="x">Абцисса точки включения катушки</param>
		/// <param name="y">Ордината точки включения катушки</param>
		private static void DrawInductor(int x, int y)
		{
			const int semicircleCount = 4;
			for (int i = 0; i < semicircleCount; i++)
			{
				const int semicircleRadius = 10;
				for (int j = -semicircleRadius; j < semicircleRadius; j++)
				{
					const int lineMatrixRows = 2;
					const int lineMatrixColumns = 3;
					int[,] lineMatrix = new int[lineMatrixRows, lineMatrixColumns];
					lineMatrix[0, 0] = j;
					lineMatrix[0, 1] = Convert.ToInt32(-1 * Math.Sqrt(Math.Pow(
						semicircleRadius, 2)- Math.Pow(j, 2)));
					lineMatrix[0, 2] = 1;
					lineMatrix[1, 0] = j + 1;
					lineMatrix[1, 1] = Convert.ToInt32(-1 * Math.Sqrt(Math.Pow(
						semicircleRadius, 2) - Math.Pow(j + 1, 2)));
					lineMatrix[1, 2] = 1;

					lineMatrix = MatrixOperations.Multiplication(lineMatrix, 
						TransformationMatrices.GetShiftMatrix(x + semicircleRadius, y), 2, 3);

					DrawLine(lineMatrix[0, 0], lineMatrix[0, 1], 
						lineMatrix[1, 0], lineMatrix[1, 1], _lineColor, _lineWidth);
				}
				x += 20;
			}
			DrawLine(x, y, x + 35, y, _lineColor, _lineWidth);
		}

		/// <summary>
		/// Рисует конденсатор
		/// </summary>
		/// <param name="x">Абцисса точки включения конденсатора</param>
		/// <param name="y">Ордината точки включения конденсатора</param>
		private static void DrawCapacitor(int x, int y)
		{
			DrawLine(x, y, x += 30, y, _lineColor, _lineWidth);
			DrawLine(x, y - _capacitorHeight / 2, x, y + _capacitorHeight / 2,
				_lineColor, _lineWidth);
			DrawLine(x + _capacitorWidth, y - _capacitorHeight / 2, 
				x + _capacitorWidth, y + _capacitorHeight / 2, _lineColor, _lineWidth);
			DrawLine(x + _capacitorWidth, y, x + _capacitorWidth + 65, 
				y, _lineColor, _lineWidth);
		}

		/// <summary>
		/// Рисует параллельное соединение элементов
		/// </summary>
		/// <param name="x">Абцисса начала соединения</param>
		/// <param name="y">Ордината начала соединения</param>
		/// <param name="branchCount">Количеств разветвлений</param>
		private static void DrawParalleConnection(int x, int y, 
			int branchCount)
		{
			int verticalLineLength = (branchCount - 1) * _verticalLinesLength;

			DrawLine(x, y, x += 35, y, _lineColor, _lineWidth);
			DrawLine(x, y - verticalLineLength / 2, x, 
				y + verticalLineLength / 2, _lineColor, _lineWidth);
			int currentY = y - verticalLineLength / 2;
			for(int i = 0; i < branchCount; i++)
			{
				DrawLine(x, currentY, x + _horizontalLinesLength, 
					currentY, _lineColor, _lineWidth);
				if(branchCount != 1)
				{
					currentY += verticalLineLength / (branchCount - 1);
				}
			}
		}

		/// <summary>
		/// Рекурсивно рисует все элементны цепи
		/// </summary>
		/// <param name="node">Текущий отображаемый элемент</param>
		/// <param name="x">Абцисса включения элемента</param>
		/// <param name="y">Ордината включения элемента</param>
		private static void DrawNode(NodeBase node, int x, int y)
		{
			switch(node)
			{
				case ParallelConnection parallelConnection:
				{
					DrawParalleConnection(x, y, parallelConnection.NodesCount);
					x += 35;
					int currentY = y - ((parallelConnection.NodesCount - 1) *
							_verticalLinesLength) / 2;
					for (int i = 0; i < parallelConnection.NodesCount; i++)
					{
						DrawNode(parallelConnection[i], x + _horizontalLinesLength,
							currentY);
						currentY += _verticalLinesLength;
					}
					break;
				}
				case SerialConnection serialConnection:
				{
					DrawLine(x, y, x += 35, y, _lineColor, _lineWidth);
					for (int i = 0; i < serialConnection.NodesCount; i++)
					{
						DrawNode(serialConnection[i], x, y);
						x += 115;
					}
					break;
				}
				case Resistor resistor:
				{
					DrawResistor(x, y);
					break;
				}
				case Inductor inductor:
				{
					DrawInductor(x, y);
					break;
				}
				default:
				{
					DrawCapacitor(x, y);
					break;
				}
			}
		}

		/// <summary>
		/// Выполняет графическое отображение макета электрической цепи
		/// </summary>
		/// <param name="circuit">Изображаемая цепь</param>
		/// <param name="bitmap">буфер для Bitmap-изображения</param>
		public static void DrawCircuit(ConnectionBase circuit, Bitmap bitmap)
		{
			_bitmap = bitmap;
			if(circuit.NodesCount != 0)
			{
				DrawNode(circuit[0], 0, bitmap.Height / 2);
			}
		}
	}
}
