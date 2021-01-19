﻿using System;
using System.Windows.Forms;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Node;

namespace CircuitResistanceCalculatorUI.EditConnection
{ 
	/// <summary>
	/// Класс <see cref="EditConnectionsForm"/> предназначен 
	/// для редактирования и создания элемента 
	/// типа <see cref="ConnectionBase"/>
	/// </summary>
	public partial class EditConnectionsForm : Form
	{
		/// <summary>
		/// Редактируемый элемент
		/// </summary>
		private ConnectionBase _editableConnection;

		/// <summary>
		/// Событие, возникающее при добавлении нового элемента в цепь
		/// </summary>
		public event EventHandler<AddedNodeArgs> CreatedNewConnection;

		/// <summary>
		/// Выполняет инициализацию и настройку компонентов 
		/// окна для редактирования элемента цепи
		/// </summary>
		/// <param name="connection"></param>
		public EditConnectionsForm(ConnectionBase connection)
		{
			InitializeComponent();

			if(connection != null)
			{
				_editableConnection = connection;
				if(_editableConnection is ParallelConnection)
				{
					ParallelRadioButton.Checked = true;
				}
				else
				{
					SerialRadioButton.Checked = true;
				}
			}
		}

		/// <summary>
		/// Запускает процесс добавления нового элемента в цепь
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void OkButton_Click(object sender, EventArgs e)
		{
			if(ParallelRadioButton.Checked)
			{
				CreatedNewConnection?.Invoke(this, 
					new AddedNodeArgs(new ParallelConnection()));
			}
			else
			{
				CreatedNewConnection?.Invoke(this, 
					new AddedNodeArgs(new SerialConnection()));
			}

			Close();
		}

		/// <summary>
		/// Отменяет создание нового элемента цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
