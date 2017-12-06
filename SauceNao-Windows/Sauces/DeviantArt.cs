using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows.Sauces
{
    class DeviantArt : Sauce
    {
        static string ENDPOINT = "https://deviantart.com/view/";
        public new string Url
        {
            get { return GetUrl(); }
        }

        public DeviantArt(dynamic data) : base((string) data.title, (int) data.da_id, (string) data.author_name) { }

        public override string ToString()
        {
            return String.Format("Title: {0}\nPixiv ID: {1}\nAuthor: {2} (#{3})\nURL: {4}", Title, SauceId, AuthorName, AuthorId, Url);
        }

        protected override string GetUrl()
        {
            return ENDPOINT + SauceId;
        }

        public new static bool IsTheRightAdapterFor(dynamic data)
        {
            return data.da_id != null;
        }
    }
}
