using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServiceCarTracker
{
	public class JsonStorage
	{
        //Store the json file with data - serialization
        public static void JsonOutput(List<Fuel> Data, string location)
        {
            string jsonString = JsonSerializer.Serialize(Data);
            //string location = "/Users/dusan/My_data/obecne/CSharp/JsonTest/TestJsonFile.json";
            File.WriteAllText(location, jsonString);
        }
        public static void JsonOutput(List<Oil> Data, string location)
        {
            string jsonString = JsonSerializer.Serialize(Data);
            File.WriteAllText(location, jsonString);
        }
        public static void JsonOutput(List<ServiceAndExpenses> Data, string location)
        {
            string jsonString = JsonSerializer.Serialize(Data);
            File.WriteAllText(location, jsonString);
        }


        //Read data from json to objects - deserialization
        //make sure fuelObject is not null, the file in the location exists, make it more simple
        public static List<Fuel> JsonReadFuel(string location)
        {
            //string fileName = "/Users/dusan/My_data/obecne/CSharp/JsonTest/TestJsonFile.json";
            string jsonString = File.ReadAllText(location);
            var resultObjects = JsonSerializer.Deserialize<List<Fuel>>(jsonString);
            return resultObjects;
        }
        public static List<Oil> JsonReadOil(string location)
        {
            //string fileName = "/Users/dusan/My_data/obecne/CSharp/JsonTest/TestJsonFile.json";
            string jsonString = File.ReadAllText(location);
            var resultObjects = JsonSerializer.Deserialize<List<Oil>>(jsonString);
            return resultObjects;
        }
        public static List<ServiceAndExpenses> JsonReadServiceAndExpenses(string location)
        {
            //string fileName = "/Users/dusan/My_data/obecne/CSharp/JsonTest/TestJsonFile.json";
            string jsonString = File.ReadAllText(location);
            var resultObjects = JsonSerializer.Deserialize<List<ServiceAndExpenses>>(jsonString);
            return resultObjects;
        }


        public JsonStorage()
		{
            
        }
    }
}

