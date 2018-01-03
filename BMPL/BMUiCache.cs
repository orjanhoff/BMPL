using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Linq;
using System.Windows.Forms;

namespace BMPL
{
    class BMUiCache
    {
        //Кэширование конфигурации из xml-файла
        private class preCache:List<string>
        {
            private XmlDocument xml_doc = new XmlDocument();

            public preCache FillPreCache ()
            {
                xml_doc.Load(BMUiConst.bm_path_xml);
                string xpath = string.Format("//section");

                foreach (XmlNode node in xml_doc.DocumentElement.SelectNodes(xpath))
                {
                    xpath = string.Format("//section[@name='{0}']/setting", node.Attributes["name"].Value);

                    foreach (XmlNode innode in node.SelectNodes(xpath))
                    {

                        Add(innode.Attributes["name"].Value);
                    }
                }

                return this;
            }
        }

        //Кэш бизнес-сущностей
        public class Cache:SortedList<string,DataTable>
        {
            //DA-движок
            BMDaGear bm_da_gear;

            public Cache(BMDaGear bm_da_gear)
            {
                this.bm_da_gear = bm_da_gear;
            }

            public void UpdateKey(string table)
            {
                Remove(table);
                Add(table, bm_da_gear.SelectData(table));
            }

            public void BuildCache()
            {
                //Билдим кэш по БД
                foreach (
                            string table in bm_da_gear.SelectData(BMUiConst.bm_name_sys, "icacheflag=1")
                                            .AsEnumerable()
                                            .Select(r => r.Field<string>("stblname"))
                                            .ToList()
                        )
                {
                    Add(table, bm_da_gear.SelectData(table));
                }
            }
        }

    }
}
