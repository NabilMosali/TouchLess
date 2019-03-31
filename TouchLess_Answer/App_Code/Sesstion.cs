using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TouchLess_Answer;

namespace TouchLess_Answer.App_Code
{

    public partial class Session
    {
        [JsonProperty("SessionID", Required = Required.Always)]
        public string SessionId { get; set; }

        [JsonProperty("Platenumber", Required = Required.Always)]
        public Platenumber Platenumber { get; set; }

        [JsonProperty("Intime", Required = Required.Always)]
        public long Intime { get; set; }

        [JsonProperty("Outtime", Required = Required.Always)]
        public OuttimeUnion Outtime { get; set; }

        [JsonProperty("INAgentMACID", Required = Required.Always)]
        public InAgentMacid InAgentMacid { get; set; }

        [JsonProperty("OUTAgentMACID", Required = Required.Always)]
        public OutAgentMacid OutAgentMacid { get; set; }

        [JsonProperty("Status", Required = Required.Always)]
        public Status Status { get; set; }
    }

    public enum InAgentMacid { The002422012345, The002432012345 };

    public enum OutAgentMacid { The006422012345, The006427012345 };

    public enum OuttimeEnum { Na };

    public enum Platenumber { Abcd1234, Abfd1234 };

    public enum Status { Ended, Ongoing };

    public partial struct OuttimeUnion
    {
        public OuttimeEnum? Enum;
        public long? Integer;

        public static implicit operator OuttimeUnion(OuttimeEnum Enum) => new OuttimeUnion { Enum = Enum };
        public static implicit operator OuttimeUnion(long Integer) => new OuttimeUnion { Integer = Integer };
    }

    public partial class Session
    {
        public static List<Session> FromJson(string json) => JsonConvert.DeserializeObject<List<Session>>(json, TouchLess.Converter.Settings);
    }

    public static class Serialize
    {
      
        public static string ToJson(this List<Session> self) => JsonConvert.SerializeObject(self, TouchLess.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                InAgentMacidConverter.Singleton,
                OutAgentMacidConverter.Singleton,
                OuttimeUnionConverter.Singleton,
                OuttimeEnumConverter.Singleton,
                PlatenumberConverter.Singleton,
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class InAgentMacidConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InAgentMacid) || t == typeof(InAgentMacid?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "00-24-22-01-23-45":
                    return InAgentMacid.The002422012345;
                case "00-24-32-01-23-45":
                    return InAgentMacid.The002432012345;
            }
            throw new Exception("Cannot unmarshal type InAgentMacid");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InAgentMacid)untypedValue;
            switch (value)
            {
                case InAgentMacid.The002422012345:
                    serializer.Serialize(writer, "00-24-22-01-23-45");
                    return;
                case InAgentMacid.The002432012345:
                    serializer.Serialize(writer, "00-24-32-01-23-45");
                    return;
            }
            throw new Exception("Cannot marshal type InAgentMacid");
        }

        public static readonly InAgentMacidConverter Singleton = new InAgentMacidConverter();
    }

    internal class OutAgentMacidConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OutAgentMacid) || t == typeof(OutAgentMacid?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "00-64-22-01-23-45":
                    return OutAgentMacid.The006422012345;
                case "00-64-27-01-23-45":
                    return OutAgentMacid.The006427012345;
            }
            throw new Exception("Cannot unmarshal type OutAgentMacid");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OutAgentMacid)untypedValue;
            switch (value)
            {
                case OutAgentMacid.The006422012345:
                    serializer.Serialize(writer, "00-64-22-01-23-45");
                    return;
                case OutAgentMacid.The006427012345:
                    serializer.Serialize(writer, "00-64-27-01-23-45");
                    return;
            }
            throw new Exception("Cannot marshal type OutAgentMacid");
        }

        public static readonly OutAgentMacidConverter Singleton = new OutAgentMacidConverter();
    }

    internal class OuttimeUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OuttimeUnion) || t == typeof(OuttimeUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new OuttimeUnion { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    if (stringValue == "NA")
                    {
                        return new OuttimeUnion { Enum = OuttimeEnum.Na };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type OuttimeUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (OuttimeUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Enum != null)
            {
                if (value.Enum == OuttimeEnum.Na)
                {
                    serializer.Serialize(writer, "NA");
                    return;
                }
            }
            throw new Exception("Cannot marshal type OuttimeUnion");
        }

        public static readonly OuttimeUnionConverter Singleton = new OuttimeUnionConverter();
    }

    internal class OuttimeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OuttimeEnum) || t == typeof(OuttimeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "NA")
            {
                return OuttimeEnum.Na;
            }
            throw new Exception("Cannot unmarshal type OuttimeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OuttimeEnum)untypedValue;
            if (value == OuttimeEnum.Na)
            {
                serializer.Serialize(writer, "NA");
                return;
            }
            throw new Exception("Cannot marshal type OuttimeEnum");
        }

        public static readonly OuttimeEnumConverter Singleton = new OuttimeEnumConverter();
    }

    internal class PlatenumberConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Platenumber) || t == typeof(Platenumber?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ABCD1234":
                    return Platenumber.Abcd1234;
                case "ABFD1234":
                    return Platenumber.Abfd1234;
            }
            throw new Exception("Cannot unmarshal type Platenumber");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Platenumber)untypedValue;
            switch (value)
            {
                case Platenumber.Abcd1234:
                    serializer.Serialize(writer, "ABCD1234");
                    return;
                case Platenumber.Abfd1234:
                    serializer.Serialize(writer, "ABFD1234");
                    return;
            }
            throw new Exception("Cannot marshal type Platenumber");
        }

        public static readonly PlatenumberConverter Singleton = new PlatenumberConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Ended":
                    return Status.Ended;
                case "ongoing":
                    return Status.Ongoing;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Ended:
                    serializer.Serialize(writer, "Ended");
                    return;
                case Status.Ongoing:
                    serializer.Serialize(writer, "ongoing");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

}