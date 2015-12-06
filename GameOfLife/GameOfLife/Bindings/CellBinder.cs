
using GameOfLife.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace GameOfLife.Bindings
{
    public class CellBinder: System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {

            HttpRequestBase request = controllerContext.HttpContext.Request;

            var count = 0;
            var keys = request.Form.AllKeys;
            var cells = new List<Cell>();
            while(count < keys.Length)
            {
                var cellKeys = keys.Skip(count).Take(3).ToList();
                cells.Add( new Cell(
                    Int32.Parse(request.Form.Get(cellKeys[0])),
                    Int32.Parse(request.Form.Get(cellKeys[1])),
                    Boolean.Parse(request.Form.Get(cellKeys[2]))
                ));
                count = count + 3;
            }

            return cells;
        }
    }
}