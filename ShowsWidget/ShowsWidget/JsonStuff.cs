using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShowsWidget
{
    public class JsonStuff
    {
        public static string LINK = @"http://api.tvmaze.com/";

        private static string CreateRequestUrl(string str)
        {
            return LINK + str;
        }

        private static string CreateRequest(string requestString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestString);

            string result = "";

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }

            return result;
        }

        public static List<Show> GetShows(string showName)
        {
            string str = LINK + "search/shows?q=" + showName;
            string request = CreateRequest(str);

            var json = JsonConvert.DeserializeObject<List<RootObject>>(request);

            var shows = new List<Show>();
            foreach (var item in json)
            {
                shows.Add(item.show);
            }
            return shows;
        }

        public static Episode GetEpisode(int? showId)
        {
            string str = LINK + "lookup/shows?tvrage=" + showId;
            string request = CreateRequest(str);
            var show = JsonConvert.DeserializeObject<Show>(request);

            str = show._links.nextepisode.href;
            request = CreateRequest(str);
            var ep = JsonConvert.DeserializeObject<Episode>(request);

            return ep;
        }
    }
}
