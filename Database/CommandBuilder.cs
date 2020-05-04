using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Gazette.Database
{
	public static class CommandBuilder
	{
		/// <summary>
		/// Creates a <see cref="MySqlCommand"/> with a <paramref name="connection"/> and <paramref name="parameters"/> already set. <br/>
		/// Mostly created so I don't forget to set a connection and have to debug for half an hour.
		/// </summary>
		/// <param name="cmdText">The command to run.</param>
		/// <param name="connection">The databse to connect to.</param>
		/// <param name="parameters">The parameters passed to the command.</param>
		/// <returns></returns>
		public static MySqlCommand CreateCommand(string cmdText, MySqlConnection connection, params (string parameterName, object value, MySqlDbType type)[] parameters)
		{
			MySqlCommand command = new MySqlCommand(cmdText, connection);
			foreach(var (parameterName, value, type) in parameters)
			{
				command.Parameters.Add(parameterName, type).Value = value;
			}
			return command;
		}
	}
}
