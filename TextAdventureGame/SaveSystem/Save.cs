using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

using System.Collections.Generic;
using Artefact.Utilities;
using Artefact.EntitySystem;
using Artefact.GameStates;
using Artefact.InventorySystem;
using Artefact.SaveSystem;
using Artefact.ScriptSettings;
using Artefact.ShopSystem;
using Artefact.UI;

namespace Artefact.SaveSystem
{
    public static class Save
    {
        public static void SaveGame()
        {

            int index = Menu.Run("Please choose a Save Game Slot:\n", new string[] {"Slot 1", "Slot 2", "Slot 3"});
            
            switch (index)
            {
                case 0:
                    SaveData(GameManager.Player, "slot1.xml");
                    break;
                case 1:
                    SaveData(GameManager.Player, "slot2.xml");
                    break;
                case 2:
                    SaveData(GameManager.Player, "slot3.xml");
                    break;
            }
        }
        
        public static Entity LoadGame()
        {

            int index = Menu.Run("Please choose a Save Game Slot:\n", new[] {"Slot 1", "Slot 2", "Slot 3"});
            
            switch (index)
            {
                case 0:
                    if (LoadData<Entity>("slot1.xml") == null) { break; }
                    return LoadData<Entity>("slot1.xml");
                case 1:
                    if (LoadData<Entity>("slot2.xml") == null) { break; }
                    return LoadData<Entity>("slot2.xml");
                case 2:
                    if (LoadData<Entity>("slot3.xml") == null) { break; }
                    return LoadData<Entity>("slot3.xml");
                default:
                    return null;
            }

            return new Entity();
        }
        
        private static void SaveData<T>(T serializableObject, string filepath) // Generic type input to capture any class I need to save 
        {
            // In this case I'm using var to minimize copied code and to improve readability
            var serializer = new DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            var writer = XmlWriter.Create(filepath, settings);
            serializer.WriteObject(writer, serializableObject);
            writer.Close();
        }


        private static T LoadData<T>(string filepath) // Generic type output to return any class I load 
        {
            if (!File.Exists(filepath))
            {
                T obj = default;
                return obj;
            }
            
            // In this case I'm using var to minimize copied code and to improve readability
            var fileStream = new FileStream(filepath, FileMode.Open); 
            var reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            var serializer = new DataContractSerializer(typeof(T));
            T serializableObject = (T)serializer.ReadObject(reader, true);
            reader.Close();
            fileStream.Close();
            return serializableObject;
        }
    }
}