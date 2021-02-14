using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculatorUI.DrawingCircuit
{
	public static class Painter
	{
		private static Color _lineColor = Color.Black;
		private static int _lineWidth = 2;

		private static int _horizontalLinesLength = 35;
		private static int _verticalLinesLength = 50;

		private static int _resistorHeight = 20;
		private static int _resistorWidth = 40;
		private static int _capacitorHeight = 40;
		private static int _capacitorWidth = 20;

		private static void DrawLine(Bitmap bitmap, int x1, int y1,
			int x2, int y2, Color lineColor, int lineWidth)
		{
			Pen myPen = new Pen(lineColor, lineWidth);
			Graphics g = Graphics.FromImage(bitmap);

			g.DrawLine(myPen, x1, y1, x2, y2);

			g.Dispose();
			myPen.Dispose();
		}

		private static void DrawRoot(Bitmap bitmap)
		{
			int x1 = 0;
			int y1 = bitmap.Height / 2;
			int x2 = 35;
			int y2 = bitmap.Height / 2;
			Color lineColor = Color.Black;
			int lineWidth = 2;
			DrawLine(bitmap, x1, y1, x2, y2, lineColor, lineWidth);
		}

		private static void DrawResistor(Bitmap bitmap, int x, int y)
		{
			DrawLine(bitmap, x, y, x + 20, y, _lineColor, _lineWidth);
			x += 20;
			DrawLine(bitmap, x, y - _resistorHeight / 2, x, y + _resistorHeight / 2, 
				_lineColor, _lineWidth);
			DrawLine(bitmap, x, y - _resistorHeight / 2, x + _resistorWidth, 
				y - _resistorHeight / 2, _lineColor, _lineWidth);
			DrawLine(bitmap, x, y + _resistorHeight / 2, x + _resistorWidth, 
				y + _resistorHeight / 2, _lineColor, _lineWidth);
			DrawLine(bitmap, x + _resistorWidth, y - _resistorHeight / 2, 
				x + _resistorWidth, y + _resistorHeight / 2, _lineColor, _lineWidth);
			DrawLine(bitmap, x + _resistorWidth, y, x + _resistorWidth + 55, 
				y, _lineColor, _lineWidth);
		}

		private static void DrawInductor(Bitmap bitmap, int x, int y)
		{
			const int semicircleCount = 4;
			for (int i = 0; i < semicircleCount; i++)
			{
				for (int j = -10; j < 10; j++)
				{
					int[,] lineMatrix = new int[2, 3];
					lineMatrix[0, 0] = j;
					lineMatrix[0, 1] = Convert.ToInt32(-1 * Math.Sqrt(Math.Pow(10, 2)
						- Math.Pow(j, 2)));
					lineMatrix[0, 2] = 1;
					lineMatrix[1, 0] = j + 1;
					lineMatrix[1, 1] = Convert.ToInt32(-1 * Math.Sqrt(Math.Pow(10, 2)
						- Math.Pow(j + 1, 2)));
					lineMatrix[1, 2] = 1;

					lineMatrix = MatrixOperations.Multiplication(lineMatrix, 
						GetShiftMatrix(x + 10, y), 2, 3);

					DrawLine(bitmap, lineMatrix[0, 0], lineMatrix[0, 1], 
						lineMatrix[1, 0], lineMatrix[1, 1], _lineColor, _lineWidth);
				}
				x += 20;
			}
			DrawLine(bitmap, x, y, x + 35, y, _lineColor, _lineWidth);
		}

		private static void DrawCapacitor(Bitmap bitmap, int x, int y)
		{
			DrawLine(bitmap, x, y, x += 30, y, _lineColor, _lineWidth);
			DrawLine(bitmap, x, y - _capacitorHeight / 2, x, y + _capacitorHeight / 2,
				_lineColor, _lineWidth);
			DrawLine(bitmap, x + _capacitorWidth, y - _capacitorHeight / 2, 
				x + _capacitorWidth, y + _capacitorHeight / 2, _lineColor, _lineWidth);
			DrawLine(bitmap, x + _capacitorWidth, y, x + _capacitorWidth + 65, y, _lineColor, _lineWidth);
		}

		private static void DrawParalleConnection(Bitmap bitmap, int x, int y, 
			int branchCount)
		{
			int verticalLineLength = (branchCount - 1) * _verticalLinesLength;

			DrawLine(bitmap, x, y - verticalLineLength / 2, x, 
				y + verticalLineLength / 2, _lineColor, _lineWidth);
			int currentY = y - verticalLineLength / 2;
			for(int i = 0; i < branchCount; i++)
			{
				DrawLine(bitmap, x, currentY, x + _horizontalLinesLength, 
					currentY, _lineColor, _lineWidth);
				currentY += verticalLineLength / (branchCount - 1);
			}
		}

		private static void DrawNode(NodeBase node, Bitmap bitmap, int x, int y)
		{
			switch(node)
			{
				case Resistor resistor:
				{
					DrawResistor(bitmap, x, y);
					break;
				}
				case Inductor inductor:
				{
					DrawInductor(bitmap, x, y);
					break;
				}
				case Capacitor capacitor:
				{
					DrawCapacitor(bitmap, x, y);
					break;
				}
				case ParallelConnection parallelConnection:
				{
					DrawParalleConnection(bitmap, x, y, parallelConnection.NodesCount);
					int currentY = y - ((parallelConnection.NodesCount - 1) * 
							_verticalLinesLength) / 2;
					for(int i = 0; i < parallelConnection.NodesCount; i++)
					{
						DrawNode(parallelConnection[i], bitmap, x + _horizontalLinesLength, 
							currentY);
						currentY += _verticalLinesLength;
					}
					break;
				}
				default:
				{
					break;
				}
			}
		}


		public static void DrawCircuit(ConnectionBase circuit, Bitmap bitmap)
		{
			DrawRoot(bitmap);
			DrawNode(circuit[0], bitmap, 35, bitmap.Height / 2);
		}
	}
}
