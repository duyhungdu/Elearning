using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace LiteSchool.Library.Helpers
{
    public class ListHelper
    {
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            if(list == null) return new DataTable();


            Type propType;
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                
                propType = prop.PropertyType;
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(System.Nullable<>)) {
                    propType = System.Nullable.GetUnderlyingType(prop.PropertyType);
                }

                table.Columns.Add(prop.Name, propType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
