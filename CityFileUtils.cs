using System.Text.Json;
using System;

namespace FreelancerProjectAngular
{
    public class CityFileUtils
    {
        public static CityFileStructure LoadFile()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "CityFiles/cities.json");

                string fileContents = File.ReadAllText(filePath);
                CityFileStructure structure = JsonSerializer.Deserialize<CityFileStructure>(fileContents);
                return structure;

            }
            catch (IOException e)
            {
                return null;
            }

        }

        public static void SaveFile(CityFileStructure structure)
        {
            string jsonString = JsonSerializer.Serialize(structure);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "CityFiles");

            // Full path to the file
            string filePath = Path.Combine(folderPath, "cities.json");

            // Write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }

        public static void AddCity(string city)
        {
            CityFileStructure fileStructure = LoadFile();

            fileStructure.CityNames.Add(city);

            SaveFile(fileStructure);

        }

        public static void RemoveCity(string city)
        {
            CityFileStructure fileStructure = LoadFile();

            fileStructure.CityNames.Remove(city);
            SaveFile(fileStructure);
        }
    }
}
