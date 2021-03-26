using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net.Http;
using System.Text;

namespace VPNHelperCommon.Formatters
{
    /// <summary>
    /// The JSON formatter class.
    /// </summary>
    public class JsonFormatter
    {
        #region Fields

        /// <summary>
        /// The root node name.
        /// </summary>
        private const string rootNodeName = "data";

        /// <summary>
        /// The default encoding.
        /// </summary>
        private readonly Encoding defaultEncoding = UTF8Encoding.UTF8;

        private readonly JsonSerializer serializer;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of <see cref="JsonFormatter"/> class.
        /// </summary>
        public JsonFormatter()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() },
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            serializerSettings.Converters.Add(new IsoDateTimeConverter());
            this.serializer = JsonSerializer.Create(serializerSettings);
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Deserialize object from JSON string.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Serialized string.</param>
        /// <returns>Object.</returns>
        public virtual T Deserialize<T>(string value)
        {
            using (var strReader = new StringReader(value))
            {
                using (var reader = new JsonTextReader(strReader))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.PropertyName
                            && (string)reader.Value == rootNodeName)
                        {
                            reader.Read();

                            var serializer = new JsonSerializer();
                            return serializer.Deserialize<T>(reader);
                        }
                    }
                    return default(T);
                }
            }
        }

        /// <summary>
        /// Deserializes object from stream.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="stream">Stream to read from.</param>
        /// <returns>Object.</returns>
        public virtual T Deserialize<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            {
                using (var reader = new JsonTextReader(streamReader))
                {
                    reader.Read();

                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(reader);
                }
            }
        }

        /// <summary>
        /// Serializes object to JSON string.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public virtual string Serialize(object obj)
        {
            var sb = new StringBuilder();
            using (var strWriter = new StringWriter(sb))
            {
                using (var jsonWriter = new JsonTextWriter(strWriter))
                {
                    serializer.Serialize(jsonWriter, obj);
                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// Serializes object to stream.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="stream">Stream to write to.</param>
        public virtual void Serialize(object obj, Stream stream)
        {
            using (var strWriter = new StreamWriter(stream))
            {
                using (var jsonWriter = new JsonTextWriter(strWriter))
                {
                    serializer.Serialize(jsonWriter, obj);
                }
            }
        }

        /// <summary>
        /// Creates HttpContent from object.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <returns>HttpContent.</returns>
        public virtual HttpContent SerializeToHttpContent(object obj)
        {
            HttpContent content = new StringContent(this.Serialize(obj));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                CharSet = defaultEncoding.WebName
            };

            return content;
        }

        #endregion Methods
    }
}
