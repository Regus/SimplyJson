using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimplyJson.WebApi {
	public class SimplyJsonMediaTypeFormatter : MediaTypeFormatter {

		public override bool CanReadType(Type type) {
			return true;
		}

		public override bool CanWriteType(Type type) {
			return true;
		}

		public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType) {
			return this;
		}

		public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger) {
			return await ReadFromStreamAsync(type, readStream, content, formatterLogger, new CancellationToken(false));
		}

		public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken) {
			Json json;
			if (content.Headers.ContentLength > 0) {
				byte[] buffer = new byte[(int)content.Headers.ContentLength];
				int offset = 0;
				while (offset < buffer.Length) {
					if (cancellationToken.IsCancellationRequested) {
						return null;
					}
					int read = await readStream.ReadAsync(buffer, offset, buffer.Length - offset);
					if (read == 0) {
						throw new Exception("Unexpected end of stream");
					}
					offset += read;
				}
				if (cancellationToken.IsCancellationRequested) {
					return null;
				}
				json = Json.Parse(Encoding.GetEncoding(content.Headers.ContentType.CharSet).GetString(buffer));
			}
			else {
				byte[] buffer = new byte[1024];
				int offset = 0;
				while (true) {
					if (cancellationToken.IsCancellationRequested) {
						return null;
					}
					if (buffer.Length - offset < 100) {
						byte[] oldBuffer = buffer;
						buffer = new byte[oldBuffer.Length + 1024];
						Buffer.BlockCopy(oldBuffer, 0, buffer, 0, offset);
					}
					int read = await readStream.ReadAsync(buffer, offset, buffer.Length - offset);
					if (read == 0) {
						break;
					}
					offset += read;
				}
				if (cancellationToken.IsCancellationRequested) {
					return null;
				}
				json = Json.Parse(Encoding.GetEncoding(content.Headers.ContentType.CharSet).GetString(buffer, 0, offset));
			}
			MethodInfo method = typeof(Json).GetMethod("Deserialize", BindingFlags.Public);
			MethodInfo generic = method.MakeGenericMethod(type);
			if (cancellationToken.IsCancellationRequested) {
				return null;
			}
			return generic.Invoke(json, null);
		}

		public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext) {
			await base.WriteToStreamAsync(type, value, writeStream, content, transportContext, new CancellationToken(false));
		}

		public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext, CancellationToken cancellationToken) {
			string json = Json.Serialize(value).ToString(false);
			if (cancellationToken.IsCancellationRequested) {
				return;
			}
			byte[] buffer = Encoding.GetEncoding(content.Headers.ContentType.CharSet).GetBytes(json);
			if (cancellationToken.IsCancellationRequested) {
				return;
			}
			await writeStream.WriteAsync(buffer, 0, buffer.Length);
		}

	}
}
