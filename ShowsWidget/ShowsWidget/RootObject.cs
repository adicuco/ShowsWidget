using System.Collections.Generic;

namespace ShowsWidget
{


    public class Schedule
    {
        public string time { get; set; }
        public List<object> days { get; set; }
    }

    public class Rating
    {
        public double? average { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
        public string timezone { get; set; }
    }

    public class Network
    {
        public int id { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
    }

    public class Country2
    {
        public string name { get; set; }
        public string code { get; set; }
        public string timezone { get; set; }
    }

    public class WebChannel
    {
        public int id { get; set; }
        public string name { get; set; }
        public Country2 country { get; set; }
    }

    public class Externals
    {
        public int? tvrage { get; set; }
        public int? thetvdb { get; set; }
        public string imdb { get; set; }
    }

    public class Image
    {
        public string medium { get; set; }
        public string original { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Previousepisode
    {
        public string href { get; set; }
    }

    public class Nextepisode
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Previousepisode previousepisode { get; set; }
        public Nextepisode nextepisode { get; set; }
    }

    public class Show
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string language { get; set; }
        public List<string> genres { get; set; }
        public string status { get; set; }
        public int? runtime { get; set; }
        public string premiered { get; set; }
        public Schedule schedule { get; set; }
        public Rating rating { get; set; }
        public int weight { get; set; }
        public Network network { get; set; }
        public WebChannel webChannel { get; set; }
        public Externals externals { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public int updated { get; set; }
        public Links _links { get; set; }
    }

    public class RootObject
    {
        public double score { get; set; }
        public Show show { get; set; }
    }


    public class Episode
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public int season { get; set; }
        public int number { get; set; }
        public string airdate { get; set; }
        public string airtime { get; set; }
        public string airstamp { get; set; }
        public int runtime { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public Links _links { get; set; }
    }
}