
class Program
{
    private static readonly HttpClient client = new HttpClient();
    private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private static string? downloadUrl;
    private static string? filePath;
    private static long totalBytes = 0;

    static async Task Main(string[] args)
    {
        Console.Write("Enter the download URL: ");
        downloadUrl = Console.ReadLine();

        Console.Write("Enter the file path to save the download (include file name, e.g., downloadedFile.exe): ");
        filePath = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter download time in seconds: ");
            if (int.TryParse(Console.ReadLine(), out int downloadTime))
            {
                cancellationTokenSource = new CancellationTokenSource();
                await DownloadFileAsync(downloadTime);
            }
            else
            {
                Console.WriteLine("Invalid time. Please enter a valid number.");
            }
        }
    }

    private static async Task DownloadFileAsync(int downloadTime)
    {
        using (var response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token))
        {
            response.EnsureSuccessStatusCode(); // Check for a successful response
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = new FileStream(filePath ?? "", FileMode.Append, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;
                DateTime startTime = DateTime.Now;

                while (totalBytes < response.Content.Headers.ContentLength &&
                       (DateTime.Now - startTime).TotalSeconds < downloadTime)
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token);
                    if (bytesRead == 0) break;

                    await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationTokenSource.Token);
                    totalBytes += bytesRead;

                    Console.WriteLine($"Downloaded {totalBytes} bytes...");
                }

                if (totalBytes < response.Content.Headers.ContentLength)
                {
                    Console.WriteLine("Time is up! Download paused.");
                    cancellationTokenSource.Cancel(); // Cancel the current operation
                }
                else
                {
                    Console.WriteLine("Download complete.");
                }
            }
        }
    }
}
