using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BMPL
{
    class BMUiCache
    {
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
                            string table in bm_da_gear.SelectData(BMInitGear.Bm_name_sys, "icacheflag=1")
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
