using System.Drawing;
using System.Drawing.Imaging;
using System.Net.WebSockets;
using System.Text;

namespace StreamVideo.Web
{
    public static class WebSocketBuilder
    {
        public static IApplicationBuilder UseStreamSocket(this IApplicationBuilder app)
        {
            var webSocketOptions = new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120)
            };

            app.UseWebSockets(webSocketOptions);

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await Stream(context, webSocket);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });

            return app;
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                    new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                    new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                        0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        private static async Task Stream(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 10];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                ArraySegment<byte> streamData = new ArraySegment<byte>(buffer, 0, result.Count);

                var data = Encoding.UTF8.GetString(streamData);
                data = data.Replace("data:image/jpeg;base64,", "");
                byte[] imageData = Convert.FromBase64String(data);
                byte[] grayscaleImage = null;

                using (var ms1 = new MemoryStream(imageData))
                {
                    var ss = Bitmap.FromStream(ms1) as Bitmap;

                    using (var ms2 = new MemoryStream())
                    {
                        MakeGrayscale3(ss).Save(ms2, ImageFormat.Jpeg);
                        grayscaleImage = ms2.ToArray();
                    }
                }

                var base64StringResult = Convert.ToBase64String(grayscaleImage);
                var modifiedData = Encoding.UTF8.GetBytes(base64StringResult);

                await webSocket.SendAsync(new ArraySegment<byte>(modifiedData, 0, modifiedData.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);

                var outputData = new ArraySegment<byte>(buffer);
                result = await webSocket.ReceiveAsync(outputData, CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
