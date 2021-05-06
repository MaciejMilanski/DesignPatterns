using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Zadanie3
{
    [Serializable]
    public class MySingleton : ISerializable
    {
        private static MySingleton _instance;
        private MySingleton() { }

        public static MySingleton GetInstance()
        {
            if (_instance == null)
                _instance = new MySingleton();
            return _instance;
        }
        public int Num { get; set; }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(MySingletonSerializationHelper));
        }
        public static MemoryStream intoStream(MySingleton singleton)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, singleton);

            return stream;
        }
        public static MySingleton intoObject(MemoryStream stream)
        {
            MySingleton singleton;
            BinaryFormatter serializer = new BinaryFormatter();
            stream.Position = 0;
            singleton = (MySingleton)serializer.Deserialize(stream);
            return singleton;
        }
    }
    [Serializable]
    public sealed class MySingletonSerializationHelper : IObjectReference
    {
        public object GetRealObject(StreamingContext context)
        {
            return MySingleton.GetInstance();
        }
    }
}