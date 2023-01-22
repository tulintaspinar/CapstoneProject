namespace CapstoneProject.Models
{
    public class PlanetInfoViewList
    {
            public Basicdetail[] basicDetails { get; set; }
            public string description { get; set; }
            public int id { get; set; }
            public Imgsrc[] imgSrc { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public string planetOrder { get; set; }
            public string source { get; set; }
            public string wikiLink { get; set; }
        

        public class Basicdetail
        {
            public string mass { get; set; }
            public string volume { get; set; }
        }

        public class Imgsrc
        {
            public string img { get; set; }
            public string imgDescription { get; set; }
        }


    }
}
