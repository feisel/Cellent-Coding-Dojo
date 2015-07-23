using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestClient
{
    class RestClient
    {
        HttpClient client;

        const string PICTURESERVICEPATH = "api/picture";


        public RestClient()
        {
            client = new HttpClient();
            // New code:
            client.BaseAddress = new Uri("http://localhost:17553/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task UploadNewPicture(Picture picture)
        {
         
            var response = await client.PostAsJsonAsync(PICTURESERVICEPATH, picture);
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                Uri pictureUrl = response.Headers.Location;
            }
        }


        public  async Task RunAsync()
        {



                try
                {
                    // New code:
                    HttpResponseMessage response = await client.GetAsync("api/picture/0");

                    response.EnsureSuccessStatusCode();    // Throw if not a success code.

                    if (response.IsSuccessStatusCode)
                    {
                        Picture pic = await response.Content.ReadAsAsync<Picture>();
                        Console.WriteLine("{0}\t${1}\t{2}", pic.Name, pic.Description, pic.Id);
                    }


                }
                catch (HttpRequestException e)
                {
                    // Handle exception.
                }


            
        }


        private void Connect()
        {
           
        }
    }
}
