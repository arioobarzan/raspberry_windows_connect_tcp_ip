private async void SocketListener_ConnectionReceived(Windows.Networking.Sockets.StreamSocketListener sender,
    Windows.Networking.Sockets.StreamSocketListenerConnectionReceivedEventArgs args)
        { 

            StringBuilder request = new StringBuilder();
            byte[] data = new byte[BuffreSize];
            IBuffer buffer = data.AsBuffer();
            StreamSocket socket = args.Socket;
            using (IInputStream input = socket.InputStream)
            {
                buffer = await input.ReadAsync(buffer, BuffreSize, InputStreamOptions.Partial);
                request.Append(Encoding.UTF8.GetString(data, 0, (int)buffer.Length));
            }
        }