using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.DTO;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    // It is formatter sample. 
    // If you want to use it, add turn on it in the TechArtSurvey.WebApi/App_start/WebApiConfig.cs
    public class UserFormatter : MediaTypeFormatter
    {
        public UserFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-user"));
        }

        /// <summary>
        ///     Queries whether this <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter" /> can deserializean object
        ///     of the specified type.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter" /> can deserialize the type;
        ///     otherwise, false.
        /// </returns>
        /// <param name="type">The type to deserialize.</param>
        public override bool CanReadType(Type type)
        {
            return type == typeof( UserDto ) || type == typeof( IEnumerable<UserDto> );
        }

        /// <summary>
        ///     Queries whether this <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter" /> can serializean object of
        ///     the specified type.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter" /> can serialize the type; otherwise,
        ///     false.
        /// </returns>
        /// <param name="type">The type to serialize.</param>
        public override bool CanWriteType(Type type)
        {
            return type == typeof( UserDto ) || type == typeof( IEnumerable<UserDto> );
        }

        /// <summary>Asynchronously writes an object of the specified type.</summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that will perform the write.</returns>
        /// <param name="type">The type of the object to write.</param>
        /// <param name="value">The object value to write.  It may be null.</param>
        /// <param name="writeStream">The <see cref="T:System.IO.Stream" /> to which to write.</param>
        /// <param name="content">The <see cref="T:System.Net.Http.HttpContent" /> if available. It may be null.</param>
        /// <param name="transportContext">The <see cref="T:System.Net.TransportContext" /> if available. It may be null.</param>
        /// <exception cref="T:System.NotSupportedException">Derived types need to support writing.</exception>
        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
                                                      TransportContext transportContext)
        {
            // Get data and convert to string
            var users = value is UserDto
                            ? new[]
                              {
                                  (UserDto) value
                              }
                            : (IEnumerable<UserDto>) value;
            var usersString = users.Select(user => $"{user.Name},{user.Email}").ToList();
            var writer = new StreamWriter(writeStream);
            // Write data to stream
            await writer.WriteAsync(string.Join(",", usersString));
            writer.Flush();
            // !!!!!Don't close stream!!!!!
        }
    }
}