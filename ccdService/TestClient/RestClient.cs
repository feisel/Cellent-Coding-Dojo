using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Picture>> GetAllPictures()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(PICTURESERVICEPATH);

                response.EnsureSuccessStatusCode();    // Throw if not a success code.

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Picture>>();
                    
                }

                return null;
            }
            catch (HttpRequestException e)
            {
                // Handle exception.
                throw;
            }
        }


        public  async Task RunAsync()
        {






            
        }


        private void Connect()
        {
           
        }
    }
}
