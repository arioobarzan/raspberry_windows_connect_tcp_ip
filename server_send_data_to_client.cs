using (var outputStream = socket.OutputStream)
            {
                using (Stream resp = outputStream.AsStreamForWrite())
                {
                    var message = request.ToString()+" sent";
                    byte[] headerArray = Encoding.UTF8.GetBytes(message);
                    await resp.WriteAsync(headerArray, 0, headerArray.Length);
                    await resp.FlushAsync();
                }
            }