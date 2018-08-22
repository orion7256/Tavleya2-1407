using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tavleya2
{
    [Serializable]
    public class Data : ISerializable
    {
        public Data()
        {
            players = tvlData.players;
            games = tvlData.games;
            zipped = tvlData.zipped;
            counted = tvlData.counted;
        }
        public Data(SerializationInfo sInfo, StreamingContext contextArg)
        {
             this.players = (List<player>)sInfo.GetValue("players", typeof(List<player>));
             this.games = (List<game>)sInfo.GetValue("games", typeof(List<game>));
             this.zipped = (List<string>)sInfo.GetValue("zipped", typeof(List<string>));
             this.counted = (List<string>)sInfo.GetValue("counted", typeof(List<string>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("players", this.players);
            sInfo.AddValue("games", this.games);
            sInfo.AddValue("zipped", this.zipped);
            sInfo.AddValue("counted", this.counted);
        }
        public List<player> players = new List<player>();
        public List<game> games = new List<game>();
        public List<string> zipped = tvlData.zipped;
        public List<string> counted = tvlData.counted;
    }
    [Serializable]
    public class Data2 : ISerializable
    {
        public Data2()
        {
            players = tvlData.short_players;

        }
        public Data2(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.players = (List<Short_player>)sInfo.GetValue("players", typeof(List<Short_player>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("players", this.players);
        }
        public List<Short_player> players = new List<Short_player>();
    }
    [Serializable]
    public class SerializableObject : ISerializable
    {
        private Data data;
        private Data2 data2;
        public Data Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public Data2 Data2
        {
            get { return this.data2; }
            set { this.data2 = value; }
        }

        public SerializableObject() { }

        public SerializableObject(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.data = (Data)sInfo.GetValue("data", typeof(Data));
            this.data2 = (Data2)sInfo.GetValue("data2", typeof(Data2));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("data", this.data);
            sInfo.AddValue("data2", this.data2);
        }
    }
    public class MySerializer
    {
        public MySerializer() { }
        public void SerializeObject(string fileName, SerializableObject objToSerialize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSerialize);
            fstream.Close();
        }
        public SerializableObject DeserializeObject(string fileName)
        {
            SerializableObject objToSerialize = null;
            FileStream fstream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = (SerializableObject)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return objToSerialize;
        }
    }
}
