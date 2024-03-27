using System;
using System.IO;
using System.Collections.Generic;
namespace CarRentalSystem.Utility
{
    internal static class PropertyUtil
    {
        public static string GetPropertyString(string filePath)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Properties file not found.", filePath);
            }

            
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    if (line.Trim() == "" || line.Trim().StartsWith("#") || line.Trim().StartsWith("//"))
                        continue;

                    
                    string[] parts = line.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        
                        properties[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }

            
            string connectionString = $"Server={properties["localhost"]};Database={properties["CAR_RENTAL"]};Username={properties["sa"]};Password={properties["candycharl@03"]}";

            return connectionString;
        }
    }
}
