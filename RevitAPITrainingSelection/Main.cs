﻿using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPICalcCountDuct
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var ducts = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))                
                .Cast<Duct>()
                .ToList();

            List<ElementId> dutsId = new List<ElementId>();

            foreach (var item in ducts)
            {
                dutsId.Add(item.Id);
            }

            uidoc.Selection.SetElementIds(dutsId);


            TaskDialog.Show("Воздуховоды",$"Количество воздуховодов {ducts.Count.ToString()} ");


            return Result.Succeeded;
        }
    }
}
