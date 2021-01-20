using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using CircuitResistanceCalculator.Connections;

namespace CircuitResistanceCalculator.Serializer
{
	/// <summary>
	/// Класс <see cref="Serializer"/> предназначен для 
	/// сериализации и десериализации цепи
	/// </summary>
	public class Serializer
	{
		/// <summary>
		/// Выполняет десериализацию цепи из файла
		/// </summary>
		/// <param name="path">Путь к файлу для записи</param>
		/// <returns>Десериализованный объект</returns>
		public static ConnectionBase ReadCircuit(FileInfo path)
		{
			if (!path.Directory.Exists)
			{
				path.Directory.Create();
			}
			if (!File.Exists(path.FullName))
			{
				path.Create().Close();
			}

			ConnectionBase circuit = new SerialConnection();

			using (StreamReader file = new StreamReader(
					Convert.ToString(path), Encoding.Default))
			{
				string projectContent = file.ReadLine();
				if (string.IsNullOrEmpty(projectContent))
				{
					return circuit;
				}
		
				circuit = JsonConvert.DeserializeObject<SerialConnection>(
					projectContent, new JsonSerializerSettings 
					{ 
						TypeNameHandling = TypeNameHandling.Auto 
					});
			}

			return circuit;
		}

		/// <summary>
		/// Выполняет сериализацию объекта в файл
		/// </summary>
		/// <param name="circuit">Сериализуемый объект</param>
		/// <param name="path">Путь к файлу для записи</param>
		public static void SaveCircuit(ConnectionBase circuit,
			FileInfo path)
		{
			if (!path.Directory.Exists)
			{
				path.Directory.Create();
			}
			if (!File.Exists(path.FullName))
			{
				path.Create().Close();
			}

			var settings = new JsonSerializerSettings 
			{ 
				TypeNameHandling = TypeNameHandling.Auto 
			};

			using (StreamWriter file = new StreamWriter(
				Convert.ToString(path), false, Encoding.UTF8))
			{
				file.Write(JsonConvert.SerializeObject(circuit, 
					typeof(object), settings));
			}
		}
	}
}
