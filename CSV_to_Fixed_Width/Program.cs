using System;
using System.IO;

namespace CSV_to_Fixed_Width
{
	class Program
	{
		static void Main()
		{
			{
				using (StreamReader reader = new StreamReader(@"C:\MW_Test_Files\csv-to-fixed-width.csv"))
				{
					using (StreamWriter file = new StreamWriter(@"C:\MW_Test_Files\csv_fixed_width_dataoutput.csv"))
					{
						while (!reader.EndOfStream)
						{
							string fileLine = reader.ReadLine();

							if (string.IsNullOrWhiteSpace(fileLine))
							{
								continue;
							}

							//StringBuilder sb = new StringBuilder();
							foreach (string column in fileLine.Split(','))
							{
								string formattedColumn = column.Trim();

								if (formattedColumn.Length > 9)
								{
									formattedColumn = formattedColumn.Substring(0, 9);
								}

								file.Write(formattedColumn.PadRight(9));
								//sb.Append(formattedColumn.PadRight(9));
							}

							file.WriteLine();
							//file.WriteLine(sb.ToString());
						}
					}
				}
			}
		}
	
		
	}
}
