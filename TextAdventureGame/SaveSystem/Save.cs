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

namespace Artefact.SaveSystem
{
    public enum GameSave
    {
        Slot1,
        Slot2,
        Slot3
    }
    
    public static class Save
    {
        private static string saveSlot1;
        private static string saveSlot2;
        private static string saveSlot3;
        
        public static void SaveD(GameSave slot)
        {
            string saveSlot = string.Empty;
            
            switch (slot)
            {
                case GameSave.Slot1:
                    saveSlot = saveSlot1;
                    break;
                case GameSave.Slot2:
                    saveSlot = saveSlot2;
                    break;
                case GameSave.Slot3:
                    saveSlot = saveSlot3;
                    break;
            }

            if (string.IsNullOrEmpty(saveSlot))
            {
                
            }

        }
        
        public static void SaveData<T>(T serializableObject, string filepath)
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


        public static T LoadData<T>(string filepath) 
        {
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