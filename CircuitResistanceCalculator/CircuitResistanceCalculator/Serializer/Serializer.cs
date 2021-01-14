using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;

namespace CircuitResistanceCalculator.Serializer
{
	public class Serializer
	{
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

				circuit = JsonConvert.DeserializeObject<SerialConnection>(projectContent);
			}

			return circuit;
		}

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

			using (StreamWriter file = new StreamWriter(
				Convert.ToString(path), false, Encoding.UTF8))
			{
				file.Write(JsonConvert.SerializeObject(circuit));
			}
		}
	}
}
