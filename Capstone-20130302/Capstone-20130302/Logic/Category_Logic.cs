using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Capstone_20130302.Models;
using Newtonsoft.Json.Linq;

namespace Capstone_20130302.Logic
{
    public class Category_Logic
    {
        public class children
        {
            public int id { get; set; }
            public string text { get; set; }
        }
        public class _text
        {
            public string text { get; set; }
            public List<children> children { get; set; }
        }

        private static SocialBuyContext db = new SocialBuyContext();


        public static List<_text> CateroryCombobox()
        {

            List<_text> list = new List<_text>();
            var category_root = (from cate in db.Categories
                                 where cate.ParentId == 1
                                 select cate).ToList();
            for (int i = 0; i < category_root.Count; i++)
            {
                _text temp = new _text();
                temp.children = new List<children>();
                temp.text = category_root[i].Name;
                int cateid = category_root[i].CategoryId;
                var category_child = (from _cate in db.Categories
                                        where _cate.ParentId == cateid
                                        select _cate).ToList();
                 for (int j = 0; j < category_child.Count; j++)
                 {
                     children child = new children();
                     child.id = category_child[i].CategoryId;
                     child.text = category_child[i].Name;
                     temp.children.Add(child);
                 }
                 list.Add(temp);
            }
            return list;
            

            /*
            string json = "[{";
            var category_root = (from cate in db.Categories
                                 where cate.ParentId == 1
                                 select cate).ToList();

            for (int i = 0; i < category_root.Count; i++)
            {
                json += "text : " + category_root[i].Name + ",children : [";
                int cateid= category_root[i].CategoryId;
                var category_child = (from _cate in db.Categories
                                        where _cate.ParentId == cateid
                                        select _cate).ToList();
                for (int j = 0; j < category_child.Count; j++)
                {
                    json += "{ id : " + category_child[i].CategoryId + ",text:" + category_child[i].Name + "}";
                    if (j != category_child.Count - 1)
                    {
                        json += ",";
                    }
                }
                json += "]}";
                if (i != category_root.Count - 1)
                {
                    json += ",";
                }
            }
            json += "]}";
            */


           
           // return json;
        }
    }
}