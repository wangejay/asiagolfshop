using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for DTModelBinder
/// </summary>
public class DTModelBinder 
{
    public object BindModel(HttpRequest request)
    {
        // Retrieve request data
        int draw = Convert.ToInt32(request["draw"]);
        int start = Convert.ToInt32(request["start"]);
        int length = Convert.ToInt32(request["length"]);
        // Search
        DTSearch search = new DTSearch
        {
            Value = request["search[value]"],
            Regex = Convert.ToBoolean(request["search[regex]"])
        };
        // Order
        var o = 0;
        var order = new List<DTOrder>();
        while (request["order[" + o + "][column]"] != null)
        {
            order.Add(new DTOrder()
            {
                Column = Convert.ToInt32(request["order[" + o + "][column]"]),
                Dir = request["order[" + o + "][dir]"]
            });
            o++;
        }
        // Columns
        var c = 0;
        var columns = new List<DTColumn>();
        while (request["columns[" + c + "][name]"] != null)
        {
            columns.Add(new DTColumn
            {
                Data = request["columns[" + c + "][data]"],
                Name = request["columns[" + c + "][name]"],
                Orderable = Convert.ToBoolean(request["columns[" + c + "][orderable]"]),
                Search = new DTSearch
                {
                    Value = request["columns[" + c + "][search][value]"],
                    Regex = Convert.ToBoolean(request["columns[" + c + "][search][regex]"])
                }
            });
            c++;
        }
        var d = 0;
        var Condition = new List<DTCondition>();
        while (request["SearchCondition[" + d + "][Name]"] != null)
        {
            Condition.Add(new DTCondition { 
                Name=request["SearchCondition[" + d + "][Name]"],
                Value = request["SearchCondition[" + d + "][Value]"]
            });
            d++;
        }

        return new DTParameterModel
        {
            Draw = draw,
            Start = start,
            Length = length,
            Search = search,
            Order = order,
            Columns = columns,
            Condition=Condition
        };
    }
}