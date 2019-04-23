using Newtonsoft.Json.Linq;
using System.IO;

namespace DashlaneTo1Password
{
	class Program
	{
		static string ToCsv( string Input )
		{
			return $"\"{Input.Replace("\"", "\"\"")}\"";
		}

		static void Main(string[] args)
		{
			string JsonData = File.ReadAllText(args[0]);
			string OutputDir = Path.GetDirectoryName(args[0]);

			string OutputPasswords = Path.Combine(OutputDir, "1PasswordImport_Passwords.csv");
			string PasswordsFile = "";

			//Passwords format:
			//title,website,username,password,notes,Associated Email,Secondary Login, custom field 3, custom field 4, etc

			JObject JsonObject = JObject.Parse(JsonData);
			JArray Passwords = (JArray)JsonObject["AUTHENTIFIANT"];

			foreach( var Password in Passwords )
			{
				var NewPassword = Password.ToObject<Password>();

				PasswordsFile += $"{ToCsv(NewPassword.title)},{ToCsv(NewPassword.domain)},{ToCsv(NewPassword.login)},{ToCsv(NewPassword.password)},{ToCsv(NewPassword.note)},{ToCsv(NewPassword.email)},{ToCsv(NewPassword.secondaryLogin)},\r\n";
			}

			File.WriteAllText(OutputPasswords, PasswordsFile);
		}
	}
}
