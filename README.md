# DashlaneJsonTo1PasswordCsv
A simple tool to convert Dashlane's Json file format export to 1Password's CSV import format.

I wrote this because Dashlane's output to CSV is broken for import into 1 Password.

Requires minimal dependencies - only uses Newtonsoft Json, and code is straightforward.

Usage:
* Build from source - I wouldn't trust binaries to handle my passwords from a random on the internet, so I doubt you would either! Built with VS2017, should compile fine with VS2019 too.
* Pause backups - you don't want your passwords ending up in plain text in your backups
* Export from Dashlane with the **'JSON'** format option (File -> Export -> Unsecured archive (readable) in JSON format)
* Pass the file to the tool as the only parameter (eg DashlaneJsonTo1PasswordCsv.exe MyPasswords.json)
* Converted CSV will be output to the same directory with the name 1PasswordImport_Passwords.csv
* Go to https://my.1password.com/, sign in and click your name in the top right. Click Import.
* Click **Other** (If you select Dashlane, it'll expect it in the mangled format Dashlane outputs)
* Click the file at the bottom and browse to 1PasswordImport_Passwords.csv
* Validate that all your passwords were imported correctly.
